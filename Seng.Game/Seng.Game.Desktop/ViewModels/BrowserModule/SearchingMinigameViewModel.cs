using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls.Primitives;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Seng.Game.Business.DTOs.Components.BrowserModule;
using Seng.Game.Desktop.Helpers.BrowserModule.SearchingMinigame;
using Seng.Game.Desktop.ViewModels.Base;

namespace Seng.Game.Desktop.ViewModels
{
	public class SearchingMinigameViewModel : BaseViewModel, INavigationAware
	{
		private Random random = new Random();
		private SearchingMinigameComponentDto searchingMinigame;
		private int width;
		private int height;
		private string solution;

		private List<List<Field>> wordSearchGrid;
		private List<Word> words;
		private bool wordSearchCompleted;
		private string userSolution;
		private bool solutionCompleted;

		private StringBuilder wordPrefix = new StringBuilder(string.Empty);
		private List<ToggleButton> checkedButtons = new List<ToggleButton>();
		

		public List<List<Field>> WordSearchGrid
		{
			get => wordSearchGrid;
			set => SetProperty(ref wordSearchGrid, value);
		}

		public List<Word> Words
		{
			get => words;
			set => SetProperty(ref words, value);
		}

		public bool WordSearchCompleted
		{
			get => wordSearchCompleted;
			set => SetProperty(ref wordSearchCompleted, value);
		}

		public bool SolutionCompleted
		{
			get => solutionCompleted;
			set => SetProperty(ref solutionCompleted, value);
		}

		public string UserSolution
		{
			get => userSolution;
			set
			{
				SetProperty(ref userSolution, value);

				if (userSolution.ToUpper() == solution)
				{
					SolutionCompleted = true;
					searchingMinigame.IsCompleted = true;
				}
			}
		}

		public DelegateCommand<ToggleButton> FieldClickCommand { get; set; }
		public DelegateCommand ReturnFromSearchingCommand { get; set; }

		public SearchingMinigameViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, GameState gameState)
			: base(regionManager, eventAggregator, gameState)
		{
			FieldClickCommand = new DelegateCommand<ToggleButton>(FieldClickCommandExecute);
			ReturnFromSearchingCommand = new DelegateCommand(ReturnFromSearchingCommandExecute);

			searchingMinigame = GameState.BrowserModule.SearchingMinigame;
			width = searchingMinigame.Width;
			height = searchingMinigame.Height;
			solution = searchingMinigame.Solution.ToUpper();

			Words = searchingMinigame.Words.ToList().ConvertAll(word => new Word {Text = word});
			WordSearchGrid = CreateWordSearchGrid();
			PopulateGridWithWords();
			PopulateGridWithSolution();
			PopulateGridWithEmptyFields();
		}

		public bool IsNavigationTarget(NavigationContext navigationContext) => false;

		public void OnNavigatedTo(NavigationContext navigationContext) { }

		public void OnNavigatedFrom(NavigationContext navigationContext) { }

		private void ReturnFromSearchingCommandExecute()
		{
			RegionManager.RequestNavigate(Regions.BrowserRegion, Regions.MinigameSelectionView);
		}

		private void FieldClickCommandExecute(ToggleButton button)
		{
			if (button.IsChecked == false)
			{
				button.IsChecked = true;
				return;
			}

			if (AllowedField(button))
			{
				checkedButtons.Add(button);
				wordPrefix.Append(button.Content);

				foreach (var word in Words)
				{
					if (word.Text.StartsWith(wordPrefix.ToString()))
					{
						if (wordPrefix.ToString() == word.Text)
						{
							var editedWords = Words.ToList();
							editedWords.First(x => x.Text == word.Text).IsFound = true;
							Words = editedWords;

							if (Words.All(x => x.IsFound))
							{
								WordSearchCompleted = true;
							}

							checkedButtons.Clear();
							wordPrefix.Clear();
						}

						return;
					}
				}
			}

			foreach (var checkedButton in checkedButtons)
			{
				checkedButton.IsChecked = false;
			}

			checkedButtons.Clear();
			wordPrefix.Clear();
		}

		private bool AllowedField(ToggleButton button)
		{
			if (checkedButtons.Count == 0)
			{
				return true;
			}

			var currentPosition = ((Field) checkedButtons.Last().DataContext).Position;
			var newPosition = ((Field) button.DataContext).Position;

			if (newPosition.Row >= currentPosition.Row - 1 && newPosition.Row <= currentPosition.Row + 1 &&
			    newPosition.Column >= currentPosition.Column - 1 && newPosition.Column <= currentPosition.Column + 1)
			{
				if (checkedButtons.Count == 1)
				{
					return true;
				}

				var previousPosition = ((Field) checkedButtons[checkedButtons.Count - 2].DataContext).Position;

				var rowDirection = previousPosition.Row - currentPosition.Row;
				var columnDirection = previousPosition.Column - currentPosition.Column;

				if (currentPosition.Row - rowDirection == newPosition.Row &&
				    currentPosition.Column - columnDirection == newPosition.Column)
				{
					return true;
				}
			}

			button.IsChecked = false;
			return false;
		}

		private List<List<Field>> CreateWordSearchGrid()
		{
			List<List<Field>> grid = new List<List<Field>>();

			for (int row = 0; row < height; row++)
			{
				grid.Add(new List<Field>());
				for (int column = 0; column < width; column++)
				{
					grid[row].Add(new Field
					{
						Position = new Position
						{
							Column = column,
							Row = row
						}
					});
				}
			}

			return grid;
		}

		private void PopulateGridWithWords()
		{
			foreach (var word in Words)
			{
				bool isWordPlaced = false;

				while (!isWordPlaced)
				{
					Position position = new Position
					{
						Row = random.Next(0, height),
						Column = random.Next(0, width)
					};

					if (PlaceWordInGrid(position, word.Text))
					{
						isWordPlaced = true;
					}
				}
			}
		}

		private bool PlaceWordInGrid(Position position, string word)
		{
			List<PlacementOption> placementOptions = new List<PlacementOption>();
			List<PlacementOption> diagonalPlacementOptions = new List<PlacementOption>();

			if (wordSearchGrid[position.Row][position.Column].Letter == '\0')
			{
				if (SpaceLeftToRight(word, position))       placementOptions.Add(PlacementOption.LeftToRight);
				if (SpaceRightToLeft(word, position))       placementOptions.Add(PlacementOption.RightToLeft);
				if (SpaceUpToDown(word, position))          placementOptions.Add(PlacementOption.UpToDown);
				if (SpaceDownToUp(word, position))          placementOptions.Add(PlacementOption.DownToUp);
				if (SpaceDownLeftToUpRight(word, position)) diagonalPlacementOptions.Add(PlacementOption.DownLeftToUpRight);
				if (SpaceUpLeftToDownRight(word, position)) diagonalPlacementOptions.Add(PlacementOption.UpLeftToDownRight);
				if (SpaceDownRightToUpLeft(word, position)) diagonalPlacementOptions.Add(PlacementOption.DownRightToUpLeft);
				if (SpaceUpRightToDownLeft(word, position)) diagonalPlacementOptions.Add(PlacementOption.UpRightToDownLeft);

				if (placementOptions.Count > 0 || diagonalPlacementOptions.Count > 0)
				{
					PlacementOption placementOption = diagonalPlacementOptions.Count > 0
						? diagonalPlacementOptions[random.Next(0, diagonalPlacementOptions.Count)]
						: placementOptions[random.Next(0, placementOptions.Count)];

					switch (placementOption)
					{
						case PlacementOption.LeftToRight:
							PlaceWordLeftToRight(word, position);
							break;
						case PlacementOption.RightToLeft:
							PlaceWordRightToLeft(word, position);
							break;
						case PlacementOption.UpToDown:
							PlaceWordUpToDown(word, position);
							break;
						case PlacementOption.DownToUp:
							PlaceWordDownToUp(word, position);
							break;
						case PlacementOption.DownLeftToUpRight:
							PlaceWordDownLeftToUpRight(word, position);
							break;
						case PlacementOption.UpLeftToDownRight:
							PlaceWordUpLeftToDownRight(word, position);
							break;
						case PlacementOption.DownRightToUpLeft:
							PlaceWordDownRightToUpLeft(word, position);
							break;
						case PlacementOption.UpRightToDownLeft:
							PlaceWordUpRightToDownLeft(word, position);
							break;
					}
					return true;
				}
			}

			return false;
		}

		private bool SpaceLeftToRight(string word, Position position)
		{
			if (width - position.Column < word.Length) return false;

			for (int i = 0; i < word.Length; i++)
			{
				if (WordSearchGrid[position.Row][position.Column + i].Letter != '\0') return false;
			}

			return true;
		}

		private bool SpaceRightToLeft(string word, Position position)
		{
			if (position.Column < word.Length - 1) return false;

			for (int i = 0; i < word.Length; i++)
			{
				if (WordSearchGrid[position.Row][position.Column - i].Letter != '\0') return false;
			}

			return true;
		}

		private bool SpaceUpToDown(string word, Position position)
		{
			if (height - position.Row < word.Length) return false;

			for (int i = 0; i < word.Length; i++)
			{
				if (WordSearchGrid[position.Row + i][position.Column].Letter != '\0') return false;
			}

			return true;
		}

		private bool SpaceDownToUp(string word, Position position)
		{
			if (position.Row < word.Length - 1) return false;

			for (int i = 0; i < word.Length; i++)
			{
				if (WordSearchGrid[position.Row - i][position.Column].Letter != '\0') return false;
			}

			return true;
		}

		private bool SpaceDownLeftToUpRight(string word, Position position)
		{
			if (width - position.Column < word.Length || position.Row < word.Length - 1) return false;

			for (int i = 0; i < word.Length; i++)
			{
				if (WordSearchGrid[position.Row - i][position.Column + i].Letter != '\0') return false;
			}

			return true;
		}

		private bool SpaceUpLeftToDownRight(string word, Position position)
		{
			if (width - position.Column < word.Length || height - position.Row < word.Length) return false;

			for (int i = 0; i < word.Length; i++)
			{
				if (WordSearchGrid[position.Row + i][position.Column + i].Letter != '\0') return false;
			}

			return true;
		}

		private bool SpaceDownRightToUpLeft(string word, Position position)
		{
			if (position.Row < word.Length - 1 || position.Column < word.Length - 1) return false;

			for (int i = 0; i < word.Length; i++)
			{
				if (WordSearchGrid[position.Row - i][position.Column - i].Letter != '\0') return false;
			}

			return true;
		}

		private bool SpaceUpRightToDownLeft(string word, Position position)
		{
			if (height - position.Row < word.Length || position.Column < word.Length - 1) return false;

			for (int i = 0; i < word.Length; i++)
			{
				if (WordSearchGrid[position.Row + i][position.Column - i].Letter != '\0') return false;
			}

			return true;
		}

		private void PlaceWordLeftToRight(string word, Position position)
		{
			for (int i = 0; i < word.Length; i++)
			{
				WordSearchGrid[position.Row][position.Column + i].Letter = word[i];
			}
		}

		private void PlaceWordRightToLeft(string word, Position position)
		{
			for (int i = 0; i < word.Length; i++)
			{
				WordSearchGrid[position.Row][position.Column - i].Letter = word[i];
			}
		}

		private void PlaceWordUpToDown(string word, Position position)
		{
			for (int i = 0; i < word.Length; i++)
			{
				WordSearchGrid[position.Row + i][position.Column].Letter = word[i];
			}
		}

		private void PlaceWordDownToUp(string word, Position position)
		{
			for (int i = 0; i < word.Length; i++)
			{
				WordSearchGrid[position.Row - i][position.Column].Letter = word[i];
			}
		}

		private void PlaceWordDownLeftToUpRight(string word, Position position)
		{
			for (int i = 0; i < word.Length; i++)
			{
				WordSearchGrid[position.Row - i][position.Column + i].Letter = word[i];
			}
		}

		private void PlaceWordUpLeftToDownRight(string word, Position position)
		{
			for (int i = 0; i < word.Length; i++)
			{
				WordSearchGrid[position.Row + i][position.Column + i].Letter = word[i];
			}
		}

		private void PlaceWordDownRightToUpLeft(string word, Position position)
		{
			for (int i = 0; i < word.Length; i++)
			{
				WordSearchGrid[position.Row - i][position.Column - i].Letter = word[i];
			}
		}

		private void PlaceWordUpRightToDownLeft(string word, Position position)
		{
			for (int i = 0; i < word.Length; i++)
			{
				WordSearchGrid[position.Row + i][position.Column - i].Letter = word[i];
			}
		}

		private void PopulateGridWithSolution()
		{
			int solutionIndex = 0;
			int emptyFields = height * width;

			foreach (var word in Words)
			{
				emptyFields -= word.Text.Length;
			}

			int spaceBetweenSolutionFields = (int) Math.Floor(((float) emptyFields / solution.Length));
			int space = 0;
			
			for (int row = 0; row < height; row++)
			{
				for (int column = 0; column < width; column++)
				{
					if (WordSearchGrid[row][column].Letter == '\0')
					{
						space += 1;

						if (space == spaceBetweenSolutionFields)
						{
							if (solutionIndex == solution.Length) return;

							WordSearchGrid[row][column].Letter = solution[solutionIndex];
							WordSearchGrid[row][column].IsPartOfSolution = true;

							solutionIndex += 1;
							space = 0;
						}
					}
				}
			}
		}

		private void PopulateGridWithEmptyFields()
		{
			string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			for (int row = 0; row < height; row++)
			{
				for (int column = 0; column < width; column++)
				{
					if (WordSearchGrid[row][column].Letter == '\0')
					{
						WordSearchGrid[row][column].Letter = alphabet[random.Next(0, alphabet.Length)];
					}
				}
			}
		}
	}
}
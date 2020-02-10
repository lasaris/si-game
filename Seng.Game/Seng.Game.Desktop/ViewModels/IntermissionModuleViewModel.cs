using Prism.Commands;
using Seng.Game.Business.DTOs.Components.IntermissionModule;
using Seng.Game.Desktop.ViewModels.Base;
using System.Collections.Generic;
using System.Linq;
using Seng.Game.Business.DTOs.Components;

namespace Seng.Game.Desktop.ViewModels
{
	public class IntermissionModuleViewModel : BaseViewModel
	{
		private readonly List<IntermissionFrameComponentDto> _frames;
		private int _currentFrame;
		
		private List<TextComponentDto> _currentTexts;
		private List<QuestionComponentDto> _currentQuestions;
		private ButtonComponentDto _currentButton;

		public List<TextComponentDto> CurrentTexts
		{
			get => _currentTexts;
			set => SetProperty(ref _currentTexts, value);
		}

		public List<QuestionComponentDto> CurrentQuestions
		{
			get => _currentQuestions;
			set => SetProperty(ref _currentQuestions, value);
		}

		public ButtonComponentDto CurrentButton
		{
			get => _currentButton;
			set => SetProperty(ref _currentButton, value);
		}

		public DelegateCommand<ICloseable> CloseCommand { get; set; }

		public IntermissionModuleViewModel()
		{
			_currentFrame = 0;
			_frames = IntermissionModule.Frames.ToList();

			UpdateFrameContent();

			CloseCommand = new DelegateCommand<ICloseable>(NextOrClose);
		}

		private void NextOrClose(ICloseable window)
		{
			var lastFrame = _currentFrame + 1 == _frames.Count;

			if (lastFrame) window?.Close();
			else
			{
				_currentFrame += 1;
				UpdateFrameContent();
			}
		}

		private void UpdateFrameContent()
		{
			CurrentTexts = _frames[_currentFrame].TextParagraphs == null
				? new List<TextComponentDto>()
				: _frames[_currentFrame].TextParagraphs.ToList();

			CurrentQuestions = _frames[_currentFrame].Questions == null
				? new List<QuestionComponentDto>()
				: _frames[_currentFrame].Questions.ToList();

			CurrentButton = _frames[_currentFrame].Button == null
				? new ButtonComponentDto { Text = string.Empty }
				: _frames[_currentFrame].Button;
		}
	}
}
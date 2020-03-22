using System;
using System.Collections.Generic;
using Seng.Game.Business.DTOs.Components.EmailModule;
using Seng.Game.Business.DTOs.Components.IntermissionModule;
using Seng.Game.Business.DTOs.Modules;

namespace Seng.Game.Desktop
{
	public static class GameInitialize
	{
		public static IntermissionModuleDto IntermissionModuleGet()
		{
			var intermissionModule = new IntermissionModuleDto
			{
				ModuleId = 1,
				IsRunning = false,
				IsVisible = true,
				Frames = new List<IntermissionFrameComponentDto>
					{
						new IntermissionFrameComponentDto
						{
							ComponentId = 2,
								TextParagraph = "Hello, this is our demo game",
								Question = new QuestionComponentDto()
							{
								ComponentId = 4,
								Text = "Example question ?",
								Options = new List<OptionComponentDto>()
								{
									new OptionComponentDto()
									{
										ComponentId = 5,
										Text = "First option",
										Clicked = false
									},
									new OptionComponentDto()
									{
										ComponentId = 6,
										Text = "Second option",
										Clicked = false
									}
								}
							}
						},
						new IntermissionFrameComponentDto
						{
							ComponentId = 7,
							TextParagraph = "Second page\nAnother row",
						},
						new IntermissionFrameComponentDto
						{
							ComponentId = 9,
							Question = new QuestionComponentDto()
							{
								ComponentId = 10,
								Text = "Slide with multichoice question ?",
								Multichoice = true,
								Options = new List<OptionComponentDto>()
								{
									new OptionComponentDto()
									{
										ComponentId = 11,
										Text = "Definitely yes"
									},
									new OptionComponentDto()
									{
										ComponentId = 12,
										Text = "Probably yes"
									},
									new OptionComponentDto()
									{
										ComponentId = 13,
										Text = "Probably no"
									},
									new OptionComponentDto()
									{
										ComponentId = 14,
										Text = "Definitely no"
									}
								}
							}
						}
					}
			};
			return intermissionModule;


			/*
			//dependency injection configuration
			var serviceCollection = new ServiceCollection();
			serviceCollection.AddBusiness();

			//resolve manually dependency injection
			//you should probably do this automatically
			var serviceProvider = serviceCollection.BuildServiceProvider();

			//resolve mediator
			//this should be done through constructor injection automatically
			IMediator mediator = serviceProvider.GetService<IMediator>();

			//creating request and fetching data
			//this is the way you should call Business layer
			var runActionRequest = new GetModuleAfterActionRequest<IntermissionModuleDto>
			{
				Module = new IntermissionModuleDto(),
				TriggeredComponentId = 4
			};
			ModuleAfterActionDto<IntermissionModuleDto> gameState = await mediator.Send(runActionRequest);

			return gameState.CurrentModule;
			*/
		}

		public static EmailModuleDto EmailModuleGet()
		{
			var emailModule = new EmailModuleDto
			{
				IsRunning = true,
				IsVisible = true,
				NewEmail = new NewEmailComponentDto
				{
					Recipients = new List<RecipientComponentDto>()
					{
						new RecipientComponentDto()
						{
							Address = "First",
							ContentHeader = "Dear Mr. First,",
							ContentFooter = "Regards",
							FirstParagraphs = new List<ParagraphComponentDto>
							{
								new ParagraphComponentDto()
								{
									Text = "First option in first paragraph",
									ChildrenParagraphs = new List<ParagraphComponentDto>
									{
										new ParagraphComponentDto
										{
											Text = "First Children"
										},
										new ParagraphComponentDto
										{
											Text = "Second Children"
										},
										new ParagraphComponentDto
										{
											Text = "Third Children"
										},
										new ParagraphComponentDto
										{
											Text = "Forth Children"
										}
									}
								},
								new ParagraphComponentDto
								{
									Text = "Second option in first paragraph"
								},
								new ParagraphComponentDto
								{
									Text = "Third option in first paragraph"
								},
								new ParagraphComponentDto
								{
									Text = "Forth option in first paragraph"
								}
							}
						},
						new RecipientComponentDto()
						{
							Address = "Second",
							ContentHeader = "Dear Mr. Second,",
							ContentFooter = "Regards",
							FirstParagraphs = new List<ParagraphComponentDto>
							{
								new ParagraphComponentDto()
								{
									Text = "First option in first paragraph",
									ChildrenParagraphs = new List<ParagraphComponentDto>
									{
										new ParagraphComponentDto
										{
											Text = "First Children"
										},
										new ParagraphComponentDto
										{
											Text = "Second Children"
										},
										new ParagraphComponentDto
										{
											Text = "Third Children"
										},
										new ParagraphComponentDto
										{
											Text = "Forth Children"
										}
									}
								},
								new ParagraphComponentDto
								{
									Text = "Second option in first paragraph"
								},
								new ParagraphComponentDto
								{
									Text = "Third option in first paragraph"
								},
								new ParagraphComponentDto
								{
									Text = "Forth option in first paragraph"
								}
							}
						},
						new RecipientComponentDto()
						{
							Address = "Third",
							ContentHeader = "Dear Mr. Third,",
							ContentFooter = "Regards",
							FirstParagraphs = new List<ParagraphComponentDto>
							{
								new ParagraphComponentDto()
								{
									Text = "First option in first paragraph",
									ChildrenParagraphs = new List<ParagraphComponentDto>
									{
										new ParagraphComponentDto
										{
											Text = "First Children"
										},
										new ParagraphComponentDto
										{
											Text = "Second Children"
										},
										new ParagraphComponentDto
										{
											Text = "Third Children"
										},
										new ParagraphComponentDto
										{
											Text = "Forth Children"
										}
									}
								},
								new ParagraphComponentDto
								{
									Text = "Second option in first paragraph"
								},
								new ParagraphComponentDto
								{
									Text = "Third option in first paragraph"
								},
								new ParagraphComponentDto
								{
									Text = "Forth option in first paragraph"
								}
							}
						},
						new RecipientComponentDto()
						{
							Address = "Forth",
							ContentHeader = "Dear Mr. Forth,",
							ContentFooter = "Regards",
							FirstParagraphs = new List<ParagraphComponentDto>
							{
								new ParagraphComponentDto()
								{
									Text = "First option in first paragraph",
									ChildrenParagraphs = new List<ParagraphComponentDto>
									{
										new ParagraphComponentDto
										{
											Text = "First Children"
										},
										new ParagraphComponentDto
										{
											Text = "Second Children"
										},
										new ParagraphComponentDto
										{
											Text = "Third Children"
										},
										new ParagraphComponentDto
										{
											Text = "Forth Children"
										}
									}
								},
								new ParagraphComponentDto
								{
									Text = "Second option in first paragraph"
								},
								new ParagraphComponentDto
								{
									Text = "Third option in first paragraph"
								},
								new ParagraphComponentDto
								{
									Text = "Forth option in first paragraph"
								}
							}
						}
					}
				},
				RegularEmails = new List<EmailComponentDto>
				{
					new EmailComponentDto
					{
						Sender = "James Black",
						Date = DateTime.Today,
						Subject = "Example Subject",
						ContentHeader = "Header,",
						Paragraphs = new List<string>
						{
							"Example first paragraph",
							"Example second paragraph"
						},
						ContentFooter = "Footer"
					},
					new EmailComponentDto
					{
						Sender = "James Black",
						Date = DateTime.Today,
						Subject = "Example Subject",
						ContentHeader = "Header,",
						Paragraphs = new List<string>
						{
							"Example first paragraph",
							"Example second paragraph"
						},
						ContentFooter = "Footer"
					},
					new EmailComponentDto
					{
						Sender = "James Black",
						Date = DateTime.Today,
						Subject = "Example Subject",
						ContentHeader = "Header,",
						Paragraphs = new List<string>
						{
							"Example first paragraph",
							"Example second paragraph"
						},
						ContentFooter = "Footer"
					},
					new EmailComponentDto
					{
						Sender = "James Black",
						Date = DateTime.Today,
						Subject = "Example Subject",
						ContentHeader = "Header,",
						Paragraphs = new List<string>
						{
							"Example first paragraph",
							"Example second paragraph"
						},
						ContentFooter = "Footer"
					},
					new EmailComponentDto
					{
						Sender = "James Black",
						Date = DateTime.Today,
						Subject = "Example Subject",
						ContentHeader = "Header,",
						Paragraphs = new List<string>
						{
							"Example first paragraph",
							"Example second paragraph"
						},
						ContentFooter = "Footer"
					},
					new EmailComponentDto
					{
						Sender = "James Black",
						Date = DateTime.Today,
						Subject = "Example Subject",
						ContentHeader = "Header,",
						Paragraphs = new List<string>
						{
							"Example first paragraph",
							"Example second paragraph"
						},
						ContentFooter = "Footer"
					},
					new EmailComponentDto
					{
						Sender = "James Black",
						Date = DateTime.Today,
						Subject = "Example Subject",
						ContentHeader = "Header,",
						Paragraphs = new List<string>
						{
							"Example first paragraph",
							"Example second paragraph"
						},
						ContentFooter = "Footer"
					},
					new EmailComponentDto
					{
						Sender = "James Black",
						Date = DateTime.Today,
						Subject = "Example Subject",
						ContentHeader = "Header,",
						Paragraphs = new List<string>
						{
							"Example first paragraph",
							"Example second paragraph"
						},
						ContentFooter = "Footer"
					}
				}
			};
			return emailModule;
		}
	}
}
using System.Collections.Generic;
using Seng.Game.Business.DTOs.Components;
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
				IsRunning = true,
				IsVisible = true,
				Frames = new List<IntermissionFrameComponentDto>
					{
						new IntermissionFrameComponentDto
						{
							ComponentId = 2,
							TextParagraphs = new List<TextComponentDto>
							{
								new TextComponentDto
								{
									ComponentId = 3,
									Text = "Hello, this is our demo game"
								}
							},
							Questions = new List<QuestionComponentDto>
							{
								new QuestionComponentDto
								{
									Text = "Question ?",
									ComponentId = 4,
									Answers = new List<AnswerComponentDto>
									{
										new AnswerComponentDto()
										{
											ComponentId = 8,
											Text = "First Answer"
										},
										new AnswerComponentDto()
										{
											ComponentId = 9,
											Text = "Second Answer"
										}
									}
								}
							}
						},
						new IntermissionFrameComponentDto
						{
							ComponentId = 5,
							TextParagraphs = new List<TextComponentDto>
							{
								new TextComponentDto()
								{
									ComponentId = 6,
									Text = "Second page"
								},
								new TextComponentDto()
								{
									ComponentId = 7,
									Text = "Another paragraph"
								}
							}
						},
						new IntermissionFrameComponentDto
						{
							ComponentId = 10,
							Questions = new List<QuestionComponentDto>
							{
								new QuestionComponentDto
								{
									ComponentId = 11,
									Text = "Slide with another question ?",
									Answers = new List<AnswerComponentDto>
									{
										new AnswerComponentDto()
										{
											ComponentId = 12,
											Text = "Definitely yes"
										},
										new AnswerComponentDto()
										{
											ComponentId = 13,
											Text = "Probably yes"
										},
										new AnswerComponentDto()
										{
											ComponentId = 14,
											Text = "Probably no"
										},
										new AnswerComponentDto()
										{
											ComponentId = 15,
											Text = "Definitely no"
										}
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
	}
}
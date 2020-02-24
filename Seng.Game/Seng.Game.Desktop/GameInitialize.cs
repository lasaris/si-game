﻿using System.Collections.Generic;
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
								TextParagraph = new TextComponentDto()
							{
								ComponentId = 3,
								Text = "Hello, this is our demo game"
							},
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
							TextParagraph = new TextComponentDto()
							{
								ComponentId = 8,
								Text = "Second page\nAnother row"
							}
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
	}
}
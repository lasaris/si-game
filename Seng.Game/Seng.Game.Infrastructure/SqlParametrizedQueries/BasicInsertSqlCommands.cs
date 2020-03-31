using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Infrastructure.SqlParametrizedQueries
{
    static class BasicInsertSqlCommands
    {
        public const string SwitchIntermissionFrameActionCommand = @"INSERT INTO [action.SwitchIntermissionFramesAction] 
                                                                    (
                                                                        Id,
                                                                        GameActionId,
                                                                        NewIntermissionFrameComponentId
                                                                    )
                                                                    VALUES (
                                                                        @Id,
                                                                        @GameActionId,
                                                                        @NewIntermissionFrameComponentId
                                                                    );";

        public const string ContextCommand = @"INSERT INTO [action.Context] 
                                            (
                                                Id,
                                                ClickedComponentId,
                                                AlreadyRunActionId,
                                                OnClickOptionId,
                                                InLast,
                                                InFirst
                                            )
                                            VALUES (
                                                @Id,
                                                @ClickedComponentId,
                                                @AlreadyRunActionId,
                                                @OnClickOptionId,
                                                @InLast,
                                                @InFirst
                                            );";

        public const string GameActionCommand = @"INSERT INTO [action.GameAction] 
                                            (
                                                Id,
                                                Type
                                            )
                                            VALUES (
                                                @Id,
                                                @Type
                                            );";

        public const string OnClickOptionCommand = @"INSERT INTO [action.OnClickOption] 
                                                (
                                                    Id,
                                                    ComponentId,
                                                    ResultActionId
                                                )
                                                VALUES (
                                                    @Id,
                                                    @ComponentId,
                                                    @ResultActionId
                                                );";

        public const string IntermissionFrameComponentCommand = @"INSERT INTO [component.IntermissionFrameComponent] 
                                                    (
                                                        Id,
                                                        IntermissionModuleId,
                                                        ButtonComponentId,
                                                        TextParagraph,
                                                        ComponentId,
                                                        QuestionComponentId
                                                    )
                                                    VALUES (
                                                        @Id,
                                                        @IntermissionModuleId,
                                                        @ButtonComponentId,
                                                        @TextParagraph,
                                                        @ComponentId,
                                                        @QuestionComponentId
                                                    );";

        public const string ButtonComponentCommand = @"INSERT INTO [component.ButtonComponent] 
                                                        (
                                                            Id,
                                                            Text,
                                                            ComponentId
                                                        )
                                                        VALUES (
                                                            @Id,
                                                            @Text,
                                                            @ComponentId
                                                        );";

        public const string ComponentCommand = @"INSERT INTO [component.Component] 
                                            (
                                                Id
                                            )
                                            VALUES (
                                                @Id
                                            );";

        public const string IntermissionModuleCommand = @"INSERT INTO [module.IntermissionModule] 
                                                    (
                                                        Id,
                                                        ModuleId,
                                                        CurrentlyVisibleFrameId
                                                    )
                                                    VALUES (
                                                        @Id,
                                                        @ModuleId,
                                                        @CurrentlyVisibleFrameId
                                                    );";

        public const string ModuleCommand = @"INSERT INTO [module.Module] 
                                        (
                                            Id,
                                            IsVisible
                                        )
                                        VALUES (
                                            @Id,
                                            @IsVisible
                                        );";

        public const string OptionComponentCommand = @"INSERT INTO [component.OptionComponent] 
                                            (
                                                Id,
                                                ComponentId,
                                                Text,
                                                QuestionComponentId
                                            )
                                            VALUES (
                                                @Id,
                                                @ComponentId,
                                                @Text,
                                                @QuestionComponentId
                                            );";

        public const string QuestionComponentCommand = @"INSERT INTO [component.QuestionComponent] (
                                                            Id,
                                                            ComponentId,
                                                            Text,
                                                            Multichoice
                                                        )
                                                        VALUES (
                                                            @Id,
                                                            @ComponentId,
                                                            @Text,
                                                            @Multichoice
                                                        );";
    }
}

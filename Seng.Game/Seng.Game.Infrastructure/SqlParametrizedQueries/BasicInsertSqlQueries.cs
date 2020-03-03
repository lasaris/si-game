using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Infrastructure.SqlParametrizedQueries
{
    static class BasicInsertSqlQueries
    {
        public static IEnumerable<string> AllBasicInserts = new List<string>
        {
            SwitchIntermissionFrameActionQuery,
            ContextQuery,
            GameActionQuery,
            OnClickOptionQuery,
            IntermissionFrameQuery,
            ButtonQuery,
            ComponentQuery,
            IntermissionModuleQuery,
            ModuleQuery
        };

        public const string SwitchIntermissionFrameActionQuery = @"INSERT INTO [action.SwitchIntermissionFramesAction] 
                                                                (
                                                                    Id,
                                                                    ActionId,
                                                                    NewIntermissionFrameId
                                                                )
                                                                VALUES (
                                                                    @Id,
                                                                    @ActionId,
                                                                    @NewIntermissionFrameId
                                                                );";

        public const string ContextQuery = @"INSERT INTO [action.Context] 
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

        public const string GameActionQuery = @"INSERT INTO [action.GameAction] 
                                            (
                                                Id
                                            )
                                            VALUES (
                                                @Id
                                            );";

        public const string OnClickOptionQuery = @"INSERT INTO [action.OnClickOption] 
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

        public const string IntermissionFrameQuery = @"INSERT INTO [component.IntermissionFrame] 
                                                    (
                                                        Id,
                                                        IntermissionModuleId,
                                                        ButtonId,
                                                        TextParagraph
                                                    )
                                                    VALUES (
                                                        @Id,
                                                        @IntermissionModuleId,
                                                        @ButtonId,
                                                        @TextParagraph
                                                    );";

        public const string ButtonQuery = @"INSERT INTO [component.Button] 
                                        (
                                            Id,
                                            Text
                                        )
                                        VALUES (
                                            @Id,
                                            @Text
                                        );";

        public const string ComponentQuery = @"INSERT INTO [component.Component] 
                                            (
                                                Id
                                            )
                                            VALUES (
                                                @Id
                                            );";

        public const string IntermissionModuleQuery = @"INSERT INTO [module.IntermissionModule] 
                                                    (
                                                        Id,
                                                        ModuleId
                                                    )
                                                    VALUES (
                                                        @Id,
                                                        @ModuleId
                                                    );";

        public const string ModuleQuery = @"INSERT INTO [module.Module] 
                                        (
                                            Id,
                                            IsVisible,
                                            IsRunning
                                        )
                                        VALUES (
                                            @Id,
                                            @IsVisible,
                                            @IsRunning
                                        );";
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Infrastructure.SqlParametrizedQueries
{
    static class BasicInsertSqlCommands
    {
        public const string SwitchIntermissionFrameActionCommand = @"INSERT INTO [action.SwitchIntermissionFramesAction] 
                                                                    (
                                                                        ActionId,
                                                                        NewIntermissionFrameComponentId
                                                                    )
                                                                    VALUES (
                                                                        @ActionId,
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
                                                    ResultActionId,
                                                    UseClickedComponentConstraint
                                                )
                                                VALUES (
                                                    @Id,
                                                    @ComponentId,
                                                    @ResultActionId,
                                                    @UseClickedComponentConstraint
                                                );";

        public const string IntermissionFrameComponentCommand = @"INSERT INTO [component.IntermissionFrameComponent] 
                                                    (
                                                        IntermissionModuleId,
                                                        ButtonComponentId,
                                                        TextParagraph,
                                                        ComponentId,
                                                        QuestionComponentId
                                                    )
                                                    VALUES (
                                                        @IntermissionModuleId,
                                                        @ButtonComponentId,
                                                        @TextParagraph,
                                                        @ComponentId,
                                                        @QuestionComponentId
                                                    );";

        public const string ButtonComponentCommand = @"INSERT INTO [component.ButtonComponent] 
                                                        (
                                                            Text,
                                                            ComponentId
                                                        )
                                                        VALUES (
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
                                                        ModuleId,
                                                        CurrentlyVisibleFrameId
                                                    )
                                                    VALUES (
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
                                                ComponentId,
                                                Text,
                                                QuestionComponentId
                                            )
                                            VALUES (
                                                @ComponentId,
                                                @Text,
                                                @QuestionComponentId
                                            );";

        public const string CommonGameDataCommand = @"INSERT INTO [module.CommonGameData] (
                                        Id,
                                        MainVisibleModuleId
                                    )
                                    VALUES (
                                        @Id,
                                        @MainVisibleModuleId
                                    );";

        public const string QuestionComponentCommand = @"INSERT INTO [component.QuestionComponent] (
                                                              ComponentId,
                                                              Text
                                                          )
                                                          VALUES (
                                                              @ComponentId,
                                                              @Text
                                                          );";

        public const string EmailModuleCommand = @"INSERT INTO [module.EmailModule] (
                                     ModuleId,
                                     NewEmailSubject,
                                     NewEmailButtonComponentId
                                 )
                                 VALUES (
                                     @ModuleId,
                                     @NewEmailSubject,
                                     @NewEmailButtonComponentId
                                 );";

        public const string BrowserModuleCommand = @"INSERT INTO [module.BrowserModule] (
                                       SearchingMinigameComponentId,
                                       ModuleId
                                   )
                                   VALUES (
                                       @SearchingMinigameComponentId,
                                       @ModuleId
                                   );";

        public const string SearchingMinigameComponentCommand = @"INSERT INTO [component.SearchingMinigameComponent] (                                                       Solution,
                                                       IsCompleted,
                                                       Height,
                                                       Width,
                                                       ComponentId
                                                   )
                                                   VALUES (
                                                       @Solution,
                                                       @IsCompleted,
                                                       @Height,
                                                       @Width,
                                                       @ComponentId
                                                   );";

        public const string WordComponentCommand = @"INSERT INTO [component.WordComponent] (
                                          Value,
                                          SearchingMinigameComponentId
                                      )
                                      VALUES (
                                          @Value,
                                          @SearchingMinigameComponentId
                                      );";

        public const string EmailComponentCommand = @"INSERT INTO [component.EmailComponent] (
                                           Sender,
                                           Subject,
                                           Date,
                                           ContentHeader,
                                           ContentFooter,
                                           ComponentId,
                                           IsSentEmail,
                                           EmailModuleId,
                                           Active
                                       )
                                       VALUES (
                                           @Sender,
                                           @Subject,
                                           @Date,
                                           @ContentHeader,
                                           @ContentFooter,
                                           @ComponentId,
                                           @IsSentEmail,
                                           @EmailModuleId,
                                           @Active
                                       );";

        public const string EmailComponentParagraphCommand = @"INSERT INTO [component.EmailComponentParagraph] (
                                                    Id,
                                                    Content,
                                                    EmailComponentId
                                                )
                                                VALUES (
                                                    @Id,
                                                    @Content,
                                                    @EmailComponentId
                                                );";

        public const string NewEmailParagraphComponentCommand = @"INSERT INTO [component.NewEmailParagraphComponent] (
                                                       Text,
                                                       ParentParagraphId,
                                                       ComponentId,
                                                       RecipientComponentId
                                                   )
                                                       @Id,
                                                       @Text,
                                                       @ParentParagraphId,
                                                       @ComponentId,
                                                       @RecipientComponentId'
                                                   );";

        public const string RecipientComponentCommand = @"INSERT INTO [component.RecipientComponent] (
                                               ComponentId,
                                               Address,
                                               Description,
                                               ContentHeader,
                                               ContentFooter,
                                               EmailModuleId,
                                               ButtonComponentId,
                                               Active
                                           )
                                           VALUES (
                                               @ComponentId,
                                               @Address,
                                               @Description,
                                               @ContentHeader,
                                               @ContentFooter,
                                               @EmailModuleId,
                                               @ButtonComponentId,
                                               @Active
                                           );";

        public const string UpdateMainVisibleModuleActionCommand = @"INSERT INTO [action.UpdateMainVisibleModuleAction] (
                                                       ActionId,
                                                       NewMainVisibleModuleId
                                                   )
                                                   VALUES (
                                                       @ActionId,
                                                       @NewMainVisibleModuleId
                                                   );";

        public const string AddRecipientToNewEmailActionCommand = @"INSERT INTO [action.AddRecipientToNewEmailAction] (
                                                      ActionId,
                                                      RecipientComponentId
                                                  )
                                                  VALUES (
                                                      @ActionId,
                                                      @RecipientComponentId
                                                  );";

        public const string SendEmailToPlayerActionCommand = @"INSERT INTO [action.SendEmailToPlayerAction] (
                                                 ActionId,
                                                 EmailComponentId
                                             )
                                             VALUES (
                                                 @ActionId,
                                                 @EmailComponentId
                                             );";
    }
}

using MediatR;
using Seng.Game.Business.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Seng.Common.Entities.Actions;

namespace Seng.Game.Infrastructure.QueryHandlers
{
    public class GetActionByComponentQueryHandler : IQueryHandler<GetActionByComponentQuery, GameAction>
    {
        private const string SqlQuery = @"SELECT
                                            ResultActionId
                                        FROM[action.OnClickOption] oco
                                        INNER JOIN[action.Context] c ON oco.Id = c.OnClickOptionId
                                        LEFT JOIN[history.ActionHistory] ah
                                        ON c.AlreadyRunActionId = ah.GameActionId
                                        AND (SELECT Value FROM [history.ActionsMetaStatistics] WHERE Type = 'ExecutedActionsSum') - c.InLast <= InsertOrder
                                        AND InFirst >= InsertOrder
                                        WHERE ComponentId = @TriggeredComponent
                                        AND c.ClickedComponentId IN(@ClickedComponents);";

        public Task<GameAction> Handle(GetActionByComponentQuery query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

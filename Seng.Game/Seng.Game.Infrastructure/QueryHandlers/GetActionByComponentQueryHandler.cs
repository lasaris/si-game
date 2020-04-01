using MediatR;
using Seng.Game.Business.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Seng.Common.Entities.Actions;
using Seng.Game.Infrastructure.Database;
using Dapper;
using System.Linq;

namespace Seng.Game.Infrastructure.QueryHandlers
{
    class GetActionByComponentQueryHandler : IQueryHandler<GetActionByComponentQuery, IEnumerable<GameAction>>
    {
        private const string SqlQuery = @"SELECT
                                            oco.ResultActionId AS Id,
                                            a.Type AS Type
                                        FROM [action.OnClickOption] oco
                                        INNER JOIN [action.GameAction] a ON a.Id = oco.ResultActionId
                                        INNER JOIN [action.Context] c ON oco.Id = c.OnClickOptionId
                                        LEFT JOIN[history.ActionHistory] ah
                                        ON c.AlreadyRunActionId = ah.GameActionId
                                        AND (SELECT Value FROM [history.ActionsMetaStatistics] WHERE Type = 'ExecutedActionsSum') - c.InLast <= InsertOrder
                                        AND InFirst >= InsertOrder
                                        WHERE ComponentId = @ComponentId
                                        AND c.ClickedComponentId IN @ClickedComponentIds;";

        private IDbConnectionCreator _dbConnectionCreator;

        public GetActionByComponentQueryHandler(IDbConnectionCreator dbConnectionCreator)
        {
            _dbConnectionCreator = dbConnectionCreator;
        }

        public async Task<IEnumerable<GameAction>> Handle(GetActionByComponentQuery query, CancellationToken cancellationToken)
        {
            using (var dbConnection = _dbConnectionCreator.CreateOpenConnection())
            {
                IEnumerable<GameAction> actions = await dbConnection.QueryAsync<GameAction>(SqlQuery, query);
                return actions == null ? new List<GameAction>() : actions;
            }
        }
    }
}

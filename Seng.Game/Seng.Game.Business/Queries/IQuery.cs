﻿using MediatR;
using Seng.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Queries
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {
    }
}

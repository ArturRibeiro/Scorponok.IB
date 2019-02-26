﻿using System;
using MediatR;

namespace Scorponok.IB.Core.Events
{
    public abstract class Message : IRequest
    {
        public string MessageType
        {
            get;
            protected set;
        }

        public Guid AggregateId
        {
            get;
            protected set;
        }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}

using System;
using Common.Code.StateMachine.States;

namespace Common.Code.StateMachine.Factory
{
    public interface IStatesFactory
    {
        IState GetState(Type state);
    }
}
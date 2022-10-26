using System;

namespace Common.Code.Input
{
    public interface IStartButton
    {
        event Action OnStartButtonClicked;
    }
}
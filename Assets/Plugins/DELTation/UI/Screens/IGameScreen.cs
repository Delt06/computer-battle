using System;

namespace DELTation.UI.Screens
{
    public interface IGameScreen
    {
        bool IsOpened { get; }
        void Open();
        event EventHandler Opened;
        void Close();
        event EventHandler Closed;
        void CloseImmediately();
        event EventHandler ClosedImmediately;
    }
}
using System;
using System.Collections.Generic;
using static System.Math;

internal class TelePrompterConfig
{
    private object lockHandle = new object();
    public int DelayInMilliSeconds { get; private set; } = 200;

    public void UpdateDelay(int increment)
    {
        var newDelay = Min(DelayInMilliSeconds + increment, 1000);
        newDelay = Max(newDelay, 20);
        lock (lockHandle)
        {
            DelayInMilliSeconds = newDelay;
        }
    }

    public bool Done { get; private set; }

    public void SetDone()
    {
        Done = true;
    }
}
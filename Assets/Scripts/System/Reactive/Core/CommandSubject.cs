﻿using System;
using System.Collections.Generic;

public delegate void Callback();
public delegate void Callback<T>(T arg1);

public class CommandSubject : IDisposable
{
    public Dictionary<Type, Delegate> _eventTable = new Dictionary<Type, Delegate>();

    public void Dispose()
    {
        _eventTable.Clear();
    }

    public IDisposable Subscribe<T>(Callback<T> handler)
    {
        Type eventType = typeof(T);
        if (!_eventTable.ContainsKey(eventType))
        {
            _eventTable.Add(eventType, null);
        }
        _eventTable[eventType] = (Callback<T>)_eventTable[eventType] + handler;
        return new AnonymousDisposable(() =>
        {
            RemoveListener<T>(handler);
        });
    }

    private void RemoveListener<T>(Delegate handler)
    {
        Type eventType = typeof(T);
        if (_eventTable.ContainsKey(eventType))
        {
            _eventTable[eventType] = Delegate.Remove(_eventTable[eventType], handler);
            if (_eventTable[eventType] == null)
            {
                _eventTable.Remove(eventType);
            }
        }
    }

    public void OnNext<T>()
    {
        Delegate d;
        Type eventType = typeof(T);

        if (_eventTable.TryGetValue(eventType, out d))
        {
            (d as Callback)?.Invoke();
        }
    }

    public void OnNext<T>(T arg)
    {
        Delegate d;
        Type eventType = typeof(T);

        if (_eventTable.TryGetValue(eventType, out d))
        {
            (d as Callback<T>)?.Invoke(arg);
        }
    }
}

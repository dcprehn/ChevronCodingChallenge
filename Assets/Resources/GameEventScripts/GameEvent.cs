using System;
using System.Globalization;
using UnityEngine;

public abstract class GameEvent : IComparable<GameEvent> {
    protected DateTime timestamp;

    public GameEvent(string date) {
        timestamp = DateTime.ParseExact(date, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
    }

    public DateTime GetTimestamp() {
        return timestamp;
    }

    public int CompareTo(GameEvent other)
    {
        if (other == null)
            return 1;
        
        return timestamp.CompareTo(other.timestamp);
    }

    public abstract void ExecuteEvent();
}
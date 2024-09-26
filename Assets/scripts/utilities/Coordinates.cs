using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Coordinates
{
    public int x;
    public int y;

    public Coordinates(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    // Overloading the '+' operator to work with Vector2Int like we see in How to
    public static Coordinates operator +(Coordinates a, Vector2Int b)
    {
        return new Coordinates(a.x + b.x, a.y + b.y);
    }

    public static bool operator ==(Coordinates a, Coordinates b)
    {
        return a.x == b.x && a.y == b.y;
    }

    public static bool operator !=(Coordinates a, Coordinates b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Coordinates)) return false;
        Coordinates other = (Coordinates)obj;
        return this == other;
    }

    public override int GetHashCode()
    {
        return x.GetHashCode() ^ y.GetHashCode();
    }
}

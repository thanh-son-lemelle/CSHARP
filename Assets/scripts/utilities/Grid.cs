// Generic Grid Class
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Grid<TGridObject> : GridInt
{
    private new TGridObject[,] gridArray;

    public Grid(int width, int height, float cellSize, Vector3 originPosition) : base(width, height, cellSize, originPosition)
    {
        gridArray = new TGridObject[width, height];
    }

    // Override or extend the setValue for generic values
    public void setValue(int x, int y, TGridObject value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            //debugTextArray[x, y].text = gridArray[x, y].ToString();
            triggerGridValueChanged(x, y);
        }
    }

    public void setValue(Vector3 worldPosition, TGridObject value)
    {
        int x, y;
        getXY(worldPosition, out x, out y);
        setValue(x, y, value);
    }

    // Override the getValue to return TGridObject
    public new TGridObject getValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return default(TGridObject); // Return the default value for the generic type
        }
    }

    public new TGridObject getValue(Vector3 worldPosition)
    {
        int x, y;
        getXY(worldPosition, out x, out y);
        return getValue(x, y);
    }
}
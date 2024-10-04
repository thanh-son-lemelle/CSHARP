// GridInt.cs
using System;
using UnityEngine;

public class GridInt
{
    public const int GRID_MAX_VALUE = 100;
    public const int GRID_MIN_VALUE = 0;
    public event EventHandler<OnGridValueChangedEventArgs> onGridValueChanged;
    public class OnGridValueChangedEventArgs : EventArgs {
        public int x;
        public int y;
    }

    protected int width;
    protected int height;
    protected float cellSize;
    protected Vector3 originPosition;
    protected int[,] gridArray;
    //! for debugging

    public GridInt(int width, int height, float cellSize, Vector3 originPosition) {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new int[width, height];

        bool showDebug = true;
        if (showDebug) {
            TextMesh[,] debugTextArray = new TextMesh[width, height];

            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    debugTextArray[x, y] = TextRender.createWorldText(gridArray[x, y].ToString(), null, getWorldPosition(x, y) + new Vector3(cellSize, cellSize) * .5f, 30, Color.white, TextAnchor.MiddleCenter);
                    Debug.DrawLine(getWorldPosition(x, y), getWorldPosition(x, y + 1), Color.white, 100f);
                    Debug.DrawLine(getWorldPosition(x, y), getWorldPosition(x + 1, y), Color.white, 100f);
                }
            }
            Debug.DrawLine(getWorldPosition(0, height), getWorldPosition(width, height), Color.white, 100f);
            Debug.DrawLine(getWorldPosition(width, 0), getWorldPosition(width, height), Color.white, 100f);

            onGridValueChanged += (object sender, OnGridValueChangedEventArgs eventArgs) =>
            {
                debugTextArray[eventArgs.x, eventArgs.y].text = gridArray[eventArgs.x, eventArgs.y].ToString();
            };
        }
    }

    public int getWidth()
    {
        return width;
    }

    public int getHeight()
    {
        return height;
    }

    public float getCellSize()
    {
        return cellSize;
    }

    protected Vector3 getWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    public void getXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public void setValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = Mathf.Clamp(value, GRID_MIN_VALUE, GRID_MAX_VALUE);
            triggerGridValueChanged(x, y);
        }
    }

    public void setValue(Vector3 worldPosition, int value)
    {
        int x, y;
        getXY(worldPosition, out x, out y);
        setValue(x, y, value);
    }

    public void addValue(int x, int y, int value) {
        setValue(x, y, getValue(x, y) + value);
    }

    public int getValue(int x, int y) {
        if (x >= 0 && y >= 0 && x < width && y < height) {
            return gridArray[x, y];
        }
        else {
            return 0; // Or handle it differently
        }
    }

    public int getValue(Vector3 worldPosition)
    {
        int x, y;
        getXY(worldPosition, out x, out y);
        return getValue(x, y);
    }

    protected void triggerGridValueChanged(int x, int y) {
        if (onGridValueChanged != null)
        {
            onGridValueChanged(this, new OnGridValueChangedEventArgs { x = x, y = y });
        }
    }

    public void addValue(Vector3 worldPosition, int value, int fullValueRange, int totalRange) {
        int lowerValueAmount = Mathf.FloorToInt((float)value / totalRange * fullValueRange);

        getXY(worldPosition, out int OriginX, out int OriginY);
        for (int x=0; x < totalRange; x++) {
            for (int y=0; y < totalRange; y++) {
                int radius = x + y;
                int addValueAmount = value;
                if (radius >= fullValueRange) {
                    addValueAmount -= lowerValueAmount * (radius - fullValueRange);
                }

                addValue(OriginX + x, OriginY + y, addValueAmount);
                if (x != 0) {
                    addValue(OriginX - x, OriginY + y, addValueAmount);
                }
                if (y != 0) {
                    addValue(OriginX + x, OriginY - y, addValueAmount);
                    if (x != 0) {
                        addValue(OriginX - x, OriginY - y, addValueAmount);
                    }
                }
            }
        }
    }
}
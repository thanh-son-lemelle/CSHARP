using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    This is a simple test script to test the grid class
    to test the grid class we need to create a game object and attach this script to it
    you can use the sample scene provided in the project to test the grid class
    you can then click on the screen to set a value to a cell and right click to get the value of a cell
*/
public class TestingGrid : MonoBehaviour
{
    // Start is called before the first frame update
    private Grid<bool> grid;
    void Start()
    {

        grid = new Grid<bool>(2, 4, 10f, new Vector3(0, 0));
        grid.onGridValueChanged += (object sender, Grid<bool>.OnGridValueChangedEventArgs eventArgs) =>
        {
            Debug.Log("Value changed at " + eventArgs.x + "," + eventArgs.y);
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Debug.Log(MouseTracking.GetMouseWorldPosition());
            grid.setValue(MouseTracking.GetMouseWorldPosition(),true);
        }
        if (Input.GetMouseButtonDown(1)){
            Debug.Log(grid.getValue(MouseTracking.GetMouseWorldPosition()));
        }
    }
}

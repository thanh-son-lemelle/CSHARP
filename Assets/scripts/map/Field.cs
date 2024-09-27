using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Field : MonoBehaviour
{
    public string fieldName;
    public Coordinates coordinates;

    public virtual bool IsWalkable()
    {
        return true;
    }
}

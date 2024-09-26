using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public List<Field> fields = new List<Field>();

    public Field GetField(Coordinates coordinates)
    {
        return fields.Find(field => field.coordinates == coordinates);
    }
}

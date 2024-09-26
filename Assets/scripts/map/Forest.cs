using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest : Field
{
    
    public override bool IsWalkable()
    {
        // We can add more complex logic here like slowing down the player
        return true;
    }
}

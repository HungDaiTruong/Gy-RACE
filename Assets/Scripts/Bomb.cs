using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Item
{
    public override void Use()
    {
        Debug.Log("Using bomb!");
        // Implement the logic for using the bomb item
    }

    public override void EndUse()
    {
        Debug.Log("Bomb item ended!");
        // Implement the logic to end the bomb item's use
    }
}


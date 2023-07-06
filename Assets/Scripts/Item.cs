using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public float duration = 5f; // Duration for which the item will persist after being used

    public abstract void Use();

    public abstract void EndUse();
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Engine : MonoBehaviour
{
    public float acceleration;
    public float turboMultiplier;
    public float durability;
}

public class StandardEngine : Engine
{
    public StandardEngine()
    {
        acceleration = 2f;
        turboMultiplier = 1.2f;
        durability = 3f;
    }
}

public class TurboEngine : Engine
{
    public TurboEngine()
    {
        acceleration = 1f;
        turboMultiplier = 1.5f;
        durability = 1f;
    }
}

public class OmnidirectionalEngine : Engine
{
    public OmnidirectionalEngine()
    {
        acceleration = 5f;
        turboMultiplier = 1f;
        durability = 2f;
    }
}

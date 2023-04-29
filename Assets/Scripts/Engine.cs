using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Engine : MonoBehaviour
{
    public float acceleration;
    public float turboSpeed;
    public float durability;
}

public class StandardEngine : Engine
{
    public StandardEngine()
    {
        acceleration = 3f;
        turboSpeed = 120f;
        durability = 3f;
    }
}

public class TurboEngine : Engine
{
    public TurboEngine()
    {
        acceleration = 2f;
        turboSpeed = 150f;
        durability = 1f;
    }
}

public class OmnidirectionalEngine : Engine
{
    public OmnidirectionalEngine()
    {
        acceleration = 5f;
        turboSpeed = 100f;
        durability = 2f;
    }
}

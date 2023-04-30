using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Wheel : MonoBehaviour
{
    public float speed;
    public float handling;
    public float durability;
}

public class StandardWheel : Wheel
{
    public StandardWheel()
    {
        speed = 90f;
        handling = 3f;
        durability = 3f;
    }
}

public class OffRoadWheel : Wheel
{
    public OffRoadWheel()
    {
        speed = 80f;
        handling = 4f;
        durability = 5f;
    }
}

public class SmoothWheel : Wheel
{
    public SmoothWheel()
    {
        speed = 100f;
        handling = 2f;
        durability = 2f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Wheel : MonoBehaviour
{
    public float speed;
    public float acceleration;
    public float handling;
}

public class StandardWheel : Wheel
{
    public StandardWheel()
    {
        speed = 5f;
        acceleration = 3f;
        handling = 2f;
    }
}

public class OffRoadWheel : Wheel
{
    public OffRoadWheel()
    {
        speed = 4f;
        acceleration = 2f;
        handling = 4f;
    }
}

public class SportsWheel : Wheel
{
    public SportsWheel()
    {
        speed = 7f;
        acceleration = 4f;
        handling = 1f;
    }
}

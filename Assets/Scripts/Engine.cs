using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Engine : MonoBehaviour
{
    public float power;
    public float torque;
    public float fuelEfficiency;
}

public class StandardEngine : Engine
{
    public StandardEngine()
    {
        power = 5f;
        torque = 3f;
        fuelEfficiency = 2f;
    }
}

public class TurboEngine : Engine
{
    public TurboEngine()
    {
        power = 7f;
        torque = 4f;
        fuelEfficiency = 1f;
    }
}

public class ElectricEngine : Engine
{
    public ElectricEngine()
    {
        power = 6f;
        torque = 2f;
        fuelEfficiency = 5f;
    }
}

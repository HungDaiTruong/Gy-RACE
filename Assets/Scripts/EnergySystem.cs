using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnergySystem : MonoBehaviour
{
    public float energyCapacity;
    public float durability;
    public float energyRegeneration;
}

public class GyroscopicSystem : EnergySystem
{
    public GyroscopicSystem()
    {
        energyCapacity = 300f;
        durability = 2f;
        energyRegeneration = 10f;
    }
}

public class MagneticSystem : EnergySystem
{
    public MagneticSystem()
    {
        energyCapacity = 200f;
        durability = 3f;
        energyRegeneration = 20f;
    }
}

public class GravitySystem : EnergySystem
{
    public GravitySystem()
    {
        energyCapacity = 100f;
        durability = 4f;
        energyRegeneration = 30f;
    }
}

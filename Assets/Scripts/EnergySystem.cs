using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnergySystem : MonoBehaviour
{
    public float energyCapacity;
    public float energyConsumption;
    public float energyRegeneration;
}

public class GyroscopicSystem : EnergySystem
{
    public GyroscopicSystem()
    {
        energyCapacity = 5f;
        energyConsumption = 3f;
        energyRegeneration = 2f;
    }
}

public class MagneticSystem : EnergySystem
{
    public MagneticSystem()
    {
        energyCapacity = 6f;
        energyConsumption = 2f;
        energyRegeneration = 4f;
    }
}

public class GravitySystem : EnergySystem
{
    public GravitySystem()
    {
        energyCapacity = 7f;
        energyConsumption = 1f;
        energyRegeneration = 5f;
    }
}

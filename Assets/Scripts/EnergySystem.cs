using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnergySystem : MonoBehaviour
{
    public float energyConsumption;
    public float durability;
    public float energyRegeneration;
}

public class GyroscopicSystem : EnergySystem
{
    public GyroscopicSystem()
    {
        energyConsumption = 20f;
        durability = 2f;
        energyRegeneration = 1f;
    }
}

public class MagneticSystem : EnergySystem
{
    public MagneticSystem()
    {
        energyConsumption = 30f;
        durability = 3f;
        energyRegeneration = 2f;
    }
}

public class GravitySystem : EnergySystem
{
    public GravitySystem()
    {
        energyConsumption = 50f;
        durability = 4f;
        energyRegeneration = 3f;
    }
}

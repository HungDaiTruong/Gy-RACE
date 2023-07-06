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
        energyRegeneration = 10f;
    }
}

public class MagneticSystem : EnergySystem
{
    public MagneticSystem()
    {
        energyConsumption = 30f;
        durability = 3f;
        energyRegeneration = 20f;
    }
}

public class GravitySystem : EnergySystem
{
    public GravitySystem()
    {
        energyConsumption = 50f;
        durability = 4f;
        energyRegeneration = 30f;
    }
}

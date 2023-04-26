using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnergySystem : MonoBehaviour
{
    public float energyCapacity;
    public float energyConsumption;
    public float energyRegeneration;
}

public class GasolineSystem : EnergySystem
{
    public GasolineSystem()
    {
        energyCapacity = 5f;
        energyConsumption = 3f;
        energyRegeneration = 2f;
    }
}

public class HybridSystem : EnergySystem
{
    public HybridSystem()
    {
        energyCapacity = 6f;
        energyConsumption = 2f;
        energyRegeneration = 4f;
    }
}

public class ElectricSystem : EnergySystem
{
    public ElectricSystem()
    {
        energyCapacity = 7f;
        energyConsumption = 1f;
        energyRegeneration = 5f;
    }
}

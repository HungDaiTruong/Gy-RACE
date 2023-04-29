using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySystemComponentHandler : EnergySystem
{

    public Renderer innerRingObject;
    public Renderer outerRingObject;
    public Renderer engineObject;
    public Renderer paneObject;
    public Renderer podObject;

    private void Start()
    {
        innerRingObject.materials[1].EnableKeyword("_EMISSION");
        outerRingObject.materials[1].EnableKeyword("_EMISSION");
        engineObject.materials[1].EnableKeyword("_EMISSION");
        paneObject.materials[1].EnableKeyword("_EMISSION");
        podObject.materials[1].EnableKeyword("_EMISSION");

        SetEnergySystemMesh(0);
    }

    public void SetEnergySystemMesh(int energySystemType)
    {
        switch (energySystemType)
        {
            case 0:
                innerRingObject.materials[1].SetColor("_EmissionColor", new Color(191, 191, 191) / 100f );
                outerRingObject.materials[1].SetColor("_EmissionColor", new Color(191, 191, 191) / 100f );
                engineObject.materials[1].SetColor("_EmissionColor", new Color(191, 191, 191) / 100f );
                paneObject.materials[1].SetColor("_EmissionColor", new Color(191, 191, 191) / 100f );
                podObject.materials[1].SetColor("_EmissionColor", new Color(191, 191, 191) / 100f );
                energyCapacity = new GyroscopicSystem().energyCapacity;
                durability = new GyroscopicSystem().durability;
                energyRegeneration = new GyroscopicSystem().energyRegeneration;
                break;
            case 1:
                innerRingObject.materials[1].SetColor("_EmissionColor", new Color(191, 191, 0) / 100f );
                outerRingObject.materials[1].SetColor("_EmissionColor", new Color(191, 191, 0) / 100f );
                engineObject.materials[1].SetColor("_EmissionColor", new Color(191, 191, 0) / 100f );
                paneObject.materials[1].SetColor("_EmissionColor", new Color(191, 191, 0) / 100f );
                podObject.materials[1].SetColor("_EmissionColor", new Color(191, 191, 0) / 100f );
                energyCapacity = new MagneticSystem().energyCapacity;
                durability = new MagneticSystem().durability;
                energyRegeneration = new MagneticSystem().energyRegeneration;
                break;
            case 2:
                innerRingObject.materials[1].SetColor("_EmissionColor", new Color(0, 191, 191) / 100f );
                outerRingObject.materials[1].SetColor("_EmissionColor", new Color(0, 191, 191) / 100f );
                engineObject.materials[1].SetColor("_EmissionColor", new Color(0, 191, 191) / 100f );
                paneObject.materials[1].SetColor("_EmissionColor", new Color(0, 191, 191) / 100f );
                podObject.materials[1].SetColor("_EmissionColor", new Color(0, 191, 191) / 100f );
                energyCapacity = new GravitySystem().energyCapacity;
                durability = new GravitySystem().durability;
                energyRegeneration = new GravitySystem().energyRegeneration;
                break;
        }
    }
}

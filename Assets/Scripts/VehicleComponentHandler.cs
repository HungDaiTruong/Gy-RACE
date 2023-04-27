using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleComponentHandler : MonoBehaviour
{
    public WheelComponentHandler wheelComponent;
    public Engine engineComponent;
    public EnergySystem energySystemComponent;

    public void SetWheelType(int option)
    {
        // Update the wheel component based on the selected option
        switch (option)
        {
            case 0:
                wheelComponent.SetWheelMesh(0); // use StandardWheel mesh
                Debug.Log(option);
                break;
            case 1:
                wheelComponent.SetWheelMesh(1); // use OffRoadWheel mesh
                Debug.Log(option);
                break;
            case 2:
                wheelComponent.SetWheelMesh(2); // use SportsWheel mesh
                Debug.Log(option);
                break;
            default:
                Debug.LogError("Invalid wheel option selected: " + option);
                break;
        }
    }

    public void SetEngineType(int option)
    {
        // Update the engine component based on the selected option
        switch (option)
        {
            case 0:
                engineComponent = GetComponentInChildren<StandardEngine>();
                break;
            case 1:
                engineComponent = GetComponentInChildren<TurboEngine>();
                break;
            case 2:
                engineComponent = GetComponentInChildren<ElectricEngine>();
                break;
            default:
                Debug.LogError("Invalid engine type selected: " + option);
                break;
        }
    }

    public void SetEnergySystemType(int option)
    {
        // Update the energy system component based on the selected option
        switch (option)
        {
            case 0:
                energySystemComponent = GetComponentInChildren<GasolineSystem>();
                break;
            case 1:
                energySystemComponent = GetComponentInChildren<HybridSystem>();
                break;
            case 2:
                energySystemComponent = GetComponentInChildren<ElectricSystem>();
                break;
            default:
                Debug.LogError("Invalid energy system type selected: " + option);
                break;
        }
    }
}
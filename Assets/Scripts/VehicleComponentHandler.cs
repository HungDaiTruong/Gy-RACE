using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleComponentHandler : MonoBehaviour
{
    public WheelComponentHandler wheelComponent;
    public EngineComponentHandler engineComponent;
    public EnergySystemComponentHandler energySystemComponent;

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
                engineComponent.SetEngineMesh(0); // use StandardEngine mesh
                Debug.Log(option);
                break;
            case 1:
                engineComponent.SetEngineMesh(1); // use TurboEngine mesh
                Debug.Log(option);
                break;
            case 2:
                engineComponent.SetEngineMesh(2); // use OmniEngine mesh
                Debug.Log(option);
                break;
            default:
                Debug.LogError("Invalid engine option selected: " + option);
                break;
        }
    }

    public void SetEnergySystemType(int option)
    {
        // Update the energy system component based on the selected option
        switch (option)
        {
            case 0:
                energySystemComponent.SetEnergySystemMesh(0); // use Gyroscopic mesh
                Debug.Log(option);
                break;
            case 1:
                energySystemComponent.SetEnergySystemMesh(1); // use Magnetic mesh
                Debug.Log(option);
                break;
            case 2:
                energySystemComponent.SetEnergySystemMesh(2); // use Gravity mesh
                Debug.Log(option);
                break;
            default:
                Debug.LogError("Invalid engine option selected: " + option);
                break;
        }
    }
}
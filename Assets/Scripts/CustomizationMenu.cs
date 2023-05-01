using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomizationMenu : MonoBehaviour
{
    public GameObject vehicle;
    public PlayerLocomotion playerLocomotion;

    public WheelComponentHandler myWheelComponent;
    public EngineComponentHandler myEngineComponent;
    public EnergySystemComponentHandler myEnergySystemComponent;

    public VehicleComponentHandler vehicleHandler;

    public TMP_Dropdown wheelDropdown;
    public TMP_Dropdown engineDropdown;
    public TMP_Dropdown energyDropdown;

    private int selectedWheelOption;
    private int selectedEngineOption;
    private int selectedEnergyOption;

    void Start()
    {
        // Add event listeners to the dropdown menus
        wheelDropdown.onValueChanged.AddListener(OnWheelDropdownChanged);
        engineDropdown.onValueChanged.AddListener(OnEngineDropdownChanged);
        energyDropdown.onValueChanged.AddListener(OnEnergyDropdownChanged);
    }

    // Event listener for the wheel dropdown menu
    void OnWheelDropdownChanged(int option)
    {
        selectedWheelOption = option;
        vehicleHandler.SetWheelType(option);
    }

    // Event listener for the engine dropdown menu
    void OnEngineDropdownChanged(int option)
    {
        selectedEngineOption = option;
        vehicleHandler.SetEngineType(option);
    }

    // Event listener for the energy dropdown menu
    void OnEnergyDropdownChanged(int option)
    {
        selectedEnergyOption = option;
        vehicleHandler.SetEnergySystemType(option);
    }

    public void ApplyCustomization()
    {
        // Get a reference to the vehicle component handler script
        VehicleComponentHandler componentHandler = vehicle.GetComponent<VehicleComponentHandler>();

        // Apply the selected options to the corresponding components
        componentHandler.SetWheelType(selectedWheelOption);
        componentHandler.SetEngineType(selectedEngineOption);
        componentHandler.SetEnergySystemType(selectedEnergyOption);

        playerLocomotion.ApplyStats();
    }

    public void ResetCustomization()
    {
        // Reset the selected options to their default values
        selectedWheelOption = 0;
        selectedEngineOption = 0;
        selectedEnergyOption = 0;

        // Get a reference to the vehicle component handler script
        VehicleComponentHandler componentHandler = vehicle.GetComponent<VehicleComponentHandler>();

        // Reset the vehicle components to their default values
        componentHandler.SetWheelType(selectedWheelOption);
        componentHandler.SetEngineType(selectedEngineOption);
        componentHandler.SetEnergySystemType(selectedEnergyOption);
    }
}

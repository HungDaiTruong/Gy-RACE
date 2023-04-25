using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationMenu : MonoBehaviour
{
    public Dropdown wheelDropdown;
    public Dropdown engineDropdown;
    public Dropdown energyDropdown;

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
    }

    // Event listener for the engine dropdown menu
    void OnEngineDropdownChanged(int option)
    {
        selectedEngineOption = option;
    }

    // Event listener for the energy dropdown menu
    void OnEnergyDropdownChanged(int option)
    {
        selectedEnergyOption = option;
    }

    // Event listener for the apply button
    public void ApplyCustomization()
    {
        // Apply the selected customization to the vehicle
        // TODO: Replace with code that updates the vehicle's components
    }

    // Event listener for the reset button
    public void ResetCustomization()
    {
        // Reset the selected options to their default values
        selectedWheelOption = 0;
        selectedEngineOption = 0;
        selectedEnergyOption = 0;

        // Apply the default customization to the vehicle
        // TODO: Replace with code that updates the vehicle's components
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Image energyImage;

    private PlayerLocomotion playerLocomotion;

    void Start()
    {
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void FixedUpdate()
    {
        UpdateEnergy();
    }

    private void UpdateEnergy()
    {
        // Normalized value between 0 and 1 used to fill the energy bar
        energyImage.fillAmount = Mathf.InverseLerp(0f, playerLocomotion.energyCapacity, playerLocomotion.energy); 
    }
}

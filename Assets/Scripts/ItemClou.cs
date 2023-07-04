using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class ItemClou : MonoBehaviour

{
    public float malusDuration = 5f; // Durée du malus en secondes
    
  
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<shieldManager>().isShieldOn)
        other.gameObject.GetComponent<PlayerLocomotion>().setMalusSlowness(malusDuration);
       
    }

}


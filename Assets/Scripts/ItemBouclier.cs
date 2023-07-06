using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBouclier : MonoBehaviour
{
    public float duration = 15f; // Dur�e de protection en secondes

    private bool isProtectionActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Si le joueur entre en collision avec l'objet de protection, active la protection
            ActivateProtection(other.gameObject);
        }
    }

    private void ActivateProtection(GameObject player)
    {
        if (isProtectionActive)
            return; // Si la protection est d�j� active, ne fait rien

        isProtectionActive = true;

        // D�sactive la collision avec les autres items
        Collider[] colliders = player.GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }

        // R�active la collision apr�s la dur�e sp�cifi�e
        Invoke("DeactivateProtection", duration);
    }

    private void DeactivateProtection()
    {
        isProtectionActive = false;

        // R�active la collision avec les autres items
        Collider[] colliders = transform.parent.GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Item
{
    private float remainingDuration; // Remaining duration of the spikes
    public float slowDuration;

    private void Update()
    {
        if (remainingDuration > 0f)
        {
            remainingDuration -= Time.deltaTime;
            if (remainingDuration <= 0f)
            {
                EndUse();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Player2") || other.CompareTag("AI")) // Check if the collider belongs to the player or AI opponent
        {
            PlayerLocomotion playerLocomotion = other.GetComponent<PlayerLocomotion>();

            if (!playerLocomotion.isShielded)
            {
                StartCoroutine(playerLocomotion.IsSlowed(slowDuration));
            }
            else
            {
                EndUse();
            }
        }
    }

    public override void Use()
    {
        transform.parent = null;
        remainingDuration = duration; // Set the remaining duration to the total duration

        Debug.Log("Using spikes!");
    }

    public override void EndUse()
    {
        Destroy(gameObject);

        Debug.Log("Spikes item ended!");
    }
}

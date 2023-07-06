using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Item
{
    private float remainingDuration; // Remaining duration of the shield

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

    public override void Use()
    {
        PlayerLocomotion playerLocomotion = GetComponentInParent<PlayerLocomotion>();
        playerLocomotion.isShielded = true;

        remainingDuration = duration; // Set the remaining duration to the total duration*

        Debug.Log("Using shield!");
    }

    public override void EndUse()
    {
        PlayerLocomotion playerLocomotion = GetComponentInParent<PlayerLocomotion>();
        playerLocomotion.isShielded = false;

        Destroy(gameObject);

        Debug.Log("Shield ended!");
    }
}


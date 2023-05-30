using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCreator : MonoBehaviour
{
    public TrailRenderer trailRenderer; // Reference to the TrailRenderer component

    private void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
    }

    // Method to create a trail for the game object
    public void CreateTrail(bool enableTrail)
    {
        trailRenderer.enabled = enableTrail;
    }
}
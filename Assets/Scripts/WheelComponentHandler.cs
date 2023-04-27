using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelComponentHandler : Wheel
{
    // References to the MeshFilters for each type of wheel
    public MeshFilter standardWheelMesh;
    public MeshFilter offRoadWheelMesh;
    public MeshFilter sportsWheelMesh;

    MeshFilter currentWheelMesh;

    private void Start()
    {
        currentWheelMesh = GetComponent<MeshFilter>();
        SetWheelMesh(0);
    }

    public void SetWheelMesh(int wheelType)
    {
        switch (wheelType)
        {
            case 0:
                currentWheelMesh.mesh = standardWheelMesh.sharedMesh;
                speed = new StandardWheel().speed;
                acceleration = new StandardWheel().acceleration;
                handling = new StandardWheel().handling;
                break;
            case 1:
                currentWheelMesh.mesh = offRoadWheelMesh.sharedMesh;
                speed = new OffRoadWheel().speed;
                acceleration = new OffRoadWheel().acceleration;
                handling = new OffRoadWheel().handling;
                break;
            case 2:
                currentWheelMesh.mesh = sportsWheelMesh.sharedMesh;
                speed = new SportsWheel().speed;
                acceleration = new SportsWheel().acceleration;
                handling = new SportsWheel().handling;
                break;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelComponentHandler : Wheel
{
    public MeshFilter standardWheelMesh;
    public MeshFilter offRoadWheelMesh;
    public MeshFilter sportsWheelMesh;

    MeshFilter currentWheelMesh;

    private void Start()
    {
        currentWheelMesh = GetComponent<MeshFilter>();
    }

    public void SetWheelMesh(int wheelType)
    {
        switch (wheelType)
        {
            case 0:
                currentWheelMesh.mesh = standardWheelMesh.sharedMesh;
                break;
            case 1:
                currentWheelMesh.mesh = offRoadWheelMesh.sharedMesh;
                break;
            case 2:
                currentWheelMesh.mesh = sportsWheelMesh.sharedMesh;
                break;
        }
    }
}
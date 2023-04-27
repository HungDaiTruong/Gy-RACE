using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineComponentHandler : Engine
{
    // References to the MeshFilters for each type of engine
    public MeshFilter standardEngineMesh;
    public MeshFilter turboEngineMesh;
    public MeshFilter omnidirectionalEngineMesh;

    MeshFilter currentEngineMesh;

    private void Start()
    {
        currentEngineMesh = GetComponent<MeshFilter>();
        SetEngineMesh(0);
    }

    public void SetEngineMesh(int engineType)
    {
        switch (engineType)
        {
            case 0:
                currentEngineMesh.mesh = standardEngineMesh.sharedMesh;
                power = new StandardEngine().power;
                torque = new StandardEngine().torque;
                fuelEfficiency = new StandardEngine().fuelEfficiency;
                break;
            case 1:
                currentEngineMesh.mesh = turboEngineMesh.sharedMesh;
                power = new TurboEngine().power;
                torque = new TurboEngine().torque;
                fuelEfficiency = new TurboEngine().fuelEfficiency;
                break;
            case 2:
                currentEngineMesh.mesh = omnidirectionalEngineMesh.sharedMesh;
                power = new OmnidirectionalEngine().power;
                torque = new OmnidirectionalEngine().torque;
                fuelEfficiency = new OmnidirectionalEngine().fuelEfficiency;
                break;
        }
    }
}

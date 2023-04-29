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
                acceleration = new StandardEngine().acceleration;
                turboSpeed = new StandardEngine().turboSpeed;
                durability = new StandardEngine().durability;
                break;
            case 1:
                currentEngineMesh.mesh = turboEngineMesh.sharedMesh;
                acceleration = new TurboEngine().acceleration;
                turboSpeed = new TurboEngine().turboSpeed;
                durability = new TurboEngine().durability;
                break;
            case 2:
                currentEngineMesh.mesh = omnidirectionalEngineMesh.sharedMesh;
                acceleration = new OmnidirectionalEngine().acceleration;
                turboSpeed = new OmnidirectionalEngine().turboSpeed;
                durability = new OmnidirectionalEngine().durability;
                break;
        }
    }
}

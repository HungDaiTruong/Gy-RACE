using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CheckpointLayer : EditorWindow
{
    private bool canPlaceObject;
    private float setDistance = 0f;

    private GameObject checkpointObject;
    private GameObject itemBoxObject;

    private GameObject objectToSet;

    private string objectLabel = "None";
    [MenuItem("Window/CheckpointLayer")]
    public static void ShowWindow()
    {
        GetWindow<CheckpointLayer>();
    }

    private void OnEnable()
    {
        checkpointObject = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Checkpoint.prefab");
        itemBoxObject = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/ItemBox.prefab");
        SceneView.duringSceneGui += SetObject;
    }

    private void OnDisable()
    {
        SceneView.duringSceneGui -= SetObject;
    }

    private void OnGUI()
    {
        GUILayout.Label("Options", EditorStyles.boldLabel);
        if (GUILayout.Button("Checkpoint"))
        {
            canPlaceObject = true;
            objectToSet = checkpointObject;
            setDistance = 5f;
            objectLabel = "Checkpoint";
        }
        
        if (GUILayout.Button("ItemBox"))
        {
            canPlaceObject = true;
            objectToSet = itemBoxObject;
            setDistance = 2.6f;
            objectLabel = "ItemBox";
        }

        GUILayout.Label($"Current object : {objectLabel}");
    }

    private void SetObject(SceneView sceneView)
    {
        if (!canPlaceObject) return;
        Event currentEvent = Event.current;
        if (currentEvent.type == EventType.MouseDown && currentEvent.button == 0)
        {
            Vector2 mousePosition = currentEvent.mousePosition;
            mousePosition.y = sceneView.camera.pixelHeight - mousePosition.y;
            Ray ray = sceneView.camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 hitPos = hit.point;
                hitPos.y += setDistance;

                Instantiate(objectToSet, hitPos, Quaternion.identity);
            }
        }
    }
}

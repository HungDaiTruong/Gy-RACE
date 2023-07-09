using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CheckpointLayer : EditorWindow
{
    private bool canPlaceObject;

    private GameObject checkpointObject;

    private string objectLabel = "None";
    [MenuItem("Window/CheckpointLayer")]
    public static void ShowWindow()
    {
        GetWindow<CheckpointLayer>();
    }

    private void OnEnable()
    {
        checkpointObject = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Checkpoint.prefab");
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
            objectLabel = "Checkpoint";
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
                hitPos.y += 5f;

                Instantiate(checkpointObject, hitPos, Quaternion.identity);
            }
        }
    }
}

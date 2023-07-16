using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class MethodExecutionTool : EditorWindow
{
    private List<MethodSlot> methodSlots = new List<MethodSlot>();

    [MenuItem("Window/Method Execution Tool")]
    private static void ShowWindow()
    {
        MethodExecutionTool window = GetWindow<MethodExecutionTool>();
        window.titleContent = new GUIContent("Method Execution");
        window.minSize = new Vector2(300, 200);
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("Method Execution Slots", EditorStyles.boldLabel);

        // Display existing slots
        foreach (MethodSlot slot in methodSlots)
        {
            EditorGUILayout.BeginHorizontal();

            // Display script reference field
            slot.script = (MonoBehaviour)EditorGUILayout.ObjectField(slot.script, typeof(MonoBehaviour), true);

            // Display method selection popup
            if (slot.script != null)
            {
                string[] methodNames = GetMethodNames(slot.script);
                slot.selectedMethodIndex = EditorGUILayout.Popup(slot.selectedMethodIndex, methodNames);
            }

            // Execute button
            if (GUILayout.Button("Execute", GUILayout.Width(70)))
            {
                slot.ExecuteSelectedMethod();
            }

            EditorGUILayout.EndHorizontal();
        }

        GUILayout.Space(10);

        // Add new slot button
        if (GUILayout.Button("Add Slot"))
        {
            methodSlots.Add(new MethodSlot());
        }
    }

    private string[] GetMethodNames(MonoBehaviour script)
    {
        Type type = script.GetType();
        List<string> methodNames = new List<string>();

        // Retrieve all methods from the script
        foreach (var method in type.GetMethods())
        {
            // Add public methods with no parameters
            if (method.ReturnType == typeof(void) && method.GetParameters().Length == 0)
            {
                methodNames.Add(method.Name);
            }
        }

        return methodNames.ToArray();
    }

    private class MethodSlot
    {
        public MonoBehaviour script;
        public int selectedMethodIndex;

        public void ExecuteSelectedMethod()
        {
            if (script != null)
            {
                Type type = script.GetType();
                var methods = type.GetMethods();

                if (selectedMethodIndex >= 0 && selectedMethodIndex < methods.Length)
                {
                    var method = methods[selectedMethodIndex];
                    method.Invoke(script, null);
                }
            }
        }
    }
}


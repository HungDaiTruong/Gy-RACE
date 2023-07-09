using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using TMPro;

public class KeybindingManager : MonoBehaviour
{
    [SerializeField] private InputActionReference inputActionReference;
    [SerializeField] private string bindingPath;
    [SerializeField] private TMP_InputField keyInputField;

    private InputAction actionToModify;

    private void Start()
    {
        // Get the InputAction from the InputActionReference
        actionToModify = inputActionReference.action;

        // Set the initial key value in the input field
        keyInputField.text = GetBindingValue(bindingPath);
    }

    private void OnEnable()
    {
        // Subscribe to the value changed event of the input field
        keyInputField.onValueChanged.AddListener(OnInputFieldValueChanged);
    }

    private void OnDisable()
    {
        // Unsubscribe from the value changed event of the input field
        keyInputField.onValueChanged.RemoveListener(OnInputFieldValueChanged);
    }

    private void OnInputFieldValueChanged(string value)
    {
        // Check if a key control is currently pressed
        foreach (KeyControl keyControl in Keyboard.current.allKeys)
        {
            if (keyControl.wasPressedThisFrame)
            {
                // Update the binding property with the new key
                string newKey = keyControl.displayName;
                actionToModify.ApplyBindingOverride(new InputBinding
                {
                    overridePath = bindingPath,
                    overrideInteractions = ""
                });
                keyInputField.text = newKey;

                // Break the loop to prevent multiple key presses from being registered
                break;
            }
        }
    }

    private string GetBindingValue(string path)
    {
        // Get the current binding value based on the path
        var bindings = actionToModify.bindings;
        for (int i = 0; i < bindings.Count; i++)
        {
            if (bindings[i].effectivePath == path)
            {
                return bindings[i].ToDisplayString();
            }
        }

        return "";
    }
}

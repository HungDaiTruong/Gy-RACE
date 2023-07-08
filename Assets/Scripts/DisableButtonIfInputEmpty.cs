using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisableButtonIfInputEmpty : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputField;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        // Disable the button initially if the input field is empty
        button.interactable = IsInputFieldEmpty();

        // Add a listener to the input field's value change event
        inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
    }

    private void OnInputFieldValueChanged(string newValue)
    {
        // Enable or disable the button based on the input field's text
        button.interactable = !IsInputFieldEmpty();
    }

    private bool IsInputFieldEmpty()
    {
        return string.IsNullOrEmpty(inputField.text);
    }
}


using System;
using TMPro;
using UnityEngine;

public class CreateNickname : MonoBehaviour
{
    public static string Value;

    public TMP_InputField NicNameInputField;

    private void OnEnable()
    {
        NicNameInputField.text = Value;
        NicNameInputField.onValueChanged.AddListener(OnChanged);
    }

    private void OnDisable()
    {
        NicNameInputField.onValueChanged.RemoveListener(OnChanged);
    }

    private void OnChanged(string nickname)
    {
        CreateNickname.Value = nickname;
    }
}

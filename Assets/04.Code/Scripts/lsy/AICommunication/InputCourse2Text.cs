using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputCourse2Text : MonoBehaviour
{
    public TMP_InputField EmotionInputField;
    public string EmotionText;
    public Course2TextCommunication _Course2TextCommunication;
    
    public void UpdateEmotionText()
    {
        EmotionText = EmotionInputField.text;
        Debug.Log("InputCourse2Text : " + EmotionText);
        _Course2TextCommunication.StartCommuteCourse2Text();
        
    }
}

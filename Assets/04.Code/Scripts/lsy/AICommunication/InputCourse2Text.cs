using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputCourse2Text : MonoBehaviour
{
    public TMP_InputField EmotionInputField;
    public string EmotionText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateEmotionText()
    {
        EmotionText = EmotionInputField.text;
        Debug.Log("InputCourse2Text : " + EmotionText);
        // FIXME  : AI 통신 코드 추가
        
    }
}

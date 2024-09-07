using TMPro;
using UnityEngine;

public class InputCourse2Text : MonoBehaviour
{
    public TMP_InputField EmotionInputField;
    //public string EmotionText;
    public Course2TextCommunication _Course2TextCommunication;
    public Canvas course2Inputcanvas;

    private CuratorNetwork curatorNetwork;

    private void Start()
    {
        curatorNetwork = FindObjectOfType<CuratorNetwork>();
        
        if (curatorNetwork == null)
        {
            Debug.LogError("InputCourse2Text : curatorNetwork is null");
        }
    }
    
    public void UpdateEmotionText()
    {
        course2Inputcanvas.enabled = false;
        //EmotionText = EmotionInputField.text;
        curatorNetwork.SetCuratorRequestData(EmotionInputField.text);
        Debug.Log("InputCourse2Text : " + curatorNetwork.curatorRequestData.chat);
        _Course2TextCommunication.StartCommuteCourse2Text();
    }
}
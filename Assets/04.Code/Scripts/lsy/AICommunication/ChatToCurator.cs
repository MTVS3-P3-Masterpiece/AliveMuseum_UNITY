using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatToCurator : MonoBehaviour
{
    public TMP_InputField inputField;
    public Text displayField;
    //public string EmotionText;
    //public Course2TextCommunication _Course2TextCommunication;
    //public Canvas chatbotCanvas;

    private CuratorNetwork _curatorNetwork;

    private void Start()
    {
        _curatorNetwork = FindObjectOfType<CuratorNetwork>();
        
        if (_curatorNetwork == null)
        {
            Debug.LogError("InputCourse2Text : curatorNetwork is null");
        }
    }
    
    public void SendChat()
    {
        //curaorCanvas.enabled = false;
        //EmotionText = EmotionInputField.text;
        _curatorNetwork.SetCuratorRequestData(inputField.text);
        Debug.Log("ChatToCurator : InputText - " + _curatorNetwork.curatorRequestData.chat);
        _curatorNetwork.GetCuratorResult(result =>
        {
            Debug.Log("ChatToCurator : Response Text - " + _curatorNetwork.GetResponseText());
            displayField.text = _curatorNetwork.GetResponseText();
        });
    }
}
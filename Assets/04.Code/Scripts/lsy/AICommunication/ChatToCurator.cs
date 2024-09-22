using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatToCurator : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text displayField;
    //public string EmotionText;
    //public Course2TextCommunication _Course2TextCommunication;
    //public Canvas chatbotCanvas;
    public GameObject chatbotCanvas;
    private MoveBoatRaw _moveBoatRaw;

    public CuratorNetwork _curatorNetwork;

    private void Start()
    {
        _curatorNetwork = FindObjectOfType<CuratorNetwork>();
        
        if (_curatorNetwork == null)
        {
            Debug.LogError("InputCourse2Text : curatorNetwork is null");
        }
    }

    public void StartSendChat()
    {
        StartCoroutine(SendChat());
    }
    
    public IEnumerator SendChat()
    {
        chatbotCanvas.SetActive(false);
        //curaorCanvas.enabled = false;
        //EmotionText = EmotionInputField.text;
        _curatorNetwork.SetCuratorRequestData(inputField.text);
        Debug.Log("ChatToCurator : InputText - " + _curatorNetwork.curatorRequestData.chat);
        yield return StartCoroutine(_curatorNetwork.ReqCurator());
        Debug.Log("ChatToCurator : Response Text - " + _curatorNetwork.GetResponseText());
        displayField.text = "감정 키워드 : "+_curatorNetwork.GetResponseText();
        _moveBoatRaw.isComplete = true;
    }
}
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatToCurator_Museum : MonoBehaviour
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

    public void StartSendChat()
    {
        Debug.Log("StartSendChat");
        StartCoroutine(SendChat());
    }
    
    public IEnumerator SendChat()
    {
        _curatorNetwork.SetCuratorRequestData(inputField.text);
        Debug.Log("ChatToCurator : InputText - " + _curatorNetwork.curatorRequestData.chat);
        yield return StartCoroutine(_curatorNetwork.ReqCurator());
        displayField.text = _curatorNetwork.GetResponseText();

    }
}
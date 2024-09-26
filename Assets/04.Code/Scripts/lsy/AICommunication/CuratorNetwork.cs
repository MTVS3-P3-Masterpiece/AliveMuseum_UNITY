using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CuratorNetwork : MonoBehaviour
{
    //private NetworkData networkData;

    public CuratorRequestData curatorRequestData;
    public CuratorResponseData curatorResponseData;

    public TMP_Text reqtext;
    public TMP_Text result;

    public int questionCnt = 0;
    //public string msg;
    
    private void Start()
    {
        //networkData = new NetworkData();
        curatorRequestData = new CuratorRequestData();
        curatorResponseData = new CuratorResponseData();
    }
    
    public void GetCuratorResult()
    {
        StartCoroutine(ReqCurator());
        //return curatorResponseData.chatResult;
    }
    
    public IEnumerator ReqCurator()
    {
        questionCnt += 1;
        SetCuratorRequestData(reqtext.text);
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("chat", curatorRequestData.chat));
        /* for real */
        using UnityWebRequest req = UnityWebRequest.Post(
            NetworkData.baseUrl+NetworkData.curatorAPI, formData);
        /* for test */
        // using UnityWebRequest req = UnityWebRequest.Post(
        //     NetworkData.tempBaseUrl+NetworkData.curatorAPI, formData);
        yield return req.SendWebRequest();
        byte[] bytes = req.downloadHandler.data;
        Debug.Log("C    uratorNetwork : "+ req.downloadHandler.text);
        Debug.Log("CuratorNetowrk : " + bytes);
        string resultText = Encoding.UTF8.GetString(bytes);
        Debug.Log("CuratorNetwork : response - "+ curatorResponseData.chatResult);
        try
        {
            curatorResponseData = JsonConvert.DeserializeObject<CuratorResponseData>(resultText);
            Debug.Log("curatorResponseData : " + curatorResponseData.chatResult);
            result.text = curatorResponseData.chatResult;
        }
        catch (Exception e)
        {
            Debug.Log("Failed to parse response: " + e.Message);
        }
    }

    public void SetCuratorRequestData(string text)
    {
        curatorRequestData.chat = text;
    }

    public string GetResponseText()
    {
        return curatorResponseData.chatResult;
    }
}

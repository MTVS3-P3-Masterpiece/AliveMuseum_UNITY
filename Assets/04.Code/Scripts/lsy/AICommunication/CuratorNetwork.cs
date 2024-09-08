using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class CuratorNetwork : MonoBehaviour
{
    //private NetworkData networkData;

    public CuratorRequestData curatorRequestData;
    public CuratorResponseData curatorResponseData;

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
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("chat", curatorRequestData.chat));
        /* for real */
        using UnityWebRequest req = UnityWebRequest.Post(
            NetworkData.tempBaseUrl+NetworkData.curatorAPI, formData);
        /* for test */
        // using UnityWebRequest req = UnityWebRequest.Post(
        //     NetworkData.tempBaseUrl+NetworkData.curatorAPI, formData);
        yield return req.SendWebRequest();
        byte[] bytes = req.downloadHandler.data;
        Debug.Log("CuratorNetowrk : " + bytes);
        curatorResponseData.chatResult = Encoding.UTF8.GetString(bytes);
        Debug.Log("CuratorNetwork : response - "+ curatorResponseData.chatResult);
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

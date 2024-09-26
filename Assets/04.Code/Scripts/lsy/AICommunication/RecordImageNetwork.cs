using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class RecordImageNetwork : MonoBehaviour
{
    public RecordRequestData recordRequestData;
    public RecordResponseData recordResponseData;
    public Material recordMaterial;
    public TMP_Text recordText;

    public TMP_Text InputUIText;

    public void Start()
    {
        recordRequestData = new RecordRequestData();
        recordText = GameObject.FindGameObjectWithTag("RecordText").GetComponent<TMP_Text>();
    }
    public void StartReqRecordIamge()
    {
        SetRequestText(InputUIText.text);
        StartCoroutine(ReqRecordImage());
    }
    public IEnumerator ReqRecordImage()
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("text", recordRequestData.text));
        using UnityWebRequest req = UnityWebRequest.Post(
            NetworkData.baseUrl+NetworkData.downloadRecordImageAPI, formData);
        req.downloadHandler = new DownloadHandlerTexture();
        yield return req.SendWebRequest();
        if (req.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("RecordImageNetwork : Request is Fail - " + req.result);
            Debug.Log(req.downloadHandler.text);
            Debug.Log(req.GetResponseHeader("Content-Type"));
            Debug.Log(req.responseCode);
            yield break;
        }
        
        var tex = DownloadHandlerTexture.GetContent(req);
        if (string.IsNullOrEmpty(tex.name))
            tex.name = "recording";
        recordMaterial.mainTexture = tex; 
    }

    public void SetRequestText(string txt)
    {
        recordRequestData.text = txt;
        recordText.text = txt;
    }
}

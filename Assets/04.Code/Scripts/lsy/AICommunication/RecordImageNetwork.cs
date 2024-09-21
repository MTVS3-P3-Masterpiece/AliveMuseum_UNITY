using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using DG.Tweening;

public class RecordImageNetwork : MonoBehaviour
{
    public RecordRequestData recordRequestData;
    public RecordResponseData recordResponseData;
    public Image image;
    private void Start()
    {
        recordRequestData = new RecordRequestData();
        recordRequestData.text = "뱃놀이에서 여유로운 분위기를 느낄 수 있었어";
        recordResponseData = new RecordResponseData();
        
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
        var sprite = Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        sprite.name = tex.name;
        image.sprite = sprite;
        image.DOKill();
        image.DOFade(1f, 0.1f);

    }
}

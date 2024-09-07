using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using UnityEngine.Networking;
using UnityEngine;


public class GetImagePathNetwork : MonoBehaviour
{
    private NetworkData networkData;

    public ImageGenResponseData imageGenResponseData;

    private void Start()
    {
        networkData = new NetworkData();
        imageGenResponseData = new ImageGenResponseData();
    }

    public void SendReqImagePath()
    {
        StartCoroutine(ReqImage());
    }
    
    public IEnumerator ReqImage()
    {
        UnityWebRequest req = new UnityWebRequest(networkData.baseUrl+networkData.genImageAPI, "POST");
        req.uploadHandler = new UploadHandlerRaw(new byte[0]); // 빈 배열로 본문 설정
        req.downloadHandler = new DownloadHandlerBuffer();
        // List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        // //formData.Add(new MultipartFormDataSection("chat", "temp"));
        // using UnityWebRequest req =
        //     UnityWebRequest.Post(networkData.baseUrl+networkData.genImageAPI, formData);
        // //https://dbfbaf2f-0fb4-49d2-97f6-68093cfa6bc4.mock.pstmn.io/images
        yield return req.SendWebRequest();
        
        if (req.result != UnityWebRequest.Result.Success)
        { 
            Debug.LogError("Request failed: " + req.error);
            yield break;
        }
        
        byte[] bytes = req.downloadHandler.data;
        string responseBody = Encoding.UTF8.GetString(bytes);
        Debug.Log("responseBody : " + responseBody);
        try
        {
            imageGenResponseData = JsonConvert.DeserializeObject<ImageGenResponseData>(responseBody);
            Debug.Log("imageResponseData : " + imageGenResponseData.generated_images[0]);
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to parse response: " + e.Message);
        }
    }
    
}
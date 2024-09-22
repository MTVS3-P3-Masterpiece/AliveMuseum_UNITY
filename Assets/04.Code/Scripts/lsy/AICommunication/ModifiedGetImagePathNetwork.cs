using System;
using System.Collections;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework.Constraints;
using UnityEngine.Networking;
using UnityEngine;


public class ModifiedGetImagePathNetwork : MonoBehaviour
{
    //private NetworkData networkData;
    //private ModifiedCuratorNetwork _modifiedCuratorNetwork;
    private CuratorNetwork _modifiedCuratorNetwork;
    public ImageGenResponseData imageGenResponseData;
    //public DownloadSample_Texture downloadTexture;
    
    public bool isPathReqComplete = false;
    private void Start()
    {
        imageGenResponseData = new ImageGenResponseData();
        _modifiedCuratorNetwork = FindObjectOfType<CuratorNetwork>();
        StartCoroutine(ObservePathReq());
        //yield return StartCoroutine(ReqImage());
        //yield return StartCoroutine(downloadTexture.UpdateTextureProcess());

    }

    public void SendReqImagePath()
    {
        StartCoroutine(ReqImage());
    }
    
    public IEnumerator ReqImage()
    {
        UnityWebRequest req = new UnityWebRequest(NetworkData.baseUrl+NetworkData.genImageAPI, "POST");
        req.uploadHandler = new UploadHandlerRaw(new byte[0]); // 빈 배열로 본문 설정
        req.downloadHandler = new DownloadHandlerBuffer();
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

    private IEnumerator ObservePathReq()
    {
        yield return new WaitUntil(() => Is2Question());
        yield return new WaitForSeconds(5f);
        yield return StartCoroutine(ReqImage());
        isPathReqComplete = true;
    }

    private bool Is2Question()
    {
        if (_modifiedCuratorNetwork.questionCnt == 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}
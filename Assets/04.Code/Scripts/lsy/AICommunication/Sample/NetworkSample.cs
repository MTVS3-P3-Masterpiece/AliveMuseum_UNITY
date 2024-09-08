using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkSample : MonoBehaviour
{

    IEnumerator Start()
    {
        yield return RequestGetString();
    }
    
    private string url = "https://c062-59-13-225-125.ngrok-free.app/curator";
    private IEnumerator RequestGetString()
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("chat", "HelloWorld"));
        using UnityWebRequest req = UnityWebRequest.Post(url, formData);
        yield return req.SendWebRequest();
        byte[] bytes = req.downloadHandler.data;
        string responseText = Encoding.UTF8.GetString(bytes);
        Debug.Log(responseText);
            
        
    }
} 
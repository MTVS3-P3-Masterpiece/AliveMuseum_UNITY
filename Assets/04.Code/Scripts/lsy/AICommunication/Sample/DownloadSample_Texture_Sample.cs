using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DownloadSample_Texture_Sample : MonoBehaviour
{
    public List<string> paths;

    private Image _image;
    //private TMP_Text _text;

    public GetImagePathNetwork getImagePathNetwork;
    //public NetworkData networkData;
    public int curIndex;
    
    //public string url;
    private int _currentIndex;

    private void Awake()
    {
        _image = GetComponent<Image>();
        //_text = GetComponent<TMP_Text>();
        //networkData = new NetworkData();
    }

    public void StartDownload()
    {
        //StartCoroutine(UpdateTextureProcess(url));
        StartCoroutine(UpdateTextureProcess(NetworkData.baseUrl + NetworkData.downloadImageAPI +
                                            getImagePathNetwork.imageGenResponseData.generated_images[0]));
        StartCoroutine(UpdateTextureProcess(NetworkData.baseUrl + NetworkData.downloadImageAPI +
                                            getImagePathNetwork.imageGenResponseData.generated_images[1]));

    }
    public void Next()
    {
        if (++_currentIndex >= paths.Count)
            _currentIndex = 0;
        StopAllCoroutines();
        StartCoroutine(UpdateTextureProcess(paths[_currentIndex]));
    }

    public void Prev()
    {
        if (--_currentIndex < 0)
            _currentIndex = paths.Count - 1;

        StopAllCoroutines();
        StartCoroutine(UpdateTextureProcess(paths[_currentIndex]));
    }

    // public IEnumerator UpdateTextureProcess(string url, string postData)
    // {
    //     Debug.Log("UpdateTextureProcess");
    //     _image.DOFade(0f, 0.1f);
    //
    //     var p = new Progress<float>(
    //         v =>
    //         {
    //             // if (v < 1f)
    //             //     _text.text = $"<size=68>{url}</size>\n{v * 100f:0}";
    //             // else
    //             //     _text.text = $"size=68{url}</size>";
    //
    //         });
    //
    //     // POST 요청을 통해 이미지를 다운로드하는 메서드 호출
    //     yield return DownloadImageWithPost(url, postData, 
    //         tex =>
    //         {
    //             var sprite = Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
    //             sprite.name = tex.name;
    //             _image.sprite = sprite;
    //             Debug.Log("sprite : " + sprite);
    //         }, p);
    //
    //     _image.DOKill();
    //     _image.DOFade(1f, 0.1f);
    // }
    
    
    public IEnumerator UpdateTextureProcess(string url)
    {
        Debug.Log("UpdateTextureProcess");
        _image.DOFade(0f, 0.1f);

        var p = new Progress<float>(
            v =>
            {
                // if (v < 1f)
                //     _text.text = $"<size=68>{url}</size>\n{v * 100f:0}";
                // else
                //     _text.text = $"size=68{url}</size>";

            });
        yield return DownloadManager_Sample.DownloadTexture(url,
            tex =>
            {
                var sprite = Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
                sprite.name = tex.name;
                _image.sprite = sprite;
                Debug.Log("sprite : "+sprite+" "+ sprite.texture.width+" "+sprite.texture.height);
            }, p);
        _image.DOKill();
        _image.DOFade(1f, 0.1f);
    }
    
    
    // for post
    public IEnumerator DownloadImageWithPost(string url, string postData, Action<Texture2D> onComplete,
        IProgress<float> progress = null)
    {
        using var req = new UnityWebRequest(url, "POST");
        byte[] postDataBytes = System.Text.Encoding.UTF8.GetBytes(postData);
        req.uploadHandler = new UploadHandlerRaw(postDataBytes);
        req.downloadHandler = new DownloadHandlerBuffer();
    
        // Content-Type 설정 (서버에서 요구하는 경우 설정)
        req.SetRequestHeader("Content-Type", "application/json");
    
        if (progress != null)
        {
            var op = req.SendWebRequest();
            while (!op.isDone)
            {
                progress.Report(op.progress);
                yield return null;
            }
            progress.Report(1f);
        }
        else
        {
            yield return req.SendWebRequest();
        }

        if (req.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("DownloadImageWithPost failed: " + req.error);
            yield break;
        }

        var tex = new Texture2D(2, 2);
        tex.LoadImage(req.downloadHandler.data);

        onComplete?.Invoke(tex);
    }

}
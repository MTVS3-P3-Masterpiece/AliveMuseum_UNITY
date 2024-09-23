using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DownloadSample_Texture : MonoBehaviour
{
    public List<Image> images;
    //private TMP_Text _text;

    public ModifiedGetImagePathNetwork _modifiedGetImagePathNetwork;
    //public NetworkData networkData;
    public int curIndex = 0;
    
    //public string url;
    private int _currentIndex;

    public void Start()
    {
        _modifiedGetImagePathNetwork = FindObjectOfType<ModifiedGetImagePathNetwork>();
        if (_modifiedGetImagePathNetwork == null)
        {
            Debug.LogError("DownloadSample_Texture : _modifiedGetImagePathNetwork is null");
        }

        StartDownload();
    }
    private void Awake()
    {
        //_image = GetComponent<Image>();
        //_text = GetComponent<TMP_Text>();
        //networkData = new NetworkData();
    }

    public void StartDownload()
    {
        //StartCoroutine(UpdateTextureProcess(url));
        
        StartCoroutine(UpdateTextureProcess());

    }
    // public void Next()
    // {
    //     if (++_currentIndex >= paths.Count)
    //         _currentIndex = 0;
    //     StopAllCoroutines();
    //     StartCoroutine(UpdateTextureProcess(paths[_currentIndex]));
    // }
    //
    // public void Prev()
    // {
    //     if (--_currentIndex < 0)
    //         _currentIndex = paths.Count - 1;
    //
    //     StopAllCoroutines();
    //     StartCoroutine(UpdateTextureProcess(paths[_currentIndex]));
    // }

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
    
    
    public IEnumerator UpdateTextureProcess()
    {
        Debug.Log("UpdateTextureProcess");
        for (int i = 0; i < 4; i++)
        {
            string url = NetworkData.baseUrl + NetworkData.downloadImageAPI +
                         _modifiedGetImagePathNetwork.imageGenResponseData.generated_images[i];
            images[i].DOFade(1f, 0.1f);

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
                    images[i].sprite = sprite;
                    Debug.Log("sprite : " + sprite);
                }, p);
            images[i].DOKill();
            images[i].DOFade(1f, 0.1f);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DownloadSample_Texture : MonoBehaviour
{
    public List<string> paths;

    private Image _image;
    //private TMP_Text _text;

    private int _currentIndex;

    private void Awake()
    {
        _image = GetComponent<Image>();
        //_text = GetComponent<TMP_Text>();
    }

    public void Start()
    {
        StartCoroutine(UpdateTextureProcess(
            "https://cdn.inflearn.com/public/files/courses/328460/0fae0254-1d55-4bb5-994c-c923a91045a3/328460-1.png"));

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
        yield return DownloadManager.DownloadTexture(url,
            tex =>
            {
                var sprite = Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
                sprite.name = tex.name;
                _image.sprite = sprite;
                Debug.Log("sprite : "+sprite);
            }, p);
        _image.DOKill();
        _image.DOFade(1f, 0.1f);
    }
}
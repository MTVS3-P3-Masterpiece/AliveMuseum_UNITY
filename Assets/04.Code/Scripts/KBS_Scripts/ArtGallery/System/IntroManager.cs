using System;
using System.Collections;
using Fusion;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    private const string MainSceneName = "Beta_Museum";
    
    public GameObject runnerPrefab;
    public TMP_InputField roomNumberInputField;
    public CanvasGroup metaLogoCanvas;
    public Canvas mainCanvas;
    public float fadeDuration = 1f;
    public AudioSource bgmAudioSource;

    private static NetworkRunner Runner;
    public GameObject panel;
    public Image pressAnyKeyImage;


    private void Start()
    {
        StartCoroutine(CanvasGroupController());
    }

    private void Update()
    {
        if (Mathf.Approximately(metaLogoCanvas.alpha , 1))
        {
            if (Input.anyKey)
            {
                panel.gameObject.SetActive(true);
                pressAnyKeyImage.gameObject.SetActive(false);
            }
        }
    }


    private IEnumerator CanvasGroupController()
    {
        float elapsedTime = 0f;

        metaLogoCanvas.alpha = 0;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            metaLogoCanvas.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;  
        }
        
        metaLogoCanvas.alpha = 1;
        StartCoroutine(MainCanvasController());

    }

    private IEnumerator MainCanvasController()
    {
        yield return new WaitForSeconds(2f);
        mainCanvas.gameObject.SetActive(true);
        bgmAudioSource.Play();
        
    }
    

    public void CreateRoom()
    {
        CreatRoom(roomNumberInputField.text);
    }

    private void CreatRoom(string roomName)
    {
        Debug.Log($"CreateRoom : {roomName}");

        if (Runner == null)
        {
            var runnerGo = Instantiate(runnerPrefab);
            Runner = runnerGo.GetComponent<NetworkRunner>();
        }

        Runner.StartGame(new StartGameArgs
            {
                SessionName = roomName,
                GameMode = GameMode.Shared,
                Scene = SceneRef.FromIndex(SceneUtility.GetBuildIndexByScenePath(MainSceneName)),
            });
    }
}

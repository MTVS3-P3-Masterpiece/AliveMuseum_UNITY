using System;
using System.Collections;
using Fusion;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveToMoonScene : NetworkBehaviour
{
    private string sceneName = "Prototype_ArtRoom_Wolhajeongin";
    private Vector3 playerPosition = new Vector3(11.825f, 1.5f, 35f);
    
    public Material mySkyBox;
    public Button introButton;
    public Light directionalLight;
    
   

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ButtonSetActive());
        }
    } 
    
    public void OnEnterClickButton()
    {
        TransitionToNextScene();
        introButton.gameObject.SetActive(false);
    }
    
    public void TransitionToNextScene()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == sceneName)
        {
            RenderSettings.ambientLight = new Color(16f / 255f, 16f / 255f,16f / 255f);
            RenderSettings.skybox = mySkyBox;
            RenderSettings.fog = true;
            RenderSettings.fogColor = Color.gray;
            RenderSettings.fogMode = FogMode.ExponentialSquared;
            RenderSettings.fogDensity = 0.03f;
            directionalLight.colorTemperature = 13726f;
            directionalLight.intensity = 0.2f;
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    IEnumerator ButtonSetActive()
    {
        introButton.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        introButton.gameObject.SetActive(false);
    }
}

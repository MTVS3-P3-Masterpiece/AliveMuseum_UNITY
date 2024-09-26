using System;
using System.Collections;
using Fusion;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveToExScene : NetworkBehaviour
{
    private string sceneName = "Beta_ExperienceRoom_test";
    //public Vector3 playerPosition = new Vector3(52.1f, 1.5f, 40f);
    public Button introButton;
    public GameObject orgDirLight;
    public MoonPosition1 MP1;

    
    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ButtonSetActive());
        }
    }
    

    public void OnEnterClickButton()
    {
        MP1 = FindObjectOfType<MoonPosition1>();
        MP1.TeleportToExScene();
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
            //RenderSettings.ambientLight = new Color(16f / 255f, 16f / 255f,16f / 255f);
            //RenderSettings.skybox = mySkyBox;
            RenderSettings.fog = true;
            //RenderSettings.fogColor = Color.gray;
            RenderSettings.fogMode = FogMode.Exponential;
            //RenderSettings.fogDensity = 0.03f;
            //directionalLight.colorTemperature = 13726f;
            //directionalLight.intensity = 0.2f;
            orgDirLight.SetActive(false);
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

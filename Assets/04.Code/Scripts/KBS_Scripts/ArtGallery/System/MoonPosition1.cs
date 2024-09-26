using System;
using System.Collections;
using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoonPosition1 : NetworkBehaviour
{
    public Vector3 teleportPositionToMoonScene = new Vector3(-14f, 1.5f, -78.95f);
    public Vector3 teleportPositionToWordScene = new Vector3(75f, 0f, 356f);
    public Vector3 teleportPositionToExScene = new Vector3(500f, 500f, 500f);
    public Vector3 teleportPositionInMuseum = new Vector3(4, 1, 4);
    private string MoonsceneName = "Prototype_ArtRoom_Wolhajeongin";
    private string WordSceneName = "3_Hall_Hangle";
    private string ExSceneName = "Beta_ExperienceRoom_test";
    public Material originSkybox;
    public Light directionalLight;
    public GameObject dirLightObject;

    public void Start()
    {
        dirLightObject = GameObject.FindWithTag("OrgDirLight");
    }
    public override void FixedUpdateNetwork()
    {
        if (HasStateAuthority == false)
        {
            return;
        }
        
    }
    
    public void TeleportToMoonScene()
    {
        var characterController = GetComponent<NetworkCharacterController>();
        if (characterController != null)
        {
            characterController.Teleport(teleportPositionToMoonScene, Quaternion.identity);
            
        }
        
    }

    public void TeleportToWordScene()
    {
        var characterController = GetComponent<NetworkCharacterController>();
        if (characterController != null)
        {
            characterController.Teleport(teleportPositionToWordScene, Quaternion.identity);
            
        }
    }

    public void TeleportToExScene()
    {
        var characterController = GetComponent<NetworkCharacterController>();
        if (characterController != null)
        {
            characterController.Teleport(teleportPositionToExScene, Quaternion.identity);

        }
    }

    public void TeleportToMuseumAtMoonScene()
    {
        var characterController = GetComponent<NetworkCharacterController>();
        if (characterController != null)
        {
            characterController.Teleport(teleportPositionInMuseum, Quaternion.identity);
        }
        
        SceneManager.UnloadSceneAsync(MoonsceneName);
            
        RenderSettings.skybox = originSkybox;
        RenderSettings.ambientLight = new Color(61f / 255f, 61f / 255f,61f / 255f);
        RenderSettings.fog = false;
        directionalLight.colorTemperature = 14650;
        directionalLight.intensity = 0.5f;
    }
    
    public void TeleportToMuseumAtWordScene()
    {
        dirLightObject.SetActive(true);
        var characterController = GetComponent<NetworkCharacterController>();
        if (characterController != null)
        {
            characterController.Teleport(teleportPositionInMuseum, Quaternion.identity);
        }
        
        SceneManager.UnloadSceneAsync( WordSceneName);
            
        RenderSettings.skybox = originSkybox;
        RenderSettings.ambientLight = new Color(190f / 255f, 191f / 255f,194f / 255f);
        directionalLight.colorTemperature = 6570f;
        directionalLight.intensity = 1.0f;
    }
    
    public void TeleportToMuseumAtExScene()
    {
        var characterController = GetComponent<NetworkCharacterController>();
        if (characterController != null)
        {
            characterController.Teleport(teleportPositionInMuseum, Quaternion.identity);
        }
        
        SceneManager.UnloadSceneAsync(ExSceneName);
            
        RenderSettings.skybox = originSkybox;
        RenderSettings.ambientLight = new Color(61f / 255f, 61f / 255f,61f / 255f);
        RenderSettings.fog = false;
        dirLightObject.SetActive(true);
        // directionalLight.colorTemperature = 14650;
        // directionalLight.intensity = 0.5f;
    }
    
}

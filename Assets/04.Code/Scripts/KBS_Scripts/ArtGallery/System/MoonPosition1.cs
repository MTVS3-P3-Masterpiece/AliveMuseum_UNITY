using System;
using System.Collections;
using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoonPosition1 : NetworkBehaviour
{
    public Vector3 teleportPositionToMoonScene = new Vector3(-14f, 1.5f, -78.95f);
    public Vector3 teleportPositionToWordScene = new Vector3();
    public Vector3 teleportPositionInMuseum = new Vector3(4, 1, 4);
    private string MoonsceneName = "Prototype_ArtRoom_Wolhajeongin";
    private string WordSceneName = "�ѱ۰�";
    public Material originSkybox;
    public Light directionalLight;

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
            characterController.Teleport(teleportPositionToMoonScene, Quaternion.identity);
            
        }
    }
    

    public void TeleportToMuseum()
    {
        var characterController = GetComponent<NetworkCharacterController>();
        if (characterController != null)
        {
            characterController.Teleport(teleportPositionInMuseum, Quaternion.identity);
        }
        
        SceneManager.UnloadSceneAsync(MoonsceneName);
            
        RenderSettings.skybox = originSkybox;
        RenderSettings.ambientLight = new Color(190f / 255f, 191f / 255f,194f / 255f);
        directionalLight.colorTemperature = 6570f;
        directionalLight.intensity = 1.0f;
    }
}

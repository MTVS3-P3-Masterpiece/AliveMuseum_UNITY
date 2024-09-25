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
    public Vector3 teleportPositionInMuseum = new Vector3(4, 1, 4);
    private string MoonsceneName = "Prototype_ArtRoom_Wolhajeongin";
    private string WordSceneName = "3_Hall_Hangle";
    public Material originSkybox;
    public Light directionalLight;

    public override void FixedUpdateNetwork()
    {
        if (HasStateAuthority == false)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            StartCoroutine(TeleportToMuseum());
            SceneManager.UnloadSceneAsync(MoonsceneName);
            
            RenderSettings.skybox = originSkybox;
            RenderSettings.ambientLight = new Color(190f / 255f, 191f / 255f,194f / 255f);
            directionalLight.colorTemperature = 6570f;
            directionalLight.intensity = 1.0f;
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
    

    private IEnumerator TeleportToMuseum()
    {
        var characterController = GetComponent<NetworkCharacterController>();
        if (characterController != null)
        {
            characterController.Teleport(teleportPositionInMuseum, Quaternion.identity);
        }

        yield return null;
    }
    
}

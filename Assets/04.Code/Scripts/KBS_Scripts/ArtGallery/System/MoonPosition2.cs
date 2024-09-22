using System.Collections;
using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoonPosition2 : NetworkBehaviour
{
    public Vector3 teleportPosition = new Vector3(-55.5f, 1.5f, -95.40f);
    public Vector3 teleportPositionInMuseum = new Vector3(4, 1, 4);
    private string sceneName = "Prototype_ArtRoom_Wolhajeongin";
    public Material originSkybox;


    public override void FixedUpdateNetwork()
    {
        if (HasStateAuthority == false)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(Teleport());
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            StartCoroutine(TeleportToMuseum());
            SceneManager.UnloadSceneAsync(sceneName);
            RenderSettings.skybox = originSkybox;
            RenderSettings.ambientLight = new Color(190f / 255f, 191f / 255f,194f / 255f);
        }
    }
    
    private IEnumerator Teleport()
    {
        var characterController = GetComponent<NetworkCharacterController>();
        if (characterController != null)
        {
            characterController.Teleport(teleportPosition, Quaternion.identity);
        }

        yield return null;
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

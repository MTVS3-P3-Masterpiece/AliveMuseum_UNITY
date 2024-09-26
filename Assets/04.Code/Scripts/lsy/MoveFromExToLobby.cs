using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveFromExToLobby : MonoBehaviour
{
    public Material originSkybox;
    public GameObject directionalLight;
    public GameObject playerObject;
    private MoonPosition1 MP1;
    private string ExSceneName = "Beta_ExperienceRoom_test";
        
    private void Start()
    {
        MP1 = FindObjectOfType<MoonPosition1>();
        directionalLight = GameObject.FindWithTag("OrgDirLight");
    }
    
    public void ClickMoveTolobby()
    {
        directionalLight.SetActive(true);
        MP1.TeleportToMuseumAtExScene();
        
    }
}

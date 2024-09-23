using System;
using Fusion;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class PlayerCollisionUI : NetworkBehaviour
{
    public GameObject MoonEndingScene;
   
    [Networked] private NetworkObject networkObject { get; set; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            MoonEndingScene.gameObject.SetActive(false);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            ShowUI();
        }
    }
    

    private void ShowUI()
    {
        if (networkObject.HasInputAuthority)
        {
            MoonEndingScene.gameObject.SetActive(true);
        }
    }
}

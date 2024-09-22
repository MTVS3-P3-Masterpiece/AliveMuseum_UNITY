using System;
using System.Collections;
using Fusion;
using UnityEngine;
using UnityEngine.UI;

public class MoonPosition1 : NetworkBehaviour
{
    public Vector3 teleportPosition = new Vector3(-14f, 1.5f, -78.95f);
    


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
    
}

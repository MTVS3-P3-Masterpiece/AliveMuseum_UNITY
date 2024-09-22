using System.Collections;
using Fusion;
using UnityEngine;

public class MoonPosition2 : NetworkBehaviour
{
    public Vector3 teleportPosition = new Vector3(-55.5f, 1.5f, -95.40f);
    public Vector3 teleportPositionInMuseum = new Vector3(4, 1, 4);
    


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

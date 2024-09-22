using System.Collections;
using Fusion;
using UnityEngine;

public class MoonPosition2 : NetworkBehaviour
{
    public Vector3 teleportPosition = new Vector3(-55.5f, 1.5f, -95.40f);
    


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

using System;
using Fusion;
using UnityEngine;

public class CamPosition : NetworkBehaviour
{
    public Camera camera;
    
    public override void Spawned()
    {
        if (HasStateAuthority)
        {
            camera = Camera.main;
           // camera.GetComponent<ThirdPersonCamera>().target = transform;
        }
    }
}

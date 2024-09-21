using UnityEngine;

public class BoatStartInteraction : MonoBehaviour, IInteractable
{
    public MoveBoatRaw _moveBoatRaw;

    public Transform targetPos;
    
    public void Interact()
    {
        StartCoroutine(_moveBoatRaw.MoveBoatStraightRaw(targetPos));
    }
}

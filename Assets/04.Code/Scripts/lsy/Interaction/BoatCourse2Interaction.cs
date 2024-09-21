using UnityEngine;

public class BoatCourse2Interaction : MonoBehaviour, IInteractable
{
    private MoveBoatCourse2 _moveBoatCourse2;
    private MoveBoatRaw _moveBoatRaw;

    public Transform targetPos;
    private void Start()
    {
        _moveBoatCourse2 = FindObjectOfType<MoveBoatCourse2>();
        _moveBoatRaw = FindObjectOfType<MoveBoatRaw>();
    }
    public void Interact()
    {
        _moveBoatCourse2.StartCourse();
        StartCoroutine(_moveBoatRaw.MoveBoatStraightRaw(targetPos));
    }
}

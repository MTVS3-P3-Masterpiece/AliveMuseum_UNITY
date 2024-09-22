using System.Collections.Generic;
using UnityEngine;

public class BoatCourse2Interaction : MonoBehaviour, IInteractable
{
    private MoveBoatCourse2 _moveBoatCourse2;
    private MoveBoatRaw _moveBoatRaw;
    private FogController _fogController;
    public List<Transform> list1;
    public List<Transform> list2;
    //public Transform targetPos;
    private void Start()
    {
        _moveBoatCourse2 = FindObjectOfType<MoveBoatCourse2>();
        _moveBoatRaw = FindObjectOfType<MoveBoatRaw>();
        _fogController = FindObjectOfType<FogController>();
    }
    public void Interact()
    {
        //_moveBoatCourse2.StartCourse();
        StartCoroutine(_moveBoatRaw.MoveBoatCurveRaw(list1, list2));
        _fogController.SetCourse2Fog();
        //transform.rotation = Quaternion.Euler(0, 90, 0);
        //StartCoroutine(_moveBoatRaw.MoveBoatStraightRaw(targetPos));
    }
}

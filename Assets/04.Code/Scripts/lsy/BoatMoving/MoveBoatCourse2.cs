using System.Collections.Generic;
using UnityEngine;

public class MoveBoatCourse2 : MonoBehaviour
{
    private MoveBoatRaw _moveBoatRaw;
    public List<Transform> points;
    
    
    void Start()
    {
        _moveBoatRaw = FindObjectOfType<MoveBoatRaw>();
        
    }

    // public void StartCourse()
    // {
    //     StartCoroutine(_moveBoatRaw.MoveBoatCurveRaw(points));
    // }
}

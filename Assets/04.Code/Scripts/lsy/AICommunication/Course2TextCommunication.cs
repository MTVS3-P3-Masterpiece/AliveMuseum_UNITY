using System.Collections;
using UnityEngine;

public class Course2TextCommunication : MonoBehaviour
{
    public MoveBoatCurve _MoveBoatCurve;
    private CuratorNetwork_Sample _curatorNetworkSample;

    private void Start()
    {
        _curatorNetworkSample = FindObjectOfType<CuratorNetwork_Sample>();
    }
    public void StartCommuteCourse2Text()
    {
        StartCoroutine(CommuteCourse2Text());
    }
    IEnumerator CommuteCourse2Text()
    {
        
        //FIXME : 실제 통신으로 변경 필요
        yield return StartCoroutine(_curatorNetworkSample.reqCurator());
        //yield return new WaitForSeconds(3f);
        Debug.Log("Course2TextCommunication : Complete Communication");
        _MoveBoatCurve.isResponseComplete = true;
        yield return null;
    }
}

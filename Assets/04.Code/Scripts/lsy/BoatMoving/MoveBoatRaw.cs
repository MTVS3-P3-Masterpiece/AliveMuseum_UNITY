using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveBoatRaw : MonoBehaviour
{
    private int speed = 4;
    private Vector3 direction;
    private Transform curTarget;
    private Coroutine moveCo;
    private CuratorNetwork _curatorNetwork;

    public GameObject boat;

    public Transform targetPos1;
    public List<Transform> targetPos2;
    public List<Transform> targetPos3;
    
    private Course2TextCommunication _course2TextCommunication;

    public bool isComplete = false;

    public Animator lotusAnim1;
    public Animator lotusAnim2;
    public Animator lotusAnim3;

    public GameObject chatbotPanel;
    
    public IEnumerator Start()
    {
        _course2TextCommunication = FindObjectOfType<Course2TextCommunication>();
        _curatorNetwork = FindObjectOfType<CuratorNetwork>();
        
        yield return StartCoroutine(MoveBoatStraightRaw(targetPos1));
        
        //Course2 
        chatbotPanel.SetActive(true);
        yield return new WaitUntil(() => isComplete);
        //yield return StartCoroutine(_course2TextCommunication.CommuteCourse2Text());
        StartAnim();
        yield return StartCoroutine(MoveBoatCurveRaw(targetPos2, targetPos3));
    }

    public IEnumerator MoveBoatCurveRaw(List<Transform> positions1, List<Transform> positions2)
    {
        // 목표 위치 배열 생성
        Vector3[] waypoints = new Vector3[positions1.Count];
        for (int i = 0; i < positions1.Count; i++)
        {
            waypoints[i] = positions1[i].position;
        }

        // 경로를 따라 이동하며 동시에 회전
        //isBoatMoving = true;
        
        yield return transform.DOPath(waypoints, 30, PathType.CubicBezier)
            .SetEase(Ease.OutQuad)
            .SetLookAt(0.01f)
            .WaitForCompletion();
        waypoints = new Vector3[positions2.Count];
        for (int i = 0; i < positions2.Count; i++)
        {
            waypoints[i] = positions2[i].position;
        }
        yield return transform.DOPath(waypoints, 10, PathType.CubicBezier)
            .SetEase(Ease.OutQuad)
            .SetLookAt(0.01f)
            .WaitForCompletion();
    }

    public IEnumerator MoveBoatStraightRaw(Transform targetPos)
    {
        boat.transform.rotation = Quaternion.Euler(0, 90, 0);
        while (transform.position != targetPos.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos.position, speed * Time.deltaTime);
            yield return null;
        }
    }

    public void StartAnim()
    {
        //if (_curatorNetwork.curatorResponseData.chatResult == "긍정")
        //{
            lotusAnim1.SetBool("Blooming", true);
            lotusAnim2.SetBool("Blooming", true);
            lotusAnim3.SetBool("Blooming", true);
        //}
    }
}
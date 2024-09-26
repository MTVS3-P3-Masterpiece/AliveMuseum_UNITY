using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.VFX;

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

    //public bool isComplete = false;

    public List<Animator> lotusAnims;
    public List<VisualEffect> lotusVFX;
    public List<GameObject> lotusObjects;
    
    

    //public GameObject chatbotPanel;
    public FogController _fogController;
    
    public void Start()
    {
        _course2TextCommunication = FindObjectOfType<Course2TextCommunication>();
        _curatorNetwork = FindObjectOfType<CuratorNetwork>();
    }

    // public IEnumerator Move()
    // {
    //     //yield return StartCoroutine(MoveBoatStraightRaw(targetPos1));
    //     
    //     //Course2
    //     //_fogController.SetCourse2Fog();
    //     //chatbotPanel.SetActive(true);
    //     //yield return new WaitUntil(() => isComplete);
    //     //yield return StartCoroutine(_course2TextCommunication.CommuteCourse2Text());
    //     // 감정 입력 통신 완료 시 실행
    //     //_fogController.SetCourse3_1Fog();
    //     //StartAnim();
    //     //yield return StartCoroutine(MoveBoatCurveRaw(targetPos2, targetPos3));
    // }

    public IEnumerator MoveBoatCurveRaw(List<Transform> positions1, List<Transform> positions2)
    {
        // 목표 위치 배열 생성
        Vector3[] waypoints = new Vector3[positions1.Count + positions2.Count];
        for (int i = 0; i < positions1.Count; i++)
        {
            waypoints[i] = positions1[i].position;
        }
        for (int i = 0; i < positions2.Count; i++)
        {
            waypoints[i + positions1.Count] = positions2[i].position;
        }
        // 경로를 따라 이동하며 동시에 회전
        //isBoatMoving = true;
        
        yield return transform.DOPath(waypoints, 30, PathType.CubicBezier)
            .SetEase(Ease.OutQuad)
            .SetLookAt(0.01f)
            .WaitForCompletion();
        // waypoints = new Vector3[positions2.Count];
        // for (int i = 0; i < positions2.Count; i++)
        // {
        //     waypoints[i] = positions2[i].position;
        // }
        // yield return transform.DOPath(waypoints, 10, PathType.CubicBezier)
        //     .SetEase(Ease.OutQuad)
        //     .SetLookAt(0.01f)
        //     .WaitForCompletion();
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
        int cnt = lotusAnims.Count;
        //if (_curatorNetwork.curatorResponseData.chatResult == "긍정")
        //{
        for (int i = 0; i < cnt; i++)
        {
            ShowPrefabWithScale(lotusObjects[i]);
            lotusAnims[i].SetBool("Blooming", true);
            lotusVFX[i].Play();
        }
        //}
    }

    public void ShowPrefabWithScale(GameObject targetObject)
    {
        Vector3 targetScale = new Vector3(0.1f, 0.1f, 0.1f);
        // 오브젝트 활성화
        targetObject.SetActive(true);
        targetObject.transform.localScale = Vector3.zero;

        // 스케일을 (1, 1, 1)로 서서히 증가시키기 (scaleDuration 동안)
        targetObject.transform.DOScale(targetScale, 3f).SetEase(Ease.OutBack);
    }
}
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Cinemachine;
using Unity.Collections;
using Unity.Mathematics.Geometry;
using UnityEngine;

public class MoveBoatCurve : MonoBehaviour
{

    public List<Transform> targetPositions1 = new List<Transform>();
    public List<Transform> targetPositions2 = new List<Transform>();
    private int speed = 1;
    private Vector3 direction;
    private Transform curTarget;
    IEnumerator Start()
    {
        // curTarget = targetPositions[0];
        // Sequence mySequence = DOTween.Sequence();
        // Sequence mySequence2 = DOTween.Sequence();
        // mySequence
        //     .Append(transform.DOMoveX(targetPositions[0].position.x, 5).SetEase(Ease.OutQuad))
        //     .Join(transform.DOMoveZ(targetPositions[0].position.z, 5).SetEase(Ease.InQuad))
        //     .OnComplete(() =>
        //     {
        //         curTarget = targetPositions[1];
        //         mySequence2
        //             .Append(transform.DOMoveX(targetPositions[1].position.x, 5).SetEase(Ease.InQuad))
        //             .Join(transform.DOMoveZ(targetPositions[1].position.z, 5).SetEase(Ease.OutQuad));
        //     });
        // yield return null;
        
        // 목표 위치 배열 생성
        Vector3[] waypoints = new Vector3[targetPositions1.Count];
        for (int i = 0; i < targetPositions1.Count; i++)
        {
            waypoints[i] = targetPositions1[i].position;
        }

        // 경로를 따라 이동하며 동시에 회전
        transform.DOPath(waypoints, 10, PathType.CubicBezier)
            .SetEase(Ease.OutQuad)
            .SetLookAt(0.01f).OnComplete(() =>
            {
                //FIXME : AI 통신 추가
                for (int i = 0; i < targetPositions2.Count; i++)
                {
                    waypoints[i] = targetPositions2[i].position;
                }

                transform.DOPath(waypoints, 10, PathType.CubicBezier)
                    .SetEase(Ease.OutQuad)
                    .SetLookAt(0.01f);
                // 이동 경로를 따라 자동으로 회전
            });
        yield return null;
    }

    // public void Update()
    // {
    //     direction = curTarget.position - transform.position;
    //
    //     if (direction.magnitude > 0.1f)
    //     {
    //         Quaternion targetRotation = Quaternion.LookRotation(direction);
    //
    //         transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    //     }
    // }
}

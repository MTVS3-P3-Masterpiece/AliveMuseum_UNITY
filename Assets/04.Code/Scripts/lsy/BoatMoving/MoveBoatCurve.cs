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
    private Coroutine moveCo;
    public void StartMoveBoatCourse1()
    {
        moveCo = StartCoroutine(MoveBoatCourse1());
    }
    IEnumerator MoveBoatCourse1()
    {
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
}

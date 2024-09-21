using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();       //생성된 노트를 담는 List 판정범위 모든 노트 비교

    [SerializeField] private Transform Center = null;
    [SerializeField] private RectTransform[] timingRect = null;         // 판정범위(Perfect, Cool, Good, Bad)
    private Vector2[] timingBoxs;                             // 판정범위 최소값(x) 최대값(y)
    private EffectManager theEffect;
    private ScoreManager theScoreManager;
    void Start()
    {
        theEffect = FindObjectOfType<EffectManager>();
        theScoreManager = FindObjectOfType<ScoreManager>();
        
        timingBoxs = new Vector2[timingRect.Length];
        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2,
                Center.localPosition.x + timingRect[i].rect.width / 2);
        }
          
    }

    public void CheckTiming()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosX = boxNoteList[i].transform.localPosition.x;
            for (int x = 0; x < timingBoxs.Length; x++)
            {
                if (timingBoxs[x].x <= t_notePosX && t_notePosX <= timingBoxs[x].y)
                {
                    // 노트 제거
                    //Destroy(boxNoteList[i]);
                    boxNoteList[i].GetComponent<Note>().HideNote();
                    
                    // 이펙트 연출
                    if(x< timingBoxs.Length-1)
                        theEffect.NoteHitEffect();
                    boxNoteList.RemoveAt(i);
                    theEffect.JudgementEffect(x);
                    
                    // 점수 증가
                    theScoreManager.IncreaseScore(x);
                    Debug.Log("Hit" + x);
                    return;
                }
            }
        }
        theEffect.JudgementEffect(timingBoxs.Length);
    }
    
    
}

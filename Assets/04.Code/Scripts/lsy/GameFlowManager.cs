using System.Collections;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    [SerializeField] private DialogSystem dialogSystem01;
    [SerializeField] private DownloadSample_Texture _downloadSampleTexture;
    [SerializeField] private MoveBoatRaw _moveBoatRaw;
    [SerializeField] private FogController _fogController;
    
    public GameObject chatbotPanel;
    
    public bool isComplete = false;
    
    private IEnumerator Start()
    {
        // Intro
        yield return StartCoroutine(RunParallelCoroutine(_downloadSampleTexture.UpdateTextureProcess(),
            dialogSystem01.UpdateDialog()));
        // Course1
        StartCoroutine(_fogController.StartBlending(_fogController.environments[1]));
        StartCoroutine(_downloadSampleTexture._GenImageController1.VfxControl());
        StartCoroutine(_downloadSampleTexture._GenImageController2.VfxControl());
        yield return StartCoroutine(_moveBoatRaw.MoveBoatStraightRaw(_moveBoatRaw.targetPos1));
        chatbotPanel.SetActive(true);
        yield return new WaitUntil(() => isComplete);
        StartCoroutine(_fogController.StartBlending(_fogController.environments[2]));
        _moveBoatRaw.StartAnim();
        yield return StartCoroutine(_moveBoatRaw.MoveBoatCurveRaw(_moveBoatRaw.targetPos2, _moveBoatRaw.targetPos3));

    }

    public IEnumerator RunParallelCoroutine(IEnumerator coroutine1, IEnumerator coroutine2)
    {
        bool coroutine1Finished = false;
        bool coroutine2Finished = false;
        
        StartCoroutine(ExecuteCoroutine(coroutine1, () => coroutine1Finished = true));
        // 코루틴2를 별도로 실행
        StartCoroutine(ExecuteCoroutine(coroutine2, () => coroutine2Finished = true));

        // 두 코루틴이 모두 완료될 때까지 대기
        while (!coroutine1Finished || !coroutine2Finished)
        {
            yield return null; // 한 프레임 대기
        }
    }

    private IEnumerator ExecuteCoroutine(IEnumerator coroutine, System.Action onComplete)
    {
        yield return StartCoroutine(coroutine);
        onComplete?.Invoke();
    }
    
    

}

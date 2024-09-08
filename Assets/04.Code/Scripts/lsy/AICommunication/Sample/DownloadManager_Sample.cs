using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class DownloadManager_Sample
{
    public static IEnumerator DownloadTexture(string url, Action<Texture2D> onComplete,
        IProgress<float> progress = null)
    {
        // IProgress<T> : 진행상황 업데이트용 매개변수
        if (string.IsNullOrEmpty(url))
            throw new ArgumentException(url);
        // 텍스처 데이터를 웹에서 가져옴.
        // 주어진 URL 에서 텍스처 데이터를 가져오고 UnityWebRequest 객체로 반환.
        // using var : 해당 블록이 끝나는 시점에서 자동으로 리소스 해제.
        // 텍스처를 다운로드할 웹 요청 객체 생성
        using var req = UnityWebRequestTexture.GetTexture(url);

        if (progress == null)
        {
            // progress가 존재하지 않으면 그냥 요청 전송
            yield return req.SendWebRequest();
        }
        else
        {
            var op = req.SendWebRequest();
            while (!op.isDone)      //완료되지 않았을 때 계속 반복하는 while문
            {
                progress.Report(op.progress);       //operation이 얼마나 실행되었는지 report 
                yield return null;
            }
            progress.Report(1f);                    // 혹시 모를 완료가 안되었을 경우 보고
        }
        Debug.Log("DownloadTexture : flag");
        if (req.result != UnityWebRequest.Result.Success)       // 비정상적인 결과면 디버깅 출력 후 종료
        { 
            Debug.LogError("DownloadTexture : Request is Fail - "+ req.result);
            Debug.Log(req.downloadHandler.text);
            Debug.Log(req.GetResponseHeader("Content-Type"));
            Debug.Log(req.responseCode);    
            yield break;
        }
        Debug.Log("DownloadTexture : Request is Success - "+ req.result);
        // Debug.Log(req.downloadHandler.text);
        // Debug.Log(req.GetResponseHeader("Content-Type"));
        // Debug.Log(req.responseCode);   
        var tex = DownloadHandlerTexture.GetContent(req);       // 다운된 텍스처를 가져옴
        if (string.IsNullOrEmpty(tex.name))                             // 텍스처 이름 지정
            tex.name = Path.GetFileName(url);
        onComplete?.Invoke(tex);                                        // 콜백으로 텍스처 변수 넘겨줌.
    }
}
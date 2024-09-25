using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Material arrowMaterial;
    public float drawSpeed = 1f;
    public float fadeOutTime = 2f;
    
    private float currentTime = 0f;
    private bool isDrawing = true;
    
    void Update()
    {
        if (isDrawing)
        {
            currentTime += Time.deltaTime * drawSpeed;

            // Tiling Offset을 통해 그려지는 효과 구현
            arrowMaterial.SetFloat("_Offset", Mathf.Lerp(0, 1, currentTime));

            // 그리는 과정이 완료되면 페이드 아웃 시작
            if (currentTime >= 1f)
            {
                isDrawing = false;
                StartCoroutine(FadeOut());
            }
        }
    }

    IEnumerator FadeOut()
    {
        float fadeTime = 0f;
        while (fadeTime < fadeOutTime)
        {
            fadeTime += Time.deltaTime;
            float alphaValue = Mathf.Lerp(1f, 0f, fadeTime / fadeOutTime);
            arrowMaterial.SetFloat("_Alpha", alphaValue);
            yield return null;
        }
    }
}

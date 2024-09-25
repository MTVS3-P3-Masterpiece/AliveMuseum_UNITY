using System.Collections;
using UnityEngine;

public class TransparentController : MonoBehaviour
{
    public Material targetMaterial; 
    public float fadeDuration = 1f;  
    private Color materialColor;

    void Start()
    {
        materialColor = targetMaterial.color;
    }

    public void FadeOut()
    {
        StartCoroutine(FadeTo(0f));
    }

    public void FadeIn()
    {
        StartCoroutine(FadeTo(1f));
    }

    private IEnumerator FadeTo(float targetAlpha)
    {
        float startAlpha = materialColor.a;
        float time = 0;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            materialColor.a = newAlpha;
            targetMaterial.color = materialColor;  
            yield return null;
        }
        
        materialColor.a = targetAlpha;
        targetMaterial.color = materialColor;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) 
        {
            FadeOut();
        }
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            FadeIn();
        }
    }
}
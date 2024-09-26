using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MoonEndingController : MonoBehaviour
{
    public Image endingImage;
    public CanvasGroup outroCanvas;
    public float fadeDuration = 1f;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player");
            if (Input.GetKeyDown(KeyCode.G))
            {
                StartCoroutine(CanvasGroupController());
            }
        }
    }
    
    private IEnumerator CanvasGroupController()
    {
        float elapsedTime = 0f;

        outroCanvas.alpha = 0;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            outroCanvas.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;  
        }
        
        outroCanvas.alpha = 1;
        
    }
    
}

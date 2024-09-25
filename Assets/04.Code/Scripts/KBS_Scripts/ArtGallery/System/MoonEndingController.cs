using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MoonEndingController : MonoBehaviour
{
    public Image endingImage;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player");
            if (Input.GetKeyDown(KeyCode.G))
            {
                endingImage.gameObject.SetActive(true);
            }
        }
    }
    
}

using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MoonEndingController : MonoBehaviour
{
    public Image endingImage;

    private void Update()
    {
        if (Input.GetKeyDown(0))
        {
            endingImage.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                endingImage.gameObject.SetActive(true);
            }
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WrestlingPainting : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}

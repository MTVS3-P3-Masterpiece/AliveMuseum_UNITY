using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToLanguageScene : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("3_Hall_Hangle");
            }
        }
    }
}

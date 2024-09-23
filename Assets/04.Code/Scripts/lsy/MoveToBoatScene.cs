using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveToBoatScene : MonoBehaviour
{
    private string sceneName = "Alpha_ExperienceRoom_test3";
    public Vector3 playerPosition = new Vector3(11.825f, 1.5f, 35f);
    public Image introImage;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter");
            introImage.gameObject.SetActive(true);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        Debug.Log("stay");
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TransitionToNextScene();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("asdfg");
        if (other.gameObject.CompareTag("Player"))
        {
            introImage.gameObject.SetActive(false);
        }
    }

    public void TransitionToNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

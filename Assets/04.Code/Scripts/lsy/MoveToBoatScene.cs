using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToBoatScene : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("BoatScene_Sample");
            }
        }
    }
}

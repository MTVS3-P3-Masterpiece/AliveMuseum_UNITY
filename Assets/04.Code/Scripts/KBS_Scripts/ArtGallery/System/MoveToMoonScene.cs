using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToMoonScene : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Prototype_ArtRoom_Wolhajeongin");
            }
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class TempSceneManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("Prototype_ArtRoom_Wolhajeongin");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("3_Hall_Hangle");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("Alpha_ExperienceRoom_test3");
        }
    }
}

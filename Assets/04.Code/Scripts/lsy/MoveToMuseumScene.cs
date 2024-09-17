using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToMuseumScene : MonoBehaviour
{
    public void Update(){
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            SceneManager.LoadScene("2.MuseumScene");
        }
    }
}

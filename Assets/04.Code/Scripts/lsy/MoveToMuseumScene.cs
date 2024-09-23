using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToMuseumScene : MonoBehaviour
{
    public void MoveToMuseum(){
        SceneManager.LoadScene("Alpha_Museum");
    }
    
}

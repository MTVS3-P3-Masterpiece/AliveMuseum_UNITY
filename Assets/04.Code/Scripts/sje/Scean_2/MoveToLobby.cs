using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToLobby : MonoBehaviour
{
    public string sceneToLoad = "j_lobby";   
    private bool playerInRange = false;       

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  
        {
            playerInRange = true;     
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            playerInRange = false;    
        }
    }

    void Update()
    {
        
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(sceneToLoad);  // 지정된 씬으로 전환
        }
        
        
        
    }
    
}

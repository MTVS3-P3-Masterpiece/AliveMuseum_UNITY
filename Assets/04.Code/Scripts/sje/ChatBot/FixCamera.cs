using UnityEngine;

public class FixCamera : MonoBehaviour
{
    public Transform player;      
    private bool isFrozen = false;  

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

      
        if (distance < 5.0f) 
        {
            if (Input.GetKeyDown(KeyCode.E) && !isFrozen)
            {
                FreezePlayer();
            }
            else if (Input.GetKeyDown(KeyCode.X) && isFrozen)
            {
                UnfreezePlayer();
            }
        }
    }

    void FreezePlayer()
    {
        isFrozen = true;
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;                   
        Time.timeScale = 0f;              
    }

    void UnfreezePlayer()
    {
        isFrozen = false;
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;                   
        Time.timeScale = 1f;                     
    }
}

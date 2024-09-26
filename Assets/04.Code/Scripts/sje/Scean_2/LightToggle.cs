using UnityEngine;

public class LightToggle : MonoBehaviour
{
    public Light[] lightsToTurnOn;    
    public Light[] lightsToTurnOff;   
    public float interactionDistance = 3.0f;  
    public KeyCode interactionKey = KeyCode.E;  

    public GameObject player; 

    void Start()
    {
         
        if (player == null)
        {
            Debug.LogError("Player not assigned! Please assign the Player GameObject in the Inspector.");
        }
        else
        {
            Debug.Log("Player assigned!");
        }
    }

    void Update()
    {
        if (player != null)  
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);

           
            if (distance <= interactionDistance && Input.GetKeyDown(interactionKey))
            {
                ToggleLights();  
            }
        }
    }

    private void ToggleLights()
    {
      
        foreach (Light light in lightsToTurnOn)
        {
            light.enabled = true;
        }

     
        foreach (Light light in lightsToTurnOff)
        {
            light.enabled = false;
        }
    }
}
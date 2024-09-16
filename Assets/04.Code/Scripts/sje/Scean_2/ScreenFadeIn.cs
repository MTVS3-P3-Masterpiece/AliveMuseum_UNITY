

using UnityEngine;

public class ScreenFadeIn : MonoBehaviour
{
    public GameObject firstObject;  
    public GameObject secondObject;  
    public float interactionDistance = 3.0f;  
    public KeyCode interactionKey = KeyCode.E;  

    private bool isSecondObjectVisible = false;  

    void Start()
    {
        
        if (secondObject != null)
        {
            secondObject.SetActive(false);
        }
    }

    void Update()
    {
        if (firstObject != null && secondObject != null)
        {
 
            float distance = Vector3.Distance(transform.position, firstObject.transform.position);
            
            if (distance <= interactionDistance && Input.GetKeyDown(interactionKey))
            {
                if (!isSecondObjectVisible)
                {
                    secondObject.SetActive(true);
                    isSecondObjectVisible = true;
                }
            }
        }
    }
}




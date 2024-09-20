using UnityEngine;

public class DoorFadeOutByTransparency : MonoBehaviour
{
    public GameObject firstObject;   
    public GameObject[] targetObjects;  
    public float duration = 2f;       

    private Vector3[] initialScale;
    private float timeElapsed;

    private bool isFading = false;
    public float interactionDistance = 3.0f;  
    public KeyCode interactionKey = KeyCode.E;  

    void Start()
    {
        initialScale = new Vector3[targetObjects.Length];
        for (int i = 0; i < targetObjects.Length; i++)
        {
            initialScale[i] = targetObjects[i].transform.localScale;
        }
    }

    void Update()
    {
        if (firstObject != null && targetObjects != null && !isFading)
        {
             
            float distance = Vector3.Distance(transform.position, firstObject.transform.position);

            
            if (distance <= interactionDistance && Input.GetKeyDown(interactionKey))
            {
               
                isFading = true;
                timeElapsed = 0f; 
            }
        }

        if (isFading && timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            float scaleValue = Mathf.Lerp(1f, 0f, timeElapsed / duration);

          
            for (int i = 0; i < targetObjects.Length; i++)
            {
                targetObjects[i].transform.localScale = initialScale[i] * scaleValue;
            }

            
            if (timeElapsed >= duration)
            {
                foreach (GameObject obj in targetObjects)
                {
                    obj.SetActive(false);
                }
                isFading = false;  
            }
        }
    }
}
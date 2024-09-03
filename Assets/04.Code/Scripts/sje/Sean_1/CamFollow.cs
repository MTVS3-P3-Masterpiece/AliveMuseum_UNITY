using UnityEngine;

public class CamFollow : MonoBehaviour
{
    
    public Transform target;
    void Start()
    {
        
    }
    void Update()
    {
        transform.position = target.position;
    }
}








































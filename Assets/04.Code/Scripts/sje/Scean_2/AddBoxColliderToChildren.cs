using UnityEngine;

public class AddBoxColliderToChildren : MonoBehaviour
{
    void Start()
    {
       
        foreach (Transform child in transform)
        {
            if (child.gameObject.GetComponent<BoxCollider>() == null)
            {
                child.gameObject.AddComponent<BoxCollider>();
            }
        }
    }
}
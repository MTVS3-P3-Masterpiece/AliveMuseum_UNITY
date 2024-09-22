using UnityEngine;

public class AddBoxColliderToChildren : MonoBehaviour
{
    void Start()
    {
        foreach (Transform child in transform)
        {
            Vector3 localScale = child.localScale;


            if (localScale.x < 0 || localScale.y < 0 || localScale.z < 0)
            {
                localScale.x = Mathf.Abs(localScale.x);
                localScale.y = Mathf.Abs(localScale.y);
                localScale.z = Mathf.Abs(localScale.z);
                
                child.localScale = localScale;
            }


            if (child.gameObject.GetComponent<BoxCollider>() == null)
            {
                BoxCollider boxCollider = child.gameObject.AddComponent<BoxCollider>();
                
                Vector3 colliderSize = boxCollider.size;
                colliderSize.x = Mathf.Abs(colliderSize.x);
                colliderSize.y = Mathf.Abs(colliderSize.y);
                colliderSize.z = Mathf.Abs(colliderSize.z);
                boxCollider.size = colliderSize;
            }
        }
    }
}
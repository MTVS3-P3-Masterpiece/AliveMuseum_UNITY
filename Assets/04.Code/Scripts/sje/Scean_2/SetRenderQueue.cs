using UnityEngine;

public class SetRenderQueue : MonoBehaviour
{
    public Material decalMaterial;  

    void Start()
    {
        if (decalMaterial != null)
        {
            decalMaterial.renderQueue = 3100;  
        }
    }
}
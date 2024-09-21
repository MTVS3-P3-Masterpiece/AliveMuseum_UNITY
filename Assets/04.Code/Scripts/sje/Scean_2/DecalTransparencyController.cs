using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DecalTransparencyController : MonoBehaviour
{
    public DecalProjector decalProjector;  
    public float transparency = 0.5f;  

    private Material decalMaterial;

    void Start()
    {
        if (decalProjector == null)
        {
            Debug.LogError("Decal Projector is not assigned!");
            return;
        }
        
        decalMaterial = decalProjector.material;
        if (decalMaterial == null)
        {
            Debug.LogError("Decal Projector does not have a material assigned!");
            return;
        }
        
        UpdateDecalTransparency();
    }

    void UpdateDecalTransparency()
    {
        if (decalMaterial == null)
            return;

        
        Color color = decalMaterial.color;
        color.a = transparency;
        decalMaterial.color = color;

      
        decalMaterial.renderQueue = 3000; 
    }
}
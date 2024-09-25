using UnityEngine;

public class SetTransparency : MonoBehaviour
{
    public Material targetMaterial; 
    [Range(0f, 1f)] public float targetAlpha = 0.2f; 

    void Start()
    {
        Color materialColor = targetMaterial.color;
        
        materialColor.a = targetAlpha;
        
        targetMaterial.color = materialColor;
    }
}
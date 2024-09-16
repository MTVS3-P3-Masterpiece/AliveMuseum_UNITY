using System.Collections;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject firstObject;   
   
    public GameObject secondParentObject;  
    public float interactionDistance = 3.0f;  
    public KeyCode interactionKey = KeyCode.E;  
    public float fadeDuration = 5.0f; 
 
    private Material[] materials;
    private bool isFading = false;
    
    
    void Start()
    {
       
        Renderer[] renderers = secondParentObject.GetComponentsInChildren<Renderer>();
        materials = new Material[renderers.Length];

        for (int i = 0; i < renderers.Length; i++)
        {
            materials[i] = renderers[i].material;
            
            materials[i].SetFloat("_Mode", 2);
            materials[i].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            materials[i].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            materials[i].SetInt("_ZWrite", 0);
            materials[i].DisableKeyword("_ALPHATEST_ON");
            materials[i].EnableKeyword("_ALPHABLEND_ON");
            materials[i].DisableKeyword("_ALPHAPREMULTIPLY_ON");
            materials[i].renderQueue = 3000;
        }
        
    }

    void Update()
    {
        if (firstObject != null && secondParentObject != null && !isFading)
        {
           
            float distance = Vector3.Distance(transform.position, firstObject.transform.position);

           
            if (distance <= interactionDistance && Input.GetKeyDown(interactionKey))
            {
                StartCoroutine(FadeOutCoroutine());
            }
        }
    }

 
       
    
    private void SetMaterialToTransparent(Material mat)
    {
        mat.SetFloat("_Surface", 1);  
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.SetInt("_ZWrite", 0);
        mat.DisableKeyword("_ALPHATEST_ON");
        mat.EnableKeyword("_ALPHABLEND_ON");
        mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.renderQueue = 3000;  
    }

    private IEnumerator FadeOutCoroutine()
    {
        isFading = true;
        float elapsedTime = 0f;
        foreach (Material mat in materials)
        {
            SetMaterialToTransparent(mat);  
        }

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            foreach (Material mat in materials)
            {
                Color color = mat.color;
                mat.color = new Color(color.r, color.g, color.b, alpha);
            }
            yield return null;
        }
        secondParentObject.SetActive(false);
        
    }
}









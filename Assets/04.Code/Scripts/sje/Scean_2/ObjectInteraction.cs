// using System.Collections;
// using UnityEngine;
//
// public class ObjectInteraction : MonoBehaviour
// {
//     public GameObject firstObject;   
//    
//     public GameObject secondParentObject;  
//     public float interactionDistance = 3.0f;  
//     public KeyCode interactionKey = KeyCode.E;  
//     public float fadeDuration = 5.0f; 
//  
//     private Material[] materials;
//     private bool isFading = false;
//     
//     
//     void Start()
//     {
//        
//         Renderer[] renderers = secondParentObject.GetComponentsInChildren<Renderer>();
//         materials = new Material[renderers.Length];
//
//         for (int i = 0; i < renderers.Length; i++)
//         {
//             materials[i] = renderers[i].material;
//             
//             materials[i].SetFloat("_Mode", 2);
//             materials[i].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
//             materials[i].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
//             materials[i].SetInt("_ZWrite", 0);
//             materials[i].DisableKeyword("_ALPHATEST_ON");
//             materials[i].EnableKeyword("_ALPHABLEND_ON");
//             materials[i].DisableKeyword("_ALPHAPREMULTIPLY_ON");
//             materials[i].renderQueue = 2000;
//         }
//         
//     }
//
//     void Update()
//     {
//         if (firstObject != null && secondParentObject != null && !isFading)
//         {
//            
//             float distance = Vector3.Distance(transform.position, firstObject.transform.position);
//
//            
//             if (distance <= interactionDistance && Input.GetKeyDown(interactionKey))
//             {
//                 StartCoroutine(FadeOutCoroutine());
//             }
//         }
//     }
//
//  
//        
//     
//     private void SetMaterialToTransparent(Material mat)
//     {
//         mat.SetFloat("_Surface", 1);  
//         mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
//         mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
//         mat.SetInt("_ZWrite", 0);
//         mat.DisableKeyword("_ALPHATEST_ON");
//         mat.EnableKeyword("_ALPHABLEND_ON");
//         mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
//         mat.renderQueue = 3000;  
//     }
//
//     private IEnumerator FadeOutCoroutine()
//     {
//         isFading = true;
//         float elapsedTime = 0f;
//         foreach (Material mat in materials)
//         {
//             SetMaterialToTransparent(mat);  
//         }
//
//         while (elapsedTime < fadeDuration)
//         {
//             elapsedTime += Time.deltaTime;
//             
//             float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
//             foreach (Material mat in materials)
//             {
//                 Color color = mat.color;
//                 mat.color = new Color(color.r, color.g, color.b, alpha);
//             }
//             yield return null;
//         }
//         secondParentObject.SetActive(false);
//         
//     }
// }
//
//
//
//
//
//
//
//










using System.Collections;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject secondParentObject;  
    public float interactionDistance = 3.0f;  
    public KeyCode interactionKey = KeyCode.E;  
    public float fadeDuration = 5.0f; 

    private GameObject player;  // 플레이어 오브젝트를 태그로 찾기 위한 변수
    private Material[] materials;
    private bool isFading = false;

    void Start()
    {
        // 플레이어 오브젝트를 태그로 찾기
        player = GameObject.FindWithTag("Player");

        // secondParentObject의 자식 렌더러들을 찾아서 머티리얼 설정
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
            materials[i].renderQueue = 2000;
        }
    }

    void Update()
    {
        // 태그로 플레이어를 찾고 나서 동작
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        if (player != null && secondParentObject != null && !isFading)
        {
            // firstObject(자기 자신)의 위치와 플레이어의 거리를 계산
            float distance = Vector3.Distance(transform.position, player.transform.position);

            // 상호작용 거리 내에 플레이어가 있고, 상호작용 키를 눌렀을 때
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
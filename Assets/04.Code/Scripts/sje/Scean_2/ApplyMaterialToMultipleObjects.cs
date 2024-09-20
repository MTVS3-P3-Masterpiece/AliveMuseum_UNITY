using UnityEngine;

public class ApplyMaterialToMultipleObjects : MonoBehaviour
{
    public Material materialToApply; // 적용할 머티리얼
    public GameObject[] objectsToApply; // 머티리얼을 적용할 오브젝트들

    void Start()
    {
        foreach (GameObject obj in objectsToApply)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = materialToApply;
            }
        }
    }
}
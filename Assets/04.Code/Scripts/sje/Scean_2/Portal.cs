using UnityEngine;
using UnityEngine.SceneManagement;  // 씬 이동을 위해 필요한 네임스페이스

public class PortalScript : MonoBehaviour
{
    // 포털에 닿으면 새로운 씬으로 이동
    private void OnTriggerEnter(Collider other)
    {
        // "Player"라는 태그를 가진 오브젝트가 포털에 닿으면
        if (other.CompareTag("Player"))
        {
            // 씬2로 이동
            SceneManager.LoadScene("4_Mapping");
        }
    }
}
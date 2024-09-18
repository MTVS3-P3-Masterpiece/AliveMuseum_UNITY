using UnityEngine;
using UnityEngine.SceneManagement;   

public class PortalScript : MonoBehaviour
{
 
    private void OnTriggerEnter(Collider other)
    {
        // "Player"라는 태그를 가진 오브젝트가 포털에 닿으면
        if (other.CompareTag("Player"))
        {
            // 씬2로 이동
            //SceneManager.LoadScene("4_Mapping");
        }
    }
}
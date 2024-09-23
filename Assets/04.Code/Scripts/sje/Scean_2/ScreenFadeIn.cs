//
//
// using UnityEngine;
//
// public class ScreenFadeIn : MonoBehaviour
// {
//     public GameObject firstObject;  
//     public GameObject secondObject;  
//     public float interactionDistance = 3.0f;  
//     public KeyCode interactionKey = KeyCode.E;  
//
//     private bool isSecondObjectVisible = false;  
//
//     void Start()
//     {
//         
//         if (secondObject != null)
//         {
//             secondObject.SetActive(false);
//         }
//     }
//
//     void Update()
//     {
//         if (firstObject != null && secondObject != null)
//         {
//  
//             float distance = Vector3.Distance(transform.position, firstObject.transform.position);
//             
//             if (distance <= interactionDistance && Input.GetKeyDown(interactionKey))
//             {
//                 if (!isSecondObjectVisible)
//                 {
//                     secondObject.SetActive(true);
//                     isSecondObjectVisible = true;
//                 }
//             }
//         }
//     }
// }
//










using UnityEngine;

public class ScreenFadeIn : MonoBehaviour
{
    public GameObject secondObject;  
    public float interactionDistance = 3.0f;  
    public KeyCode interactionKey = KeyCode.E;  

    private GameObject player;  // 플레이어를 태그로 찾아서 할당
    private bool isSecondObjectVisible = false;  

    void Start()
    {
        // 플레이어 오브젝트를 태그로 찾기
        player = GameObject.FindWithTag("Player");

        if (secondObject != null)
        {
            secondObject.SetActive(false);  // secondObject를 비활성화
        }
    }

    void Update()
    {
        // 태그로 플레이어를 찾고 나서 동작
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        if (player != null && secondObject != null)
        {
            // firstObject(자기 자신)와 플레이어 간 거리 계산
            float distance = Vector3.Distance(transform.position, player.transform.position);

            // 플레이어가 상호작용 거리 내에 있고 상호작용 키를 눌렀을 때
            if (distance <= interactionDistance && Input.GetKeyDown(interactionKey))
            {
                if (!isSecondObjectVisible)
                {
                    secondObject.SetActive(true);  // secondObject 활성화
                    isSecondObjectVisible = true;
                }
            }
        }
    }
}







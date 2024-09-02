using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;


// 안내원 말할 때 애니메이션 구현
// SimpleCharacterController 
public class ChatBotAct : MonoBehaviour
{
    
    public GameObject viewPos;
    public GameObject interaction;
    public GameObject ChatText;
    bool enterOk = false;
    bool chatOpen = false;
    private bool followPlayer = false;  
    private bool isChatBotVisible = true; 

    PlayerMove playerScript;
    GameObject player;  
    CamRotate camRotate;
    
    private NavMeshAgent agent;  


    [SerializeField]

    IEnumerator CheckAndWarp()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); 
        
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer > 10f)  
            {
                agent.Warp(player.transform.position);
            }
        }
    }
 
    void Start()
    {
     
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 15f;
        agent.acceleration = 10f; 
        agent.stoppingDistance = 5f; 

        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerMove>();
        camRotate = Camera.main.GetComponent<CamRotate>();
    }


    void Update()
    {
        if (enterOk == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ChatText.SetActive(true);
                playerScript.enabled = false;
                chatOpen = true;
                followPlayer = true;  
            }
        }

        if (followPlayer && player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer > 20f)
            {
                agent.Warp(player.transform.position);
            }
            else
            {
                agent.SetDestination(player.transform.position);
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            ChatText.SetActive(false);
            playerScript.enabled = true;
            chatOpen = false;
        }
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interaction.SetActive(true);
            enterOk = true;
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        ChatText.SetActive(false);
        
        if (other.gameObject.CompareTag("Player"))
        {
            interaction.SetActive(false);
            enterOk = false;
        }
    }
}
















































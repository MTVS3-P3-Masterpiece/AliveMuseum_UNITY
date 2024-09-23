using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UIElements;


// SimpleCharacterController 
public class ChatBotAct : MonoBehaviour
{
    
    //public GameObject viewPos;
    public GameObject interaction;
    public GameObject ChatText;
    bool enterOk = false;
    bool chatOpen = false;
    private bool followPlayer = false;  
    private bool isChatBotVisible = true;
    public Text textChat;

    PlayerManager playerScript;
    GameObject player;  
    FirstPersonCamera camRotate;
    [SerializeField]
    private CuratorNetwork _curatorNetwork;
    
    //private NavMeshAgent agent;  


    // [SerializeField]
    // private float smoothTime = 0.3f; 
    // private Vector3 velocity = Vector3.zero;  
    //
    // IEnumerator CheckAndWarp()
    // {
    //     while (true)
    //     {
    //         yield return new WaitForSeconds(1f); 
    //     
    //         float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
    //         if (distanceToPlayer > 10f)  
    //         {
    //             agent.Warp(player.transform.position);
    //         }
    //     }
    // }
 
    void Start()
    {
     
        // agent = GetComponent<NavMeshAgent>();
        // agent.speed = 10f;  
        // agent.acceleration = 15f;  
        // agent.angularSpeed = 120f;  
        // agent.stoppingDistance = 3f;  
        
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerManager>();
      //  camRotate = Camera.main.GetComponent<CamRotate>();
      //_curatorNetwork = FindObjectOfType<CuratorNetwork>();
    }


    void Update()
    {
        if (enterOk == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ChatText.SetActive(true);
                //playerScript.enabled = false;
                chatOpen = true;
                followPlayer = true;  
                interaction.SetActive(false);
                //camRotate.enabled = false;
            }
        }

        // if (followPlayer && player != null)
        // {
        //     float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        //     if (distanceToPlayer > agent.stoppingDistance) 
        //     {
        //         Vector3 targetPosition = player.transform.position;  
        //         Vector3 newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        //         transform.position = newPosition; 
        //     }
        //     else
        //     {
        //         agent.ResetPath(); 
        //     }
        // }

        if (Input.GetKeyDown(KeyCode.X))
        {
            ChatText.SetActive(false);
            //playerScript.enabled = true;
            chatOpen = false;
            camRotate.enabled = true;
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

    public void PressEnter()
    {
        StartCoroutine(EnterCoroutine());
    }

    public IEnumerator EnterCoroutine()
    {
        yield return StartCoroutine(_curatorNetwork.ReqCurator());
        textChat.text = _curatorNetwork.GetResponseText();
    }

    public void PressCancel()
    {
        ChatText.SetActive(false);
        playerScript.enabled = true;
        chatOpen = false;
        camRotate.enabled = true;
    }
}



using System.Collections;
using UnityEngine;

public class TalkingToChange : MonoBehaviour
{
       public GameObject viewPos;
    public GameObject interaction;
    public GameObject ChatText;
    bool enterOk = false;
    bool chatOpen = false;
    private bool followPlayer = false;  
    private bool isChatBotVisible = true; 

    //PlayerMove playerScript;
    GameObject player;  
    CamRotate camRotate;
    


    [SerializeField]
    private float smoothTime = 0.3f; 
    private Vector3 velocity = Vector3.zero;  

    IEnumerator CheckAndWarp()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); 
        
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        }
    }
 
    void Start()
    {
     
 
        
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        
        player = GameObject.Find("Player");
        //playerScript = player.GetComponent<PlayerMove>();
        camRotate = Camera.main.GetComponent<CamRotate>();
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

            }
        }

        if (followPlayer && player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        }

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
}



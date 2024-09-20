using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToLanguageScene : MonoBehaviour
{

    PlayerMove playerScript;
    GameObject player;
    CamRotate camRotate;

    bool enterOk = false;
    bool chatOpen = false;
   //public GameObject interaction;
    public GameObject ChatText;




    private void Start()
    {
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
          
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ChatText.SetActive(true);
                playerScript.enabled = false;
                chatOpen = true;
                //followPlayer = true;  
                //interaction.SetActive(false);
                camRotate.enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            ChatText.SetActive(false);
            playerScript.enabled = true;
            chatOpen = false;
            camRotate.enabled = true;
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enterOk = true;
        }


    }
    
    void OnTriggerExit(Collider other)
    {
        ChatText.SetActive(false);
        
        if (other.gameObject.CompareTag("Player"))
        {
          
            enterOk = false;
        }
    }

}



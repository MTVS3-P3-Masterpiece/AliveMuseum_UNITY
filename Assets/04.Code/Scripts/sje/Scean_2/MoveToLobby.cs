using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveToLobby : MonoBehaviour
{
    
    public Canvas OutroCanvas;
    private MoonPosition1 MP1;


    private void Start()
    {
        MP1 = FindObjectOfType<MoonPosition1>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))  
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                OutroCanvas.gameObject.SetActive(true);
            }
        }
    }

    public void EndingBittonOnClickInWordScene()
    {
        MP1.TeleportToMuseumAtWordScene();
        OutroCanvas.gameObject.SetActive(false);
    }
    

    void Update()
    {
        
        
        
        
        
    }
    
}

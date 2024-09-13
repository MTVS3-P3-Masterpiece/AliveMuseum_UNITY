using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MuseumManager : MonoBehaviour
{
    
    public enum MuseumState
    {
        Ready,
        Run, 
        Pause,   
        GameOver
    }
 
    public MuseumState mState; 
    public GameObject museumOption;
    private GameObject player;
    public GameObject gameLabel;
    private Text gameText;
    PlayerController playerScript;
    CamRotate camRotate;
   
    void Start()
    {

        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
      //  camRotate = Camera.main.GetComponent<CamRotate>();
    }
    
    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(2f);
        gameText.text = "Go!";
        yield return new WaitForSeconds(0.5f);
        gameLabel.SetActive(false);
        mState = MuseumState.Run;
    }
    void Update()
    {
        
    }

    public void CloseOptionWindow()
    {
        museumOption.SetActive(false);
        Time.timeScale = 1f;
        playerScript.enabled = true;
    }
}

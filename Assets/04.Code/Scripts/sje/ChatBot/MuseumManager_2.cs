using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MuseumManager_2 : MonoBehaviour
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

    public Canvas chineseCanvas;
    //PlayerMove playerScript;
    CamRotate camRotate;
   
    void Start()
    {

        player = GameObject.Find("Player");
        //playerScript = player.GetComponent<PlayerMove>();
        //camRotate = Camera.main.GetComponent<CamRotate>();
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
        //playerScript.enabled = true;
        //camRotate.enabled = true;
    }
    
    public void MoveToKorean()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("3_Hall_Hangle", LoadSceneMode.Additive);
        chineseCanvas.gameObject.SetActive(false);
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}

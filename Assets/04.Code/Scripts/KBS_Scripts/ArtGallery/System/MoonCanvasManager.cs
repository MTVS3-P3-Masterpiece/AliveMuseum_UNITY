using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoonCanvasManager : MonoBehaviour
{
    public Image BG;
    public Image EndingBG;
    public TMP_Text waitText;
    public Button pressTextButton;
    private MoonPosition1 MP1;
    public AudioSource moonSceneAudioSource;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MP1 = FindObjectOfType<MoonPosition1>();
        StartCoroutine(TextChanger());
        
    }

    // Update is called once per frame
    

    IEnumerator TextChanger()
    {
        waitText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        waitText.gameObject.SetActive(false);
        pressTextButton.gameObject.SetActive(true);
    }

    public void IntroSceneManagerButtonOnClick()
    {
        BG.gameObject.SetActive(false);
    }

    public void CharacterTeleportButtonOnClickInMoonScene()
    {
        MP1.TeleportToMoonScene();
    }

    public void EndingButtonOnClick()
    {
        MP1.TeleportToMuseum();
        moonSceneAudioSource.Stop();
        EndingBG.gameObject.SetActive(false);
    }
}

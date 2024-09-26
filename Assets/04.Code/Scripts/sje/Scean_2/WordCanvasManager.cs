using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordCanvasManager : MonoBehaviour
{
    public Image BG;
    public Image EndingBG;
    public Image WaitImage;
    public Button pressTextButton;
    private MoonPosition1 MP1;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MP1 = FindObjectOfType<MoonPosition1>();
        StartCoroutine(TextChanger());
        
    }

    // Update is called once per frame
    

    IEnumerator TextChanger()
    {
        WaitImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        WaitImage.gameObject.SetActive(false);
        pressTextButton.gameObject.SetActive(true);
    }

    public void IntroSceneManagerButtonOnClick()
    {
        BG.gameObject.SetActive(false);
    }

    public void CharacterTeleportButtonOnClickInWordScene()
    {
        MP1.TeleportToWordScene();
    }
    
}
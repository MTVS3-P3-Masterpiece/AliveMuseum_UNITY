using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoonCanvasManager : MonoBehaviour
{
    public Image BG;
    public Image EndingBG;
    public TMP_Text waitText;
    public TMP_Text pressTText;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(TextChanger());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            BG.gameObject.SetActive(false);
        }
    }

    IEnumerator TextChanger()
    {
        waitText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        waitText.gameObject.SetActive(false);
        pressTText.gameObject.SetActive(true);
    }
    
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoonCanvasManager : MonoBehaviour
{
    public Image BG;
    public Image EndingBG;
    public TMP_Text guideText;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            guideText.gameObject.SetActive(false);
            BG.gameObject.SetActive(false);
        }
    }

    public void GameEndingImageController()
    {
        EndingBG.gameObject.SetActive(true);
    }
}

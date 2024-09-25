using UnityEngine;
using UnityEngine.UI;


public class WaitingInfoManager : MonoBehaviour
{
    public Transform player;
    public Button artInfoButton;
    public Button closeButton;
    public Image infoImage;
    public Image titleImage;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 3f)
        {
            artInfoButton.gameObject.SetActive(true);
            titleImage.gameObject.SetActive(true);
        }
        else
        {
            artInfoButton.gameObject.SetActive(false);
            titleImage.gameObject.SetActive(false);
        }
    }

    public void InfoButtonOnClick()
    {
        infoImage.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(true);
    }

    public void CloseButtonOnClick()
    {
        infoImage.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
    }
}

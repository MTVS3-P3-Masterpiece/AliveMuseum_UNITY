using UnityEngine;
using UnityEngine.UI;

public class ArtInfoTrigger : MonoBehaviour
{
    private Transform player;
    public Button artInfoButton;
    public Button closeButton;
    public Image infoImage;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 2f)
        {
            artInfoButton.gameObject.SetActive(true);
        }
        else
        {
            artInfoButton.gameObject.SetActive(false);
        }
    }

    public void InfoButtonOnClick()
    {
        infoImage.gameObject.SetActive(true);
        artInfoButton.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(true);
    }

    public void CloseButtonOnClick()
    {
        closeButton.gameObject.SetActive(false);
    }
}

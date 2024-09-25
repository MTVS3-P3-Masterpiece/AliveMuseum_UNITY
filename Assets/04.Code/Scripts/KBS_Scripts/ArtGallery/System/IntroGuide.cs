using UnityEngine;

public class IntroGuide : MonoBehaviour
{
    private Transform player;
    public Canvas introCanvas;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 1.5f)
        {
            introCanvas.gameObject.SetActive(true);
        }
        else
        {
            introCanvas.gameObject.SetActive(false);
        }
    }
}

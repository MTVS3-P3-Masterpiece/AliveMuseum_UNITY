using UnityEngine;

public class NoteController : MonoBehaviour
{
    private TimingManager theTimingManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theTimingManager = FindObjectOfType<TimingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            theTimingManager.CheckTiming();
        }
    }
}

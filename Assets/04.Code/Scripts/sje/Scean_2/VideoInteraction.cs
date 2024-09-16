using UnityEngine;
using UnityEngine.Video;
using System.Collections;

public class VideoInteraction : MonoBehaviour
{
    [System.Serializable]
    public class CubeVideoPair
    {
        public GameObject cube;  
        public VideoPlayer[] videoPlayers;   
        public float delay;   
    }

    public CubeVideoPair[] cubeVideoPairs;  
    public float interactionDistance = 3.0f;   
    public KeyCode interactionKey = KeyCode.E;   

    private bool[] isVideoPlaying; 

    void Start()
    {
        isVideoPlaying = new bool[cubeVideoPairs.Length];
        for (int i = 0; i < cubeVideoPairs.Length; i++)
        {
            foreach (VideoPlayer videoPlayer in cubeVideoPairs[i].videoPlayers)
            {
                videoPlayer.Stop();
            }
            isVideoPlaying[i] = false;
        }
    }

    void Update()
    {
        for (int i = 0; i < cubeVideoPairs.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, cubeVideoPairs[i].cube.transform.position);
            
            if (distance <= interactionDistance && Input.GetKeyDown(interactionKey))
            {
                if (!isVideoPlaying[i])
                {
                    StartCoroutine(PlayVideosWithDelay(cubeVideoPairs[i].videoPlayers, cubeVideoPairs[i].delay));
                    isVideoPlaying[i] = true;
                }
                else
                {
                    foreach (VideoPlayer videoPlayer in cubeVideoPairs[i].videoPlayers)
                    {
                        videoPlayer.Stop();
                    }
                    isVideoPlaying[i] = false;
                }
            }
        }
    }

    private IEnumerator PlayVideosWithDelay(VideoPlayer[] videoPlayers, float delay)
    {
        yield return new WaitForSeconds(delay);

        foreach (VideoPlayer videoPlayer in videoPlayers)
        {
            videoPlayer.Play();
        }
    }
}




































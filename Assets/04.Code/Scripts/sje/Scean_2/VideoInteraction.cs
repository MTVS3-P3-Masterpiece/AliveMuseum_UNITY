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
    private Light[] sceneLights;   // 씬의 모든 조명

    void Start()
    {
        isVideoPlaying = new bool[cubeVideoPairs.Length];

        // 씬에 있는 모든 Light 컴포넌트를 찾음
        sceneLights = FindObjectsOfType<Light>();

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
                    TurnOffLights();  // 비디오 재생 시 조명 끄기
                    isVideoPlaying[i] = true;
                }
                else
                {
                    foreach (VideoPlayer videoPlayer in cubeVideoPairs[i].videoPlayers)
                    {
                        videoPlayer.Stop();
                    }
                    TurnOnLights();  // 비디오 중지 시 조명 켜기
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

    // 씬의 모든 조명을 끄는 함수
    private void TurnOffLights()
    {
        foreach (Light light in sceneLights)
        {
            light.enabled = false;
        }
    }

    // 씬의 모든 조명을 켜는 함수
    private void TurnOnLights()
    {
        foreach (Light light in sceneLights)
        {
            light.enabled = true;
        }
    }
}

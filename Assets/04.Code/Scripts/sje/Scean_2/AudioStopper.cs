using UnityEngine;

public class AudioStopper : MonoBehaviour
{
    // 범위 안에 들어올 때 오디오를 끄는 스크립트
    private void OnTriggerEnter(Collider other)
    {
 
        if (other.CompareTag("Player"))
        {
 
            AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

 
            foreach (AudioSource audioSource in allAudioSources)
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                    Debug.Log("재생 중인 오디오가 정지되었습니다: " + audioSource.gameObject.name);
                }
            }
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuseumSceneManager : MonoBehaviour
{
    public AudioSource museumBGAudio;
    public string sceneName = "Prototype_ArtRoom_Wolhajeongin";
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        museumBGAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == sceneName)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            museumBGAudio.Stop();
        }
    }
}

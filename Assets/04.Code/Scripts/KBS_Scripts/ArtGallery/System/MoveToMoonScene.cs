using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveToMoonScene : MonoBehaviour
{
    private string sceneName = "Prototype_ArtRoom_Wolhajeongin";
    public Vector3 playerPosition = new Vector3(11.825f, 1.5f, 35f);
    public Image introImage;
    public Material mySkyBox;
    public Button introButton;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter");
            StartCoroutine(ImageController());
        }
    }


    public void OnEnterClickButton()
    {
        TransitionToNextScene();
    }

    private IEnumerator ImageController()
    {
        introButton.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        introButton.gameObject.SetActive(false);
        
    }

    /*  private void OnTriggerExit(Collider other)
      {
          Debug.Log("asdfg");
          if (other.gameObject.CompareTag("Player"))
          {
              introImage.gameObject.SetActive(false);
          }
      } */

    public void TransitionToNextScene()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == sceneName)
        {
            RenderSettings.ambientLight = Color.gray;
            RenderSettings.skybox = mySkyBox;
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    } 
}

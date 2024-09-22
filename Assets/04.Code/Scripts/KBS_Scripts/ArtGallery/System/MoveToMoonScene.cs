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

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter");
            StartCoroutine(ImageController());
        }
    }


    private void OnTriggerStay(Collider other)
    {
        Debug.Log("stay");
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TransitionToNextScene();
            }
        }
    }

    private IEnumerator ImageController()
    {
        introImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        introImage.gameObject.SetActive(false);
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

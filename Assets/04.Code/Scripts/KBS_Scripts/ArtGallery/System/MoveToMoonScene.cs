using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToMoonScene : MonoBehaviour
{
    private string sceneName = "Prototype_ArtRoom_Wolhajeongin";
    public Vector3 playerPosition = new Vector3(11.825f, 1.5f, 35f);
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
               TransitionToNextScene();
            }
        }
    }

    public void TransitionToNextScene()
    {
        SpawnPosition spawnPosition = FindObjectOfType<SpawnPosition>();
        if (spawnPosition != null)
        {
            spawnPosition.desirePosition = playerPosition;
        }

        SceneManager.LoadScene(sceneName);
    }
}

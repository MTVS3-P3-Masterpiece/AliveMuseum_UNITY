using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPosition : MonoBehaviour
{
    public Vector3 desirePosition;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    /*private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    } */

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = desirePosition;
        }
    }
}

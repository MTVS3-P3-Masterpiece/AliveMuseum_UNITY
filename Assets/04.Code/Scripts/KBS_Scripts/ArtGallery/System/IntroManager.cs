using Fusion;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    private const string MainSceneName = "Alpha_Museum";
    
    public GameObject runnerPrefab;
    public TMP_InputField roomNumberInputField;

    private static NetworkRunner Runner;

    public void CreateRoom()
    {
        CreatRoom(roomNumberInputField.text);
    }

    private void CreatRoom(string roomName)
    {
        Debug.Log($"CreateRoom : {roomName}");

        if (Runner == null)
        {
            var runnerGo = Instantiate(runnerPrefab);
            Runner = runnerGo.GetComponent<NetworkRunner>();
        }

        Runner.StartGame(new StartGameArgs
            {
                SessionName = roomName,
                GameMode = GameMode.Shared,
                Scene = SceneRef.FromIndex(SceneUtility.GetBuildIndexByScenePath(MainSceneName)),
            });
    }
}

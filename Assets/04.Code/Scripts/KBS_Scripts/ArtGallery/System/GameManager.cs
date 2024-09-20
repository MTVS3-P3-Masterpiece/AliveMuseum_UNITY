using System;
using UnityEngine;
using System.Collections;
using System.Diagnostics;
using Fusion;
using TMPro;
using Unity.Mathematics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : SimulationBehaviour
{
    public NetworkPrefabRef playerPrefab;
    public Button manButton;
    public Button womenButton;
    public Image BG;
    private NetworkObject _spawnedPlayer;

    public static GameManager Instance;
    public int countdown = 3;
    private TickTimer startTimer;

    private void Awake()
    {
        Instance = this;
    }
    
    public void OnClickButton()
    {
        StartCoroutine(Process());
        
       //runnerController.Runner.Spawn(playerPrefab, new Vector3(0, 1, 0), quaternion.identity);

       //StartCoroutine(SpawnPlayer(RunnerController.Runner));
       womenButton.gameObject.SetActive(false);
       manButton.gameObject.SetActive(false);
       BG.gameObject.SetActive(false);
       
    }

    private IEnumerator Process()
    {
        var op = RunnerController.Runner.SpawnAsync(playerPrefab, new Vector3(4, 1, 4));
        yield return new WaitUntil(() => op.Status == NetworkSpawnStatus.Spawned);
        _spawnedPlayer = op.Object;
        _spawnedPlayer.name = $"Player : {_spawnedPlayer.Id}"; // 하이라이키상의 player이름 변경
        
        startTimer = TickTimer.CreateFromSeconds(RunnerController.Runner, countdown + 1.1f);
        for (var i = countdown; i > 0; i--)
        {
            yield return new WaitForSeconds(1f);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitUntil(() => startTimer.Expired(RunnerController.Runner));

    }

    IEnumerator SpawnPlayer(NetworkRunner runner)
    {
        yield return new WaitUntil(() => SceneManager.GetActiveScene().isLoaded);

        if (runner.IsClient || runner.IsServer)
        {
            runner.Spawn(playerPrefab, new Vector3(0, 1, 0), Quaternion.identity, runner.LocalPlayer);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

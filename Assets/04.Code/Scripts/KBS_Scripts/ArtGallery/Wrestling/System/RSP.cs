using System.Collections;
using TMPro;
using UnityEngine;

public enum RSPState { START, ROCK, SCISSORS, PAPER }
public enum EnemyState {ROCK, SCISSORS, PAPER}

public class RSP : MonoBehaviour
{

    private Unit playerUnit;
    private Unit enemyUnit;

    public TMP_Text dialogue;
    
    public RSPState state;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = RSPState.START;
        StartCoroutine(SetupBattle());
    }
    

    IEnumerator SetupBattle()
    {
        yield return new WaitForSeconds(2f);
        state = RSPState.START;
        PlayerTurn();
    }
    
    void PlayerTurn()
    {
        dialogue.text = "Choose attack or guard";
    }
    
    public void OnRockButton()
    {
        StartCoroutine(PlayerRock());
    }

    public void OnScissorsButton()
    {
        StartCoroutine(PlayerScissors());
    }

    public void OnPaperButton()
    {
        StartCoroutine(PlayerPaper());
    }

    IEnumerator PlayerRock()
    {
        state = RSPState.ROCK;
        yield return new WaitForSeconds(5f);
        StartCoroutine(EnemyTurn());
    }
    
    IEnumerator PlayerScissors()
    {
        state = RSPState.SCISSORS;
        yield return new WaitForSeconds(5f);
        StartCoroutine(EnemyTurn());
    }
    
    IEnumerator PlayerPaper()
    {
        state = RSPState.PAPER;
        yield return new WaitForSeconds(5f);
        StartCoroutine(EnemyTurn());
    }
    

    IEnumerator EnemyTurn()
    {
        
        int enumLength = System.Enum.GetValues(typeof(EnemyState)).Length;

        int randomIndex = Random.Range(0, enumLength);

        EnemyState randomEnumValue = (EnemyState)randomIndex;
        Debug.Log(randomEnumValue);

        if (randomEnumValue == EnemyState.ROCK)
        {
            if (state == RSPState.ROCK)
            {
                dialogue.text = "무승부";
            }

            if (state == RSPState.PAPER)
            {
                dialogue.text = "플레이어 승리";
            }

            if (state == RSPState.SCISSORS)
            {
                dialogue.text = " 플레이어 패배";
            }
        }

        if (randomEnumValue == EnemyState.PAPER)
        {
            if (state == RSPState.ROCK)
            {
                dialogue.text = "플레이어 패배";
            }

            if (state == RSPState.PAPER)
            {
                dialogue.text = "무승부";
            }

            if (state == RSPState.SCISSORS)
            {
                dialogue.text = "플레이어 승리";
            }
        }

        if (randomEnumValue == EnemyState.SCISSORS)
        {
            if (state == RSPState.ROCK)
            {
                dialogue.text = "플레이어 승리";
            }

            if (state == RSPState.PAPER)
            {
                dialogue.text = "플레이어 패배";
            }

            if (state == RSPState.SCISSORS)
            {
                dialogue.text = "무승부";
            }
        }

        yield return null;
    }
   
}

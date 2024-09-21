using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Move,
        Return
    }

    public EnemyState enemyState;

    public float findDistance = 5f;
    public float moveDistance = 10f;
    private Vector3 _originPos;
    private Quaternion _originRot;
    private Transform player;

    private CharacterController cc;
    private NavMeshAgent smith;
    
    void Start()
    {
        enemyState = EnemyState.Idle;

        player = GameObject.Find("Player").transform;
        cc = GetComponent<CharacterController>();

        _originPos = transform.position;
        _originRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyState)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Return:
                Return();
                break;
        }
    }

    private void Idle()
    {
        if (Vector3.Distance(transform.position, player.position) < findDistance)
        {
            enemyState = EnemyState.Move;
        }
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, _originPos) > moveDistance)
        {
            enemyState = EnemyState.Return;
        }
    }

    private void Return()
    {
        if (Vector3.Distance(transform.position, _originPos) > 0.1f)
        {
            smith.SetDestination(_originPos);
            smith.stoppingDistance = 0f;
        }
        else
        {
            smith.isStopped = true;
            smith.ResetPath();
            transform.position = _originPos;
            transform.rotation = _originRot;
            enemyState = EnemyState.Idle;
        }
    }
}

using UnityEngine;
using UnityEngine.AI;

public class EnermyFSM : MonoBehaviour
{
    public enum EnermyState
    {
        Chase,
        Shoot,
        Victory
    }

    [Header("현재 상태")]
    [SerializeField] private EnermyState currentState;

    [Header("컴포넌트")]
    [SerializeField] private EnermyMove enemyMove;
    [SerializeField] private EnemyShooter enemyShooter;
    [SerializeField] private NavMeshAgent agent;

    [Header("플레이어")]
    [SerializeField] private Transform player;

    [Header("발사 설정")]
    [SerializeField] private float shootStopDuration = 1f;

    [Header("승리 설정")]
    [SerializeField] private float victoryRotateSpeed = 360f;

    private PlayerStat playerStat;

    private float shootTimer;
    private float stateTimer;

    private void Start()
    {
        if (enemyMove == null)
            enemyMove = GetComponent<EnermyMove>();

        if (enemyShooter == null)
            enemyShooter = GetComponent<EnemyShooter>();

        if (agent == null)
            agent = GetComponent<NavMeshAgent>();

        if (player == null)
        {
            GameObject obj =
                GameObject.FindGameObjectWithTag("Player");

            if (obj != null)
                player = obj.transform;
        }

        if (player != null)
        {
            playerStat = player.GetComponent<PlayerStat>();

            enemyMove.player = player;
            enemyShooter.player = player;
        }

        ChangeState(EnermyState.Chase);
    }

    private void Update()
    {
        // 플레이어 사망 확인
        if (currentState != EnermyState.Victory)
        {
            if (player == null ||
                (playerStat != null && playerStat.Hp <= 0))
            {
                ChangeState(EnermyState.Victory);
            }
        }

        switch (currentState)
        {
            case EnermyState.Chase:
                Chase();
                break;

            case EnermyState.Shoot:
                Shoot();
                break;

            case EnermyState.Victory:
                Victory();
                break;
        }
    }

    private void ChangeState(EnermyState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case EnermyState.Chase:

                enemyMove.enabled = true;
                enemyShooter.enabled = true;

                agent.isStopped = false;

                break;

            case EnermyState.Shoot:

                enemyMove.enabled = false;

                agent.isStopped = true;
                agent.velocity = Vector3.zero;

                stateTimer = shootStopDuration;

                // 발사 순간 플레이어 위치 저장
                if (player != null)
                {
                    enemyShooter.ShootOnce(player.position);
                }

                break;

            case EnermyState.Victory:

                enemyMove.enabled = false;
                enemyShooter.enabled = false;

                agent.isStopped = true;
                agent.ResetPath();

                // NavMeshAgent의 회전 제어 해제
                agent.updateRotation = false;

                break;
        }
    }

    // 추적 상태
    private void Chase()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= enemyShooter.fireInterval)
        {
            shootTimer = 0f;

            ChangeState(EnermyState.Shoot);
        }
    }

    // 발사 상태
    private void Shoot()
    {
        stateTimer -= Time.deltaTime;

        if (stateTimer <= 0f)
        {
            ChangeState(EnermyState.Chase);
        }
    }

    // 승리 상태
    private void Victory()
    {
        transform.Rotate(
            Vector3.up,
            victoryRotateSpeed * Time.deltaTime
        );
    }
}
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;  // 총알 프리팹
    public Transform player;         // 플레이어 위치
    public Transform firePoint;       // 총알 생성 위치

    public float fireInterval = 2f;  // 발사 간격

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireInterval)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot() //플레이어의 위치를 실시간으로 계산하여, 해당 위치로 포탄이 도달 하게 해 주는 함수. (포물선)
    {
        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            Quaternion.identity
        );

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // 플레이어와 총알의 위치 차이
        Vector3 target = player.position;
        Vector3 start = firePoint.position;

        // 중력 가속도
        float gravity = Mathf.Abs(Physics.gravity.y);

        // 총알이 목표에 도달하는 시간
        float time = 1.5f;

        // X, Z 방향 속도 계산
        Vector3 velocity = new Vector3(
            (target.x - start.x) / time,
            0,
            (target.z - start.z) / time
        );

        // Y 방향 속도 계산 (중력 보정)
        velocity.y = (target.y - start.y + 0.5f * gravity * time * time) / time;

        rb.linearVelocity = velocity;

        // 발사 방향으로 총알 회전
        bullet.transform.rotation = Quaternion.LookRotation(velocity);
    }
}
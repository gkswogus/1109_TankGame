using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [Header("총알 설정")]
    public GameObject bulletPrefab;
    public Transform player;
    public Transform firePoint;

    [Header("발사 간격 개인 조정")]
    public float fireInterval = 2f;

    [Header("포물선 설정")]
    public float time = 1.5f;

    // FSM에서 호출할 발사 함수
    public void ShootOnce(Vector3 targetPosition)
    {
        if (bulletPrefab == null || firePoint == null)
            return;

        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            Quaternion.identity
        );

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb == null)
        {
            Destroy(bullet);
            return;
        }

        Vector3 start = firePoint.position;

        float gravity = Mathf.Abs(Physics.gravity.y);

        Vector3 velocity = new Vector3(
            (targetPosition.x - start.x) / time,
            0,
            (targetPosition.z - start.z) / time
        );

        velocity.y =
            (targetPosition.y - start.y +
            0.5f * gravity * time * time) / time;

        rb.linearVelocity = velocity;

        bullet.transform.rotation =
            Quaternion.LookRotation(velocity);
    }
}
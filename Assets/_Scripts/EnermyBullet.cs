using UnityEngine;

public class EnermyBullet : MonoBehaviour
{
    public float speed = 20f;
    public float distroyBulleTime = 2.0f;
    public int damage = 30;
    private Rigidbody rb;
    private float currentLifeTime;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void OnEnable()
    {
        currentLifeTime = distroyBulleTime;
    }

    private void Update()
    {
        currentLifeTime -= Time.deltaTime;
        if (currentLifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            PlayerStat ps = collision.gameObject.GetComponent<PlayerStat>();
            if (ps != null)
            {
                ps.PlayerDamage(damage);           
            }
        }
        Destroy(gameObject);
    }
}

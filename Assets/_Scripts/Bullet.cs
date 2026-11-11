using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float distroyBulleTime = 2.0f;
    public int damage = 30;
    private Rigidbody rb;
    private float currentLifeTime;

  [SerializeField] private BulletHitEffect hitEffectPrefab;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
     
    }

    private void OnEnable()
    {
        currentLifeTime = distroyBulleTime;

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.linearVelocity = transform.forward * speed;
        }
    }

    private void Update()
    {
        currentLifeTime -= Time.deltaTime;
        if (currentLifeTime <= 0)
        {
            gameObject.SetActive(false);
        }
    }
  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Enermy"))
        {
            EnermyManager e = collision.gameObject.GetComponent<EnermyManager>();
            if (e != null)
            {
                 e.HitDamage(damage);
            }  
        }
        if (hitEffectPrefab != null) hitEffectPrefab.Play(transform.position);
        gameObject.SetActive(false);
    }
}
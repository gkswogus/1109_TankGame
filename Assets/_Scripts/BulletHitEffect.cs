using UnityEngine;

public class BulletHitEffect : MonoBehaviour
{
   [SerializeField] private GameObject hitEffectPrefab;
    public void Play(Vector3 position)
    {
        if (hitEffectPrefab == null)
            return;

        GameObject effect = Instantiate(hitEffectPrefab,  position, Quaternion.identity);

        Destroy(effect, 1f);
    }
}

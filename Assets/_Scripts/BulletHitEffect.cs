using UnityEngine;

public class BulletHitEffect : MonoBehaviour
{
   [SerializeField] private GameObject hitEffectPrefab;
    public void Play(Vector3 position)
    {
        if (hitEffectPrefab == null)
            return;

        Instantiate(hitEffectPrefab, position, Quaternion.identity);
    }
}

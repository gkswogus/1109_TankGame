using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
    [SerializeField] private GameObject particlePrefab;
    [SerializeField] private int initialSize = 3;

    private readonly Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = Instantiate(particlePrefab, transform);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public void Play(Vector3 position)
    {
        GameObject obj = pool.Count > 0
            ? pool.Dequeue()
            : Instantiate(particlePrefab, transform);

        obj.transform.position = position;
        obj.SetActive(true);

        ParticleSystem ps = obj.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            ps.Play();
            StartCoroutine(ReturnAfterPlay(obj, ps.main.duration));
        }
    }

    private IEnumerator ReturnAfterPlay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);

        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
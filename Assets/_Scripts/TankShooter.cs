using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankShooter : MonoBehaviour
{
    public GameObject bulletPrefab;     
    public Transform bulletShooter;
    [Header("총알발사 사운드")]
    public AudioClip fireSfx;

    public int poolSize = 3;
    private List<GameObject> bulletPool;

    [SerializeField] private InputActionReference fire; //스페이스바 연동

    private void OnEnable()
    {
        fire.action.started += Shooter;
    }
    private void OnDisable()
    {
        fire.action.started -= Shooter;
    }

    private void Start()
    {
        bulletPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }
    private void Shooter(InputAction.CallbackContext context)
    {
        Shoot();
    }

    void Shoot()
    {
        if (bulletPrefab == null || bulletShooter == null)
        {
            Debug.LogError($"<Color=yellow><b>Bullet Prefab 또는 BulletShooter</b></color>가 연결되지 않았습니다!");
            return;
        }

        foreach (GameObject bullet in bulletPool)
        {          
            if (!bullet.activeInHierarchy)//해당 오브젝트가 게임 상에 켜졌나??확인하는 거) 
            {
                bullet.transform.position = bulletShooter.position;
                bullet.transform.rotation = bulletShooter.rotation;
                bullet.SetActive(true);

                SoundManager.Instance.PlaySFX(fireSfx);

                return; 
            }
        }
      
        Debug.Log("<color=red>모든 총알이 발사 중입니다! 재장전 대기...</color>");
    }
}
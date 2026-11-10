using UnityEngine;

public class EnermyManager : MonoBehaviour
{
    private int hp = 100;

    public int Hp
    {
        get { return hp; }
        private set { hp = value; }
    }

    public void HitDamage(int damage)
    {
        Hp -= damage;

        if (Hp <= 0)
        {
            Hp = 0;
            Die();
            return;
        }

        Debug.Log($"적에게 {damage}의 데미지를 입혔으며, 남은 체력은 {Hp} 입니다.");
    }

    private void Die()
    {
        Debug.Log($"적의 남은 체력{Hp} 적 사망!");
        Destroy(gameObject);
    }
}

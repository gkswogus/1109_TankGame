using UnityEngine;

public class PlayerStat : MonoBehaviour
{


    [SerializeField] private int hp;
    public int Hp {  get { return hp; } set { hp = value; } }

    private void Start()
    {
      HealthUI.Instance.SetHp(hp);
    }
    public void PlayerDamage(int damage)
    {
        this.Hp-=damage;
        HealthUI.Instance.SetHp(hp);

        if (Hp <= 0)
        {
            Hp = 0;
            Die();
            return;
        }

        Debug.Log($"풀레이어에게 {damage}의 데미지를 입혔으며, 남은 체력은 {Hp} 입니다.");
    }
    private void Die()
    {
        Debug.Log($"플레이어의 남은 체력{Hp} 사망!");

        UiManager.Instance.losePanel.SetActive(true);
        GameManager.Instance.isGameOver = true;
    }
 
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HealthUI : MonoBehaviour
{
    public static HealthUI Instance;

    [Header("하트 UI")]
    [SerializeField] private Image heartPrefab;
    [SerializeField] private Transform heartContainer;

    private List<Image> hearts = new List<Image>();
    private void Awake()
    {
        if(Instance == null) Instance = this;
    }
    public void SetHp(int hp)
    {
        hp = Mathf.Max(0, hp);

        // HP보다 하트가 많으면 제거
        while (hearts.Count > hp)
        {
            int lastIndex = hearts.Count - 1;

            Destroy(hearts[lastIndex].gameObject);
            hearts.RemoveAt(lastIndex);
        }

        // HP보다 하트가 적으면 생성
        while (hearts.Count < hp)
        {
            Image heart = Instantiate(heartPrefab, heartContainer);
            hearts.Add(heart);
        }
    }
}
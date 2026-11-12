using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public  static UiManager Instance;
     public TextMeshProUGUI scoreText;
    public TextMeshProUGUI stageText;
    public GameObject winPanel;
    public GameObject losePanel;

    //public GameObject mainUi;
    private void Awake()
    {
        if(Instance == null) Instance = this;

    }
    private void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        if (scoreText == null || stageText == null) return;
        scoreText.text = GameManager.Instance.enermyCount.ToString();
        stageText.text = GameManager.Instance.currentStage.ToString();
     
    }

    public void Update()
    {
        if (!winPanel.activeInHierarchy && !losePanel.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}

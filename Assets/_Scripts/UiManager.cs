using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public  static UiManager Instance;
     public TextMeshProUGUI scoreText;
    public TextMeshProUGUI stageText;
    public GameObject winPanel;

    //public GameObject mainUi;
    private void Awake()
    {
        if(Instance == null) Instance = this;

    }
    private void Start()
    {
        scoreText.text = GameManager.Instance.enermyCount.ToString();
        stageText.text = GameManager.Instance.currentStage.ToString();
        winPanel.SetActive(false);
    }

    public void Update()
    {
        if (!winPanel.activeInHierarchy)
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

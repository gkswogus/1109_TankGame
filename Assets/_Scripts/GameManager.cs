using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
  /*  [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI stageText;
    [SerializeField] private GameObject winPanel;*/

    public int enermyCount = 0;
    public int currentStage = 1; // 이 값 타이틀에서 스테이지선택 or 게임시작 시 디폴트1로 값 지정.
    public int maxClearStage; //클리어 하지 못한 스테이지는 스테이지선택에서 불가능하게 만들 예정

    public bool isGameOver;

    [Header("탱크 스킨 목록")]
    [SerializeField] private GameObject[] tankSkinPrefabs;
    public int SeletedTankIndex { get; private set; } = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
  
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnScenLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnScenLoaded;
    }
    public void OnScenLoaded(Scene scene, LoadSceneMode mode)
    {
        init();
    }
    public void init()
    {
        GameObject[] Count = GameObject.FindGameObjectsWithTag("Enermy");
        enermyCount = Count.Length;
        isGameOver = false;
    }



    public void KillEnermy() //적 사망 시 호출하도록.
    {
        this.enermyCount -= 1;
        UiManager.Instance.scoreText.text = enermyCount.ToString();
        if (enermyCount <= 0)
        {
            UiManager.Instance.stageText.text = currentStage.ToString();
            UiManager.Instance.winPanel.SetActive(true);
        }
    }
    public void NextStage()
    {
        this.gameObject.GetComponent<ScenesLoadManager>().NextStage();
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
    public void RestartStage()
    {
        this.gameObject.GetComponent<ScenesLoadManager>().ReStartStage();
    }

    public void ChoiceStage(int stage)
    {
        this.currentStage = stage;
    }
   

    /* 탱크 스킨을 고르는 내용 */
    public GameObject SelectedTankPrefab
    {
        get
        {
            return tankSkinPrefabs[SeletedTankIndex];
        }
    }

    public void SelectTank(int index)
    {
        if (index < 0 || index >= tankSkinPrefabs.Length)
        {
            Debug.LogError("잘못 된 탱크 인덱스");
            return;
        }
        SeletedTankIndex = index;

        Debug.Log("선택 된 탱크 이름 :" + SelectedTankPrefab.name);

    }
}

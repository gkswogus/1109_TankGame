using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI stageText;
    [SerializeField] private GameObject winPanel;

    public int enermyCount = 0;
    public int currentStage = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    private void Start()
    {

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
        CountEnermys();
        CountStage();
        winPanel.SetActive(false);
    }
    public void CountEnermys()
    {
        GameObject[] Count = GameObject.FindGameObjectsWithTag("Enermy");
        enermyCount = Count.Length;
        scoreText.text = enermyCount.ToString();
    }

    public void CountStage()
    {
        stageText.text = currentStage.ToString();       
    }

    public void KillEnermy() //적 사망 시 호출하도록.
    {
        this.enermyCount -= 1;
        scoreText.text = enermyCount.ToString();
        if (enermyCount <= 0)
        {
            stageText.text = currentStage.ToString();
            winPanel.SetActive(true);
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

    /*IEnumerator Winners()
    {
        winPanel.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        winPanel.SetActive(false);
        this.gameObject.GetComponent<ScenesLoadManager>().NextStage();
    }*/

}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesLoadManager : MonoBehaviour
{
    public void NextStage()
    {
        GameManager.Instance.currentStage++;
        SceneManager.LoadScene("Stage" + GameManager.Instance.currentStage);
    }
    public void ReStartStage()
    {
        SceneManager.LoadScene("Stage" + GameManager.Instance.currentStage);
    }
    public void BackStage()
    {
        GameManager.Instance.currentStage--;
        SceneManager.LoadScene("Stage" + GameManager.Instance.currentStage);
    }
    public void TitleStage()
    {
        GameManager.Instance.currentStage = 0;
        SceneManager.LoadScene("Stage" + GameManager.Instance.currentStage);
    }
}

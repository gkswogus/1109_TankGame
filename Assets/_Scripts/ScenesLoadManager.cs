using UnityEngine;
using UnityEngine.SceneManagement;

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
}

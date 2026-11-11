using UnityEngine;

public class UiManager : MonoBehaviour
{
    private static UiManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance= this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
}

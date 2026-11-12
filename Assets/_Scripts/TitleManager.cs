using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public GameObject ChoiceUI;
    void Start()
    {
        ChoiceUI.SetActive(false);
    }
public void ChoiceUiOn()
    {
        ChoiceUI.SetActive(true);
    }
    public void ChoiceUiOff()
    {
        ChoiceUI.SetActive(false);
    }
    void Update()
    {
        
    }
}

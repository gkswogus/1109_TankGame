using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public GameObject ChoiceUI;
    public GameObject ChoiceStageUI;
    void Start()
    {
        ChoiceUI.SetActive(false);
        ChoiceStageUI.SetActive(false);
    }
public void ChoiceUiOn()
    {
        ChoiceUI.SetActive(true);
    }
    public void ChoiceUiOff()
    {
        ChoiceUI.SetActive(false);
    }


    public void ChoiceStageUiOn()
    {
        ChoiceStageUI.SetActive(true);
    }
    public void ChoiceStageUiOff() //이거 선택 완료 시 호출 하는 거라, 여기서 선택 된 스테이지 값 게임매니저 currentstage넘겨주기
    {
        ChoiceStageUI.SetActive(false);
    }
}

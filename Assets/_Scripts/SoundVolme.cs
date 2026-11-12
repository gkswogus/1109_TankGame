using UnityEngine;
using UnityEngine.UI;

public class SoundVolme : MonoBehaviour
{
    private AudioSource bgm;
    private AudioSource sfx;
    private AudioSource move;

    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider moveSlider;
    private void OnEnable()
    {
        bgm=SoundManager.Instance.bgmSource;
        sfx = SoundManager.Instance.sfxSource;
        move = SoundManager.Instance.moveSource;

        bgmSlider.SetValueWithoutNotify(bgm.volume);
        sfxSlider.SetValueWithoutNotify(sfx.volume);
        moveSlider.SetValueWithoutNotify(move.volume);
    }
    private void OnDisable()
    {
        bgm= null;
        sfx= null;
        move = null;
    }
    public void SetBGMVolume(float value)
    {
        bgm.volume = value;
    }

    public void SetSFXVolume(float value)
    {
        sfx.volume = value;
    }

    public void SetMoveVolume(float value)
    {
        move.volume = value;
    }
}

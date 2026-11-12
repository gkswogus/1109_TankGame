using UnityEngine;

public class TitleSound : MonoBehaviour
{
    [SerializeField] private AudioClip AudioSource;

    private void Start()
    {
        SoundManager.Instance.PlayBGM(AudioSource);
    }
}

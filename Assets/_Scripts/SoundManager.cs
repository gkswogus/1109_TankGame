using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
   public AudioSource bgmSource;
   public AudioSource sfxSource;
   public AudioSource moveSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // 움직임 사운드 재생
    public void PlayMove(AudioClip clip)
    {
        moveSource.clip = clip;
        moveSource.loop = true;
        moveSource.Play();
    }
    // 움직임 사운드 정지
    public void StopMove()
    {
        moveSource.Stop();
    }


    // 효과음 재생
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    // 배경음악 재생
    public void PlayBGM(AudioClip clip)
    {
        if (bgmSource.clip == clip && bgmSource.isPlaying)
            return;

        bgmSource.clip = clip;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    // 배경음악 정지
    public void StopBGM()
    {
        bgmSource.Stop();
    }
}
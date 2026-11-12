using UnityEngine;

public class Stage1Sound : MonoBehaviour
{
   [SerializeField] private AudioClip AudioClip;
    void Start()
    {
        SoundManager.Instance.PlayBGM(AudioClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;

namespace Golf
{   

    public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hitClip;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayHitSound()
    {
        audioSource.PlayOneShot(hitClip);
    }
}
}

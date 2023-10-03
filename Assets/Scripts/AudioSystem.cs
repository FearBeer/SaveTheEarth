using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    [Header("Background Music")]
    public AudioClip[] sounds;
    [Header("Other sounds")]
    public AudioClip[] playersSounds;
    [Header("Button sounds")]
    public AudioClip[] buttonSounds;
    public static AudioSystem instance;
    private AudioSource audioSource => GetComponent<AudioSource>();

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void PlaySound(AudioClip clip, float volume)
    {
        audioSource.PlayOneShot(clip, volume);
    }

    public void ChangeTrack(AudioClip clip)
    {
        audioSource.clip = clip;
    }

    public void PlayMusic()
    {
        audioSource.Play();
    }

    public void PauseMusic()
    {
        audioSource.Stop();
    }
}

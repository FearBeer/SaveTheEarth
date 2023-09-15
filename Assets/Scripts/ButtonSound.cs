using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] AudioClip hoverSound;
    [SerializeField] AudioClip clickSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void HoverSound()
    {
        audioSource.PlayOneShot(hoverSound);
    }
    public void ClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }
}

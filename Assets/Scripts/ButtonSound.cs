using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public void HoverSound()
    {
        AudioSystem.instance.PlaySound(AudioSystem.instance.buttonSounds[0], 1f);
    }
    public void ClickSound()
    {
        AudioSystem.instance.PlaySound(AudioSystem.instance.buttonSounds[1], 1f);
    }

    public void ChangeAudio(AudioClip clip)
    {
        AudioSystem.instance.ChangeTrack(clip);
        AudioSystem.instance.PlayMusic();
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundsPlay : MonoBehaviour
{
    [SerializeField] private AudioClip destroyEnemy;
    [SerializeField] private AudioClip earthCrash;
    [SerializeField] private AudioClip colissionStation;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void DestroyEnemySound()
    {
        audioSource.PlayOneShot(destroyEnemy);
    }

    public void EarthCrashSound()
    {
        audioSource.PlayOneShot(earthCrash, 0.5f);
    }

    public void ColissionStationSound()
    {
        audioSource.PlayOneShot(colissionStation, 0.5f);
    }
}

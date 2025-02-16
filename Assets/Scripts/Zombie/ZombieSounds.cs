using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieSounds : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip[] idleSounds;
    public AudioClip[] angrySounds;
    public AudioClip[] attackingSounds;
    public AudioClip[] deathSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAttackSound() {
        PlayRandomSound(attackingSounds);
    }
    public void PlayAngrySound() {
        PlayRandomSound(angrySounds);
    }
    public void PlayDeathSound()
    {
        PlayRandomSound(deathSound);
    }

    private void PlayRandomSound(AudioClip[] soundArray)
    {
        if (soundArray.Length > 0)
        {
            int index = Random.Range(0, soundArray.Length);
            audioSource.PlayOneShot(soundArray[index]);
        }
    }

}


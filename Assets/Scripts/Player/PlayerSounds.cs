using UnityEngine;
using UnityEngine.Audio;

public class PlayerSounds : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] jumpSound;
    public AudioClip[] hurtSound;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void PlayRandomSound(AudioClip[] soundArray)
    {
        if (soundArray.Length > 0)
        {
            int index = Random.Range(0, soundArray.Length);
            audioSource.PlayOneShot(soundArray[index]);
        }
    }
    public void PlayJumpSound()
    {
        PlayRandomSound(jumpSound);
    }
    public void PlayHurtSound()
    {
        PlayRandomSound(hurtSound);
    }
}

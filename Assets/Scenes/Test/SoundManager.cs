using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isPlaying = false; // Flag to control looping

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    // Call this method to play the sound effect
    public void PlaySoundEffect()
    {
        if (!isPlaying)
        {
            // Start playing the sound effect and set loop to true
            audioSource.loop = true;
            audioSource.Play();
            isPlaying = true;
        }
    }

    // Call this method to stop the sound effect
    public void StopSoundEffect()
    {
        // Stop playing the sound effect and set loop to false
        audioSource.loop = false;
        audioSource.Stop();
        isPlaying = false;
    }
}
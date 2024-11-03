using UnityEngine;

public class ShipSoundController : MonoBehaviour
{
    private AudioSource audioSource;
    private Rigidbody rb;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        // Ensure the sound doesn�t play at the start
        if (audioSource != null)
        {
            audioSource.loop = true;  // Set to loop for continuous engine sound
            audioSource.Stop();       // Stop initially
        }
    }

    void Update()
    {
        if (rb.linearVelocity.magnitude > 0.1f) // Adjust the threshold as needed
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();  // Start playing the engine sound when moving
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause(); // Pause the engine sound when stopped
            }
        }
    }
}

using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    [Header("Footstep Settings")]
    public AudioClip footstepClip;       // Your footstep sound clip
    public float stepInterval = 0.5f;      // Time (in seconds) between footsteps when moving
    public float minDistance = 0.1f;       // Minimum distance moved to consider it "walking"

    [Header("Audio Source")]
    public AudioSource audioSource;      // Optionally assign one here (or one will be added automatically)

    private Vector3 lastPosition;        // To track movement
    private float stepTimer = 0f;

    private void Start()
    {
        lastPosition = transform.position;
        if (audioSource == null)
        {
            // Add an AudioSource component if one isn't assigned
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = footstepClip;
        audioSource.loop = false;
    }

    private void Update()
    {
        // Calculate how far we've moved since last frame
        float distance = Vector3.Distance(transform.position, lastPosition);

        if (distance > minDistance)
        {
            stepTimer += Time.deltaTime;

            // If enough time has passed, play a footstep sound
            if (stepTimer >= stepInterval)
            {
                PlayFootstep();
                stepTimer = 0f;
                // Update lastPosition after playing a step
                lastPosition = transform.position;
            }
        }
        else
        {
            // Reset timer if not moving
            stepTimer = 0f;
        }
    }

    private void PlayFootstep()
    {
        if (footstepClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(footstepClip);
        }
    }
}

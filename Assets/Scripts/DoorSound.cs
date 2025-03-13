using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DoorSound : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip doorOpenClip;      // The sound clip for door opening
    public AudioSource audioSource;     // AudioSource to play the clip
    [Range(0f, 1f)] public float volume = 1f;

    [Header("Door Angles")]
    public float openAngleThreshold = 30f; // Angle at which we consider the door "open"
    public float closedAngleThreshold = 5f; // If you also want to detect "close"

    // Internal state
    private bool hasPlayedOpenSound = false;

    private void Start()
    {
        // If no AudioSource is assigned, add one
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.loop = false;
        }
    }

    private void Update()
    {
        // Measure the door's local rotation around the hinge axis (often Y)
        float doorAngle = transform.localEulerAngles.y;

        // Because Euler angles can jump from 0 to 360, normalize to [0..180] range for detection
        if (doorAngle > 180f)
            doorAngle -= 360f;

        // If the door crosses our open threshold and we haven't played the sound yet
        if (!hasPlayedOpenSound && Mathf.Abs(doorAngle) > openAngleThreshold)
        {
            PlayOpenSound();
            hasPlayedOpenSound = true;
        }

        // (Optional) If you also want to detect door closing, you can do:
        // if (hasPlayedOpenSound && Mathf.Abs(doorAngle) < closedAngleThreshold)
        // {
        //     // e.g., play a "doorCloseClip" if you have one
        //     // audioSource.PlayOneShot(doorCloseClip, volume);
        //     hasPlayedOpenSound = false;
        // }
    }

    private void PlayOpenSound()
    {
        if (doorOpenClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(doorOpenClip, volume);
            Debug.Log("Door open sound played.");
        }
    }
}

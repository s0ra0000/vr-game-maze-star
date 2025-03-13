using UnityEngine;
using TMPro;

public class StarCollector : MonoBehaviour
{
    [Header("UI Reference")]
    public TMP_Text starText;      // Assign in the Inspector

    [Header("Door Lock Reference")]
    public DoorLock doorLock;      // Assign your door's DoorLock script in the Inspector

    [Header("Audio")]
    public AudioClip collectSound; // The sound to play when a star is collected
    public AudioSource audioSource; // Reference to an AudioSource component

    private int starCount = 0;

    private void Awake()
    {
        // If no AudioSource is assigned, add one
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered!");
        Debug.Log("Triggered by: " + other.gameObject.name);
        Debug.Log("Collider Tag: " + other.tag);
        Debug.Log("Root Name: " + other.transform.root.name);
        Debug.Log("Root Tag: " + other.transform.root.tag);

        // Check if the collider is tagged "Star"
        if (other.CompareTag("Star"))
        {
            Debug.Log("Star Triggered!");

            // Increment the star counter
            starCount++;
            Debug.Log("Star Count: " + starCount);

            // Update the UI text
            if (starText != null)
            {
                starText.text = starCount + "/2";
            }
            else
            {
                Debug.LogError("starText is not assigned in the Inspector!");
            }

            // Play the collect sound (if assigned)
            if (collectSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(collectSound);
            }

            // If the player has collected 2 or more stars, unlock the door
            if (starCount >= 2)
            {
                if (doorLock != null)
                {
                    doorLock.UnlockDoor();
                }
                else
                {
                    Debug.LogError("doorLock is not assigned in the Inspector!");
                }
            }

            // (Optional) Destroy the star so it’s “collected”
            // Destroy(other.gameObject);
        }
    }

    // Public getter for the star count (if needed)
    public int GetStarCount()
    {
        return starCount;
    }
}

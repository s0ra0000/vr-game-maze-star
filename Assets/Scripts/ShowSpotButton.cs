using System.Collections;
using UnityEngine;

public class ShowSpotsButton : MonoBehaviour
{
    [Header("Settings")]
    public float appearTime = 10f;

    [Header("Audio")]
    public AudioClip pushSound;       // Sound clip to play when button is pressed
    public AudioSource audioSource;   // AudioSource to play the sound
    [Range(0f, 1f)]
    public float volume = 1.4f;         // Volume (0.0 to 1.0)

    private void Awake()
    {
        // If no AudioSource is assigned, add one automatically
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
        // Set the AudioSource volume from the public volume variable
        audioSource.volume = volume;
    }

    public void ShowSpotsTemporarily()
    {
        // Play the button push sound with the defined volume
        if (audioSource != null && pushSound != null)
        {
            audioSource.PlayOneShot(pushSound, volume);
        }

        // Proceed with showing spots
        StartCoroutine(ShowSpotsCoroutine());
    }

    private IEnumerator ShowSpotsCoroutine()
    {
        GameObject[] spots = GameObject.FindGameObjectsWithTag("Spot");
        Debug.Log("Found " + spots.Length + " spots.");

        // Show them by enabling MeshRenderer
        foreach (GameObject spot in spots)
        {
            MeshRenderer renderer = spot.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                renderer.enabled = true;
            }
        }

        yield return new WaitForSeconds(appearTime);

        // Hide them again
        foreach (GameObject spot in spots)
        {
            MeshRenderer renderer = spot.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }
        }
        Debug.Log("All spots hidden after " + appearTime + " seconds!");
    }
}

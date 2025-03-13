using UnityEngine;
using TMPro;

public class DoorTimer : MonoBehaviour
{
    [Header("Timer Text Reference")]
    public TMP_Text timerText;   // Assign your TextMeshPro UI element here in the Inspector

    private bool startTimer = false;
    private float currentTime = 0f;

    private void Update()
    {
        if (startTimer)
        {
            currentTime += Time.deltaTime;
            // Format the time to, say, two decimals
            timerText.text = currentTime.ToString("F2");
        }
    }

    // This method is called automatically when something enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by object name: " + other.gameObject.name);
        Debug.Log("Tag of the collider: " + other.gameObject.tag);

        // If you want the root object’s tag (e.g., the top-level parent)
        Debug.Log("Root object name: " + other.transform.root.name);
        Debug.Log("Root object tag: " + other.transform.root.tag);
        // Check if it's the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Triggered!");
            // We can also display "Hello world" right before starting, if needed
            timerText.text = "Hello world";

            // Now start the timer
            startTimer = true;
        }
    }
    //--- New Methods ---
    public void StopTimer()
    {
        startTimer = false;
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }
}

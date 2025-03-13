using UnityEngine;
using UnityEngine.SceneManagement;  // For SceneManager
using TMPro;                       // For TMP_Text

public class EndDoor : MonoBehaviour
{
    [Header("References")]
    public DoorTimer doorTimer;         // Assign the DoorTimer object in Inspector
    public GameObject endGameCanvas;    // The UI Canvas that has Restart & Menu buttons
    public TMP_Text finalTimeText;      // A TextMeshPro field to show final time

    private bool gameEnded = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!gameEnded && other.CompareTag("Player"))
        {
            gameEnded = true;

            // 1) Stop the timer
            doorTimer.StopTimer();

            // 2) Show the end-game UI
            endGameCanvas.SetActive(true);

            // 3) Display the final time
            float finalTime = doorTimer.GetCurrentTime();
            finalTimeText.text = "Final Time: " + finalTime.ToString("F2");
        }
    }

    // Called by the "Restart" button
    public void RestartGame()
    {
        // Replace "2 Game Scene" with the exact scene name or index
        SceneManager.LoadScene("2 Game Scene");
    }

    // Called by the "Menu" button
    public void BackToMenu()
    {
        // Replace "1 Start Scene" with the exact scene name or index
        SceneManager.LoadScene("1 Start Scene");
    }
}

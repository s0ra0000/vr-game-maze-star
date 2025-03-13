using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DoorLock : MonoBehaviour
{
    [Header("Star Requirement")]
    public int requiredStars = 2;

    [Header("Star Collector Reference")]
    public StarCollector starCollector; // Assign this via the Inspector

    private Rigidbody doorRigidbody;
    private bool isLocked = true;

    private void Start()
    {
        doorRigidbody = GetComponent<Rigidbody>();

        if (starCollector != null && starCollector.GetStarCount() >= requiredStars)
        {
            Debug.Log("UnlockDoor() called!");
            UnlockDoor();
        }
        else
        {
            int currentStars = (starCollector != null) ? starCollector.GetStarCount() : 0;
            Debug.Log("Door still locked. Star count = " + currentStars);
            LockDoor();
        }
    }

    private void Update()
    {
        // Continuously check if the door should unlock
        if (isLocked && starCollector != null && starCollector.GetStarCount() >= requiredStars)
        {
            UnlockDoor();
        }
    }

    private void LockDoor()
    {
        doorRigidbody.isKinematic = true;
        isLocked = true;
        Debug.Log("Door locked! Need " + requiredStars + " stars.");
    }

    public void UnlockDoor()  // Made public in case you want to call it externally
    {
        doorRigidbody.isKinematic = false;
        isLocked = false;
        Debug.Log("Door unlocked!");
    }
}

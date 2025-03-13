using UnityEngine;

public class HideSpotsOnAwake : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] spots = GameObject.FindGameObjectsWithTag("Spot");
        foreach (GameObject spot in spots)
        {
            MeshRenderer renderer = spot.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                renderer.enabled = false; // Hide visually
            }
        }
    }
}

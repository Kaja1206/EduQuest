using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject endingPanel; // Reference to the ending panel UI

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            // Show the ending panel
            if (endingPanel != null)
            {
                endingPanel.SetActive(true);
                Time.timeScale = 0; // Pause the game
            }
        }
    }
}
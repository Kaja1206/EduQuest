using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject questionPanel; // Reference to the question panel UI

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            // Save checkpoint data
            PlayerManage.lastCP = transform.position;
            PlayerPrefs.SetInt("CheckpointCoins", PlayerManage.NoOfCoins);

            // Change checkpoint color
            GetComponent<SpriteRenderer>().color = Color.green;

            // Play checkpoint sound
            AudioManager.instance.Play("CheckPoint");

            // Show the question panel
            if (questionPanel != null)
            {
                questionPanel.SetActive(true);
                Time.timeScale = 0; // Pause the game
            }
        }
    }
}

using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject questionPanel; // Reference to the question panel UI
    private bool isActivated = false; // Flag to track if the checkpoint is activated

    private void Start()
    {
        // Check if this checkpoint has already been activated
        if (PlayerPrefs.HasKey("CheckpointActivated_" + gameObject.name))
        {
            isActivated = true;
            GetComponent<SpriteRenderer>().color = Color.green; // Set color to green if already activated
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" && !isActivated)
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

            // Mark this checkpoint as activated
            isActivated = true;
            PlayerPrefs.SetInt("CheckpointActivated_" + gameObject.name, 1); // Save activation state
        }
    }
}
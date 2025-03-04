using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject questionPanel; // Reference to the question panel UI

    private bool isActivated = false; // Flag to track if the checkpoint is activated

    private void Start()
    {
        // Load the activation state from PlayerPrefs
        isActivated = PlayerPrefs.GetInt("CheckpointActivated_" + gameObject.name, 0) == 1;

        // If the checkpoint is already activated, change its color to green
        if (isActivated)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" && !isActivated)
        {
            // Mark the checkpoint as activated
            isActivated = true;

            // Save the activation state to PlayerPrefs
            PlayerPrefs.SetInt("CheckpointActivated_" + gameObject.name, 1);

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

    public void ResetCheckpoint()
    {
        // Reset the activation state
        isActivated = false;
        PlayerPrefs.SetInt("CheckpointActivated_" + gameObject.name, 0);

        // Reset the checkpoint color
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
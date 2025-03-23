using UnityEngine;

public class RaycastJumpPad : MonoBehaviour
{
    public float jumpForce = 10f;
    public LayerMask playerLayer; // Set this in the Inspector to the player's layer

    void Update()
    {
        // Raycast downwards to detect the player
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, playerLayer); // Adjust distance (1f) as needed

        if (hit.collider != null)
        {
            Rigidbody2D rb = hit.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Apply the jump force
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
        }
    }
}
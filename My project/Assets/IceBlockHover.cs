using UnityEngine;

public class IceBlockHover : MonoBehaviour
{
    private Vector3 originalScale;
    private bool isHovering = false;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void OnMouseEnter()
    {
        isHovering = true;
        transform.localScale = originalScale * 9.1f; // Slightly enlarge
    }

    void OnMouseExit()
    {
        isHovering = false;
        transform.localScale = originalScale; // Reset to original size
    }

    void Update()
    {
        if (isHovering)
        {
            // Optional: Add a shake effect
            transform.Rotate(Vector3.forward * Mathf.Sin(Time.time * 10) * 2);
        }
    }
}


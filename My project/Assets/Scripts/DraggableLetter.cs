using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableLetter : MonoBehaviour
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;
    private Transform originalParent;
    public string letter;
    private bool isDragging = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = rectTransform.anchoredPosition;
        originalParent = transform.parent;
    }

    public void StartDragging()
    {
        isDragging = true;
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        transform.SetParent(transform.root);
    }

    public void OnDragging()
    {
        if (isDragging)
        {
            rectTransform.position = Input.mousePosition;
        }
    }

    public void StopDragging()
    {
        isDragging = false;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        // If not dropped in valid zone, return to original position
        if (transform.parent == transform.root)
        {
            transform.SetParent(originalParent);
            rectTransform.anchoredPosition = originalPosition;
        }
    }

    public void ResetPosition()
    {
        transform.SetParent(originalParent);
        rectTransform.anchoredPosition = originalPosition;
    }
}


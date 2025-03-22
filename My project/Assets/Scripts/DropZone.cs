using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    private DraggableLetter currentLetter;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DraggableLetter letter = eventData.pointerDrag.GetComponent<DraggableLetter>();
            if (letter != null)
            {
                
                if (currentLetter != null)
                {
                    currentLetter.ResetPosition();
                }

                
                currentLetter = letter;
                letter.transform.SetParent(transform);
                letter.transform.position = transform.position;
            }
        }
    }

    public string GetCurrentLetter()
    {
        return currentLetter != null ? currentLetter.letter : "";
    }

    public void ClearDropZone()
    {
        if (currentLetter != null)
        {
            currentLetter.ResetPosition();
            currentLetter = null;
        }
    }
}

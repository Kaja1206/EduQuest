using UnityEngine;

public class CharacterDance : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            animator = gameObject.AddComponent<Animator>();
        }

        // Start dancing
        animator.Play("Dance");
    }

    public void StartDancing()
    {
        animator.SetBool("IsDancing", true);
    }

    public void StopDancing()
    {
        animator.SetBool("IsDancing", false);
    }
}

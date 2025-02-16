using UnityEngine;

public class MovingSaw : MonoBehaviour
{

    public float speed = 2;
    public int dir = 1;

    public Transform right;
    public Transform left;
    


     void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * dir * Time.fixedDeltaTime);
        if (Physics2D.Raycast(right.position, Vector2.down, 2) == false)
            dir = -1;

        if (Physics2D.Raycast(left.position, Vector2.down, 2) == false)
            dir = 1;

    }
}


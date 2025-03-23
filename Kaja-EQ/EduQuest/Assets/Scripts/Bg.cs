using UnityEngine;

public class Bg : MonoBehaviour
{
    public Transform main;
    public Transform middle;
    public Transform side;

    public float length = 28.4f;
    void Update()
    {
        if (main.position.x > middle.position.x)
            side.position = middle.position + Vector3.right * length;

        if(main.position.x < middle.position.x)
            side.position = middle.position + Vector3.left * length;

        if (main.position.x > side.position.x || main.position.x < side.position.x)
        {
            Transform z = middle;
            middle = side;
            side = z;
            
        }
    }


}

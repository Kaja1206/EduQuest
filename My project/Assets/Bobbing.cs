using UnityEngine;
using System.Collections;

public class Bobbing : MonoBehaviour
{
    public float bobbingSpeed = 2f;
    public float bobbingAmount = 0.1f;
    private float originalY;

    void Start()
    {
        originalY = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, originalY + Mathf.Sin(Time.time * bobbingSpeed) * bobbingAmount, transform.position.z);
    }
}


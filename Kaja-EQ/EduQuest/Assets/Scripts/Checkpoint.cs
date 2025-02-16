using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
                      // Your other logic here
            PlayerManage.lastCP = transform.position;
            GetComponent<SpriteRenderer>().color = Color.green;
            AudioManager.instance.Play("CheckPoint");
        }
    }
}

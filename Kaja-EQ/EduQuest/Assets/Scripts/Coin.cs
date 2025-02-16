using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            PlayerManage.NoOfCoins++;
            AudioManager.instance.Play("Coins");
            PlayerPrefs.SetInt("NoOfCoins", PlayerManage.NoOfCoins);
            Destroy(gameObject);
        }
    }
}

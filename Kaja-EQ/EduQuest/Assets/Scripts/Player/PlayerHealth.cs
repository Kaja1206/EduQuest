using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static int health = 3;

    public Image[] hearts;
    public Sprite heart;
    public Sprite emptyHeart;

    private void Awake()
    {
        health = 3;
    }
    // Update is called once per frame
    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = heart;
        }
    }
}

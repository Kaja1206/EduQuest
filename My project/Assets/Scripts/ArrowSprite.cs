using UnityEngine;

[CreateAssetMenu(fileName = "ArrowSprite", menuName = "Quiz/Arrow Sprite")]
public class ArrowSprite : ScriptableObject
{
    public Sprite arrowSprite;
    public Color arrowColor = Color.white;
    public float arrowSize = 50f;
}

using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card System/Card")]
public class Card : ScriptableObject
{
    public int cost;
    public int troopCount;
    public string title;
    public string description;
    public Image image;
}
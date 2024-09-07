using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewDeck", menuName = "Card System/Deck")]
public class Deck : ScriptableObject
{
    public List<Card> cards;
}
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public List<Deck> container = new List<Deck>(); // Deck ScriptableObject'leri listesi
    public Text displayText; // Kartlar� g�stermek i�in UI Text
    public Button nextDeckButton; // Sonraki deste i�in buton

    private int currentDeckIndex = 0;

    void Start()
    {
        // Ba�lang��ta ilk desteyi g�ster
        DisplayCurrentDeck();

        // Butona t�klama olay�n� ekle
        nextDeckButton.onClick.AddListener(NextDeck);
    }

    // Bir sonraki desteye ge�i�
    void NextDeck()
    {
        currentDeckIndex++;

        // E�er mevcut deste indexi konteynerin boyutunu a�arsa, en ba�a d�n
        if (currentDeckIndex >= container.Count)
        {
            currentDeckIndex = 0;
        }

        DisplayCurrentDeck();
    }

    // Mevcut desteyi g�r�nt�le
    void DisplayCurrentDeck()
    {
        if (container.Count == 0) return;

        Deck currentDeck = container[currentDeckIndex];

        displayText.text = "Deck " + (currentDeckIndex + 1) + ":\n";

    }
}

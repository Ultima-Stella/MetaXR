using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public List<Deck> container = new List<Deck>(); // Deck ScriptableObject'leri listesi
    public Text displayText; // Kartlarý göstermek için UI Text
    public Button nextDeckButton; // Sonraki deste için buton

    private int currentDeckIndex = 0;

    void Start()
    {
        // Baþlangýçta ilk desteyi göster
        DisplayCurrentDeck();

        // Butona týklama olayýný ekle
        nextDeckButton.onClick.AddListener(NextDeck);
    }

    // Bir sonraki desteye geçiþ
    void NextDeck()
    {
        currentDeckIndex++;

        // Eðer mevcut deste indexi konteynerin boyutunu aþarsa, en baþa dön
        if (currentDeckIndex >= container.Count)
        {
            currentDeckIndex = 0;
        }

        DisplayCurrentDeck();
    }

    // Mevcut desteyi görüntüle
    void DisplayCurrentDeck()
    {
        if (container.Count == 0) return;

        Deck currentDeck = container[currentDeckIndex];

        displayText.text = "Deck " + (currentDeckIndex + 1) + ":\n";

    }
}

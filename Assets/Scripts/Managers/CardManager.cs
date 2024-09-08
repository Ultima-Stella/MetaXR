using GorillaZilla;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public List<Deck> container = new List<Deck>(); // Deck ScriptableObject'leri listesi
    public Button openCloseButton; // Kartlarý göstermek için UI Text
    public Button nextDeckButton; // Sonraki deste için buton
    public List<GameObject> cards = new();
    private int currentDeckIndex = 0;

    public GameObject closeButton;
    public GameObject openButton;
    public GameManager gameManager;

    private bool deckOpen = false;

    void Start()
    {
        // Baþlangýçta ilk desteyi göster
        DisplayCurrentDeck();

        gameManager = GetComponent<GameManager>();

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

        for (int i = 0; i < currentDeck.cards.Count; i++)
        {

            cards[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentDeck.cards[i].cost.ToString();
        }



    }

    public async void ProcessCard(int index)
    {

        gameManager.playerGold -= container[currentDeckIndex].cards[index].cost;
        await gameManager.PutTroop();
    }



    public void OpenDeck()
    {


        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].transform.gameObject.SetActive(true);
        }
        closeButton.SetActive(true);
        openButton.SetActive(false);
    }

    public void CloseDect()
    {
        closeButton.SetActive(false);
        openButton.SetActive(true);

        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].transform.gameObject.SetActive(false);
        }

    }
}

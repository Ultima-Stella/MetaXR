using GorillaZilla;
using System.Collections.Generic;
using System.Numerics;
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

    Image[] cardImages;
    List<GameObject> currentTroops = new List<GameObject>();
    private bool deckOpen = false;
    bool inPlane = false;
    bool waitForTroop = false;
    void Start()
    {
        DisplayCurrentDeck();
        // Baþlangýçta ilk desteyi göster
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
            currentTroops.Add(currentDeck.cards[i].prefab);
            cards[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentDeck.cards[i].cost.ToString();
        }



    }

    public void ProcessCard(int index)
    {

        gameManager.playerGold -= container[currentDeckIndex].cards[index].cost;



        waitForTroop = true;








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

    private void Update()
    {

        if (inPlane && waitForTroop)
        {
            // Check if A button is pressed on Oculus controller (Right hand)
            if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch))
            {
                UnityEngine.Vector3 localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);

                // Convert to world position by applying the camera rig's world transform
                UnityEngine.Vector3 worldPosition = OVRManager.instance.transform.TransformPoint(localPosition);


                foreach(GameObject go in currentTroops){
                    Instantiate(go, worldPosition, UnityEngine.Quaternion.Euler(new UnityEngine.Vector3(0,0,0)));
                }
           

            }

            // Check if B button is pressed on Oculus controller (Right hand)
            if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
            {
                UnityEngine.Vector3 localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);

                // Convert to world position by applying the camera rig's world transform
                UnityEngine.Vector3 worldPosition = OVRManager.instance.transform.TransformPoint(localPosition);

                foreach (GameObject go in currentTroops)
                {
                    Instantiate(go, worldPosition, UnityEngine.Quaternion.Euler(new UnityEngine.Vector3(0, 0, 0)));
                }


            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Plane"))
        {
            inPlane = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {


        if (other.gameObject.CompareTag("Plane"))
        {
            inPlane = false;
        }
    }
}
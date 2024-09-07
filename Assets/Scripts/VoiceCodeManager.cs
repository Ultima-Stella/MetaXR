﻿using Meta.WitAi; // Meta Voice SDK'nın namespace'i
using Meta.WitAi.Dictation; // Dictation için gerekli namespace
using UnityEngine;

public class VoiceCodeManager : MonoBehaviour
{
    public WitDictation witDictation; // WitDictation bileşeni
    public GameObject cube;

    private void Start()
    {
        if (witDictation == null)
        {
            Debug.LogError("WitDictation bileşeni atanmadı. Lütfen Unity'de bu bileşeni sürükleyip bırakın.");
            return;
        }

        // Dinlemeye başla
        witDictation.DictationEvents.OnFullTranscription.AddListener(OnTranscriptionReceived);
        witDictation.DictationEvents.OnStartListening.AddListener(OnListeningStarted);
        witDictation.DictationEvents.OnStoppedListening.AddListener(OnListeningStopped);

        // WitDictation'da ses dinleme otomatik başlatılıyor, elle başlatmak istersen:
        witDictation.Activate();
    }

    // Sesli komut alındığında tetiklenen fonksiyon
    private void OnTranscriptionReceived(string transcription)
    {
        Debug.Log("Duyulan: " + transcription);

        // Metne göre komutları işleme
        if (transcription.ToLower().Contains("ışığı aç"))
        {
            TurnOnLight(); // Komut ile ilgili aksiyonu tetikle
        }
        else if (transcription.ToLower().Contains("ışığı kapat"))
        {
            TurnOffLight();
        }
        else
        {
            Debug.Log("Komut tanınmadı.");
        }
    }

    // Dinlemeyi başlatan callback
    private void OnListeningStarted()
    {
        Debug.Log("Dinlemeye başlandı...");
    }

    // Dinlemeyi durduran callback
    private void OnListeningStopped()
    {
        Debug.Log("Dinleme durdu.");
    }

    // Işık açma komutu
    private void TurnOnLight()
    {
        Debug.Log("Işık açıldı!");
        cube.SetActive(true);
        // Işık açma işlemleri buraya eklenir
    }

    // Işık kapatma komutu
    private void TurnOffLight()
    {
        Debug.Log("Işık kapandı!");
        cube.SetActive(false);
        // Işık kapatma işlemleri buraya eklenir
    }
}
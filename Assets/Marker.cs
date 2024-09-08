using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Untagged"))
        {
            other.gameObject.tag = "Marked";
            Rigidbody rb = other.GetComponent<Rigidbody>();
            Debug.Log("Çarptı");
            other.GetComponent<Renderer>().material.color = Color.red;
        }

    }
    void Update()
    {
        
    }
}

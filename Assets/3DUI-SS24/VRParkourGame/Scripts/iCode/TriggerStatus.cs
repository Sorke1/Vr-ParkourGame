using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStatus : MonoBehaviour
{
    public bool TriggerEntered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) {
            Debug.Log("TriggerEnter with:" + other.gameObject.name);
            TriggerEntered = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            Debug.Log("TriggerLost with:" + other.gameObject.name);
            TriggerEntered = false;
        }
    }
}

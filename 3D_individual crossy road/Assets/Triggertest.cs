using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggertest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Trigger Enter" + other.name);
    }

    private void OnTriggerStay(Collider other) {
        Debug.Log("Trigger Stay" + other.name);
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log("Trigger Exit" + other.name);
    }
}

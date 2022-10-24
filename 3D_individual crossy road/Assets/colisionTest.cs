using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionTest : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        Debug.Log("Collision Enter" + other.contacts[0].point);
    }

    private void OnCollisionStay(Collision other) {
        Debug.Log("Collision Stay" + other.contacts[0].point);
    }

    private void OnCollisionExit(Collision other) {
        Debug.Log("Collision Exit" + other.contacts[0].point);
    }
}

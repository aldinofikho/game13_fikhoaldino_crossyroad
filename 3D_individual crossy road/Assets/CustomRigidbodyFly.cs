using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomRigidbodyFly : MonoBehaviour
{
    [SerializeField] CustomRigidbody Crb;
    [SerializeField] float force;
    [SerializeField] ForceMode forceMode;

    bool flyKey;
   
    void Update()
    {
        flyKey = Input.GetKey(KeyCode.Space);
        // if (Input.GetKey(KeyCode.Space))
        //     flyKey = true;
    }

    private void FixedUpdate() {
        if (flyKey)
            Crb.AddForce(Vector3.up*force, forceMode);
    }
}

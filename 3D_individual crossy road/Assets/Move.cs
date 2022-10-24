using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float force;
    [SerializeField] float velocity;
    [SerializeField] Method method;
    Vector3 moveDir;

    public enum Method
    {
        Force,
        Velocity
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(horizontal, 0, vertical);

        if (method == Method.Velocity && moveDir != Vector3.zero)
            rb.velocity = moveDir * velocity;
    }

    private void FixedUpdate() {
        // rb.AddForce(moveDir*force, ForceMode.Force);
        if (method == Method.Force && moveDir != Vector3.zero)
            rb.AddForce(moveDir*force, ForceMode.Force);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWalkRun : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float acceleration = 1f;
    [SerializeField] float deceleration = 1f;

    bool isMoving;
    float speed;

    private void Update() {
        if (Input.GetKey(KeyCode.W))
        {
            isMoving = true;
            speed += acceleration * Time.deltaTime;
        }
        else
        {
            isMoving = false;
            speed -= deceleration * Time.deltaTime;
        }

        speed = Mathf.Clamp01(speed);

        animator.SetBool("IsMoving", isMoving);
        animator.SetFloat("Speed", speed);
        
    }
}

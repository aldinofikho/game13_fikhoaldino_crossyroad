using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendWalkRun : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float acceleration = 1f;
    [SerializeField] float deceleration = 0.2f;

    bool isMoving;
    float speed;

    private void Update() {
        if (Input.GetKey(KeyCode.W))
        {
            speed += acceleration * Time.deltaTime;
        }
        else
        {
            speed -= deceleration * Time.deltaTime;
        }

        speed = Mathf.Clamp01(speed);

        isMoving = speed == 0 ? false : transform;

        animator.SetBool("IsMoving", isMoving);
        animator.SetFloat("Speed", speed);
    }
}

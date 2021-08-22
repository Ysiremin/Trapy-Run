using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Animator playerAnimator;

    public float accelerationSpeed;
    public float rotationSpeed;
    public float maxAngle;

    private void FixedUpdate()
    {
        Movement();
        RotateCharacter();
    }

    private void Movement()
    {
        playerAnimator.SetFloat("Speed", 1); //rb.velocity.magnitude
        Vector3 velocity = transform.forward * accelerationSpeed * Time.deltaTime;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }

    private void RotateCharacter()
    {
        if (Mathf.Abs(playerInput.DeltaPosition.x) > 1)
        {
            Vector3 eulerAngle = transform.eulerAngles;
            eulerAngle.y += playerInput.DeltaPosition.x * Time.deltaTime * rotationSpeed * -1;

            if (eulerAngle.y > 180) //left side
            {
                if (eulerAngle.y < 360 - maxAngle)
                {
                    eulerAngle.y = 360 - maxAngle;
                }
            }
            else //right side
            {
                if (eulerAngle.y > maxAngle)
                {
                    eulerAngle.y = maxAngle;
                }
            }
            transform.eulerAngles = eulerAngle;
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
        }
    }
}


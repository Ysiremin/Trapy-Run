using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemy : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private RaysAndDetections raysAndDetections;

    private float accelerationSpeed = 300;
    private float distance;
    private bool gameOver;

    private void FixedUpdate()
    {
        if (gameOver)
        {
            return;
        }

        Movement();

        if (distance < 2)
        {
            StartCoroutine(Catch());
        }

        if (!raysAndDetections.IsLeftDownGround() && !raysAndDetections.IsRightDownGround())
        {
            StartCoroutine(Die());
        }
    }

    private void Movement()
    {
        if (distance > 5)
        {
            accelerationSpeed = (player.accelerationSpeed + 100);
        }
        else if (distance <= 5)
        {
            accelerationSpeed = (player.accelerationSpeed + 50);
        }

        distance = Mathf.Abs(player.transform.position.z - transform.position.z);
        enemyAnimator.SetFloat("Speed", 1);
        Vector3 velocity = transform.forward * accelerationSpeed * Time.deltaTime;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
        transform.eulerAngles = Vector3.forward;
    }

    private IEnumerator Catch()
    {
        gameOver = true;
        accelerationSpeed = 0;
        player.Caught();
        enemyAnimator.SetTrigger("Catch");
        float time = 0.5f;
        float elapsedTime = 0;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = player.transform.position;
        while (elapsedTime <= time)
        {
            endPosition = player.transform.position;
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = endPosition;
    }
    private IEnumerator Die()
    {
        Debug.Log(transform.name + "i died");
        gameOver = true;
        accelerationSpeed = 0;
        yield return new WaitForSeconds(0.5f);
        enemyAnimator.SetTrigger("Fall");
    }
}
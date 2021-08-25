using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemy : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private Rigidbody rb;

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
    }

    private void Movement()
    {
        if (distance > 7)
        {
            accelerationSpeed = (player.accelerationSpeed + 100);
        }
        else if (distance <= 7)
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
    //private void Catch()
    //{
    //    if (distance < 2)
    //    {

    //        accelerationSpeed = 0;
    //        //enemyAnimator.SetTrigger("Catch");
    //        transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.1f);
    //        Debug.Log("sad");
    //    }
    //}
    private IEnumerator Catch()
    {
        gameOver = true;
        accelerationSpeed = 0;
        player.GameOver();
        //enemyAnimator.SetTrigger("Catch");
        Debug.Log("sad");
        float time = 0.3f;
        float elapsedTime = 0;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = player.transform.position;
        while (elapsedTime <= time)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = endPosition;
    }
}

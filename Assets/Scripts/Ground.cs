using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private Color fallingColor;
    private Renderer rnd;
    private float fallSpeed;
    private bool isFall;

    private void Start()
    {
        rnd = transform.GetComponent<Renderer>();
        fallingColor = Color.Lerp(Color.white, Color.red, 0.6f);
        fallSpeed = 0.1f;
    }
    private void Update()
    {
        if (isFall)
        {
            StartCoroutine(Fall());
        }
    }
    public void FallTrigger()
    {
        rnd.material.color = fallingColor;
        isFall = true;
    }
    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(0.1f);
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        fallSpeed += 0.15f;
    }
}

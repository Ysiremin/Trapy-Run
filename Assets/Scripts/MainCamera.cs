using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    private void Update()
    {
        Vector3 pos = playerInput.transform.position + Vector3.up * 8 + Vector3.back * 19;
        transform.position = pos;
    }
}
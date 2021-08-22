using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector2 currentPosition;
    private Vector2 lastPosition;
    private Vector2 deltaPosition;
    public bool OnDown;
    public bool OnUp;
    public Vector2 DeltaPosition { get => deltaPosition; }
    private void Update()
    {
        OnDown = OnUp = false;

        if (Input.GetMouseButtonDown(0))
        {
            OnDown = true;
            lastPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
            OnUp = true;

        if (Input.GetMouseButton(0))
        {
            currentPosition = Input.mousePosition;
            deltaPosition = lastPosition - currentPosition;
            lastPosition = currentPosition;
        }
    }
}

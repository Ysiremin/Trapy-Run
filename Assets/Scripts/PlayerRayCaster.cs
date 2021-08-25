using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCaster : MonoBehaviour
{
    [SerializeField] RaysAndDetections raysAndDetections;
    [SerializeField] PlayerMovement player; 

    private void Update()
    {
        if (player.GameOver)
        {
            return;
        }
        if (raysAndDetections.IsLeftDownGround() || raysAndDetections.IsRightDownGround())
        {
            raysAndDetections.RightGroundInfo().FallTrigger();
            raysAndDetections.LeftGroundInfo().FallTrigger();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCaster : MonoBehaviour
{
    [SerializeField] RaysAndDetections raysAndDetections;

    private void Update()
    {
        if (raysAndDetections.IsLeftDownGround() || raysAndDetections.IsRightDownGround())
        {
            raysAndDetections.RightGroundInfo().FallTrigger();
            raysAndDetections.LeftGroundInfo().FallTrigger();
        }
    }
}

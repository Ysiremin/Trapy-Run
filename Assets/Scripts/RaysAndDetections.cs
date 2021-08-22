using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaysAndDetections : MonoBehaviour
{
    private RaycastHit RightDownRayHit()
    {
        var direction = Vector3.down;
        Physics.Raycast(transform.position + Vector3.up + Vector3.right * 0.2f, direction, out RaycastHit raycastHit, 2f);
        return raycastHit;
    }
    private RaycastHit LeftDownRayHit()
    {
        var direction = Vector3.down;
        Physics.Raycast(transform.position + Vector3.up + Vector3.left * 0.2f, direction, out RaycastHit raycastHit, 2f);
        return raycastHit;
    }
    public bool IsRightDownGround()
    {
        var raycastHit = RightDownRayHit();
        if (raycastHit.collider != null)
        {
            return raycastHit.transform.TryGetComponent(out Ground ground);
        }
        return false;
    }
    public bool IsLeftDownGround()
    {
        var raycastHit = LeftDownRayHit();
        if (raycastHit.collider != null)
        {
            return raycastHit.transform.TryGetComponent(out Ground ground);
        }
        return false;
    }
    public Ground RightGroundInfo()
    {
        var raycastHit = RightDownRayHit();
        if (raycastHit.transform.TryGetComponent(out Ground ground))
        {
            return ground;
        }
        return null;
    }
    public Ground LeftGroundInfo()
    {
        var raycastHit = LeftDownRayHit();
        if (raycastHit.transform.TryGetComponent(out Ground ground))
        {
            return ground;
        }
        return null;
    }
}

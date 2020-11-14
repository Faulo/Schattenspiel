using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Extensions;

public class Movable : MonoBehaviour {
    private const float BOUNDINGBOX_SCALE = 0.9f;

    public bool CanMoveTo(Vector3 target) {
        return CanMoveBy(transform.position - target);
    }

    public bool CanMoveBy(Vector3 movement) {
        var colliders = GetComponents<Collider>()
            .Union(GetComponentsInChildren<Collider>());
        return colliders
            .Select(collider => collider.bounds)
            .SelectMany(bounds => Physics.OverlapBox(bounds.center + movement, bounds.extents * BOUNDINGBOX_SCALE, transform.rotation))
            .Except(colliders)
            .Where(collider => collider.gameObject.tag != "Ground") //öhh
            .None();
    }
}

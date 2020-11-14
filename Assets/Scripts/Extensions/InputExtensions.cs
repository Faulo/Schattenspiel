using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputExtensions
{
    public static Vector3 localMousePosition {
        get {
            var backdrop = GameObject.FindGameObjectWithTag("Ground").GetComponent<Collider>();
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (backdrop.Raycast(ray, out var info, float.PositiveInfinity)) {
                return info.point;
            } else {
                return default;
            }
        }
    }
}

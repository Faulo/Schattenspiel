using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        var plane = new Plane(Vector3.up, transform.position);
        // create a ray from the mousePosition
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // plane.Raycast returns the distance from the ray start to the hit point
        //float distance;
        if (plane.Raycast(ray, out var distance)) {
            // some point of the plane was hit - get its coordinates
            var hitPoint = ray.GetPoint(distance);
            // use the hitPoint to aim your cannon
            transform.position = hitPoint;
        }

        if (Input.GetMouseButton(0)) {
            transform.Translate(new Vector3(0, Time.deltaTime, 0));
        }
        if (Input.GetMouseButton(1)) {
            transform.Translate(new Vector3(0, -Time.deltaTime, 0));
        }



        /*
        Debug.Log(Input.mousePosition);
        Vector3 temp = Input.mousePosition;
        temp.z = 4f;
        temp = Camera.main.ScreenToWorldPoint(temp);
        //temp.y = 1f;
        transform.position = temp;
        //*/
    }
}

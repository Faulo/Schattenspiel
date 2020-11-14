using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private new Rigidbody rigidbody {
       get {
            return GetComponent<Rigidbody>();
       }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(FindObjectOfType<Camera>().transform);
        rigidbody.velocity = transform.forward;
    }
}

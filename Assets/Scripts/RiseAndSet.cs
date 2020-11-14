using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseAndSet : MonoBehaviour
{
    public float radius = 1;
    public float speed = 1;
    private Vector3 offset;
    private Light lightSource;

    void Start() {
        offset = transform.position;
        lightSource = GetComponentInChildren<Light>();
    }

    void Update()
    {
        float x = - radius * Mathf.Sin(2 * Mathf.PI * GameController.instance.scaledTime);
        float y = - radius * Mathf.Cos(2 * Mathf.PI * GameController.instance.scaledTime);

        transform.position = offset + new Vector3(x, y, 0);
        lightSource.gameObject.SetActive(transform.position.y > 0);
    }
}

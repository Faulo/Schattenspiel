using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightDetector : MonoBehaviour {
    public bool isLit {
        get {
            return lights
                .Where(light => {
                    if (Physics.Raycast(light.transform.position, transform.position - light.transform.position, out var hit)) {
                        return hit.collider.gameObject == gameObject;
                    } else {
                        return false;
                    }
                })
                .Any();
        }
    }
    private IEnumerable<Light> lights {
        get {
            return FindObjectsOfType<Light>()
                .Where(light => light.transform.position.y > 0);
        }
    }
    private Animator animator;
    private void Start() {
        animator = GetComponent<Animator>();
    }
    private void Update() {
        animator.SetBool("isLit", isLit);
    }
}

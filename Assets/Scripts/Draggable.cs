using Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Movable))]
public class Draggable : MonoBehaviour {
    private bool followPointer = false;
    private Vector3 followOffset;
    private Draggable parentDraggable;
    private bool hasMoved = false;

    // Start is called before the first frame update
    void Start() {
        parentDraggable = transform.parent.GetComponent<Draggable>();
    }

    // Update is called once per frame
    void Update() {
        if (followPointer) {
            if (hasMoved) {
                hasMoved = false;
                return;
            }
            Vector3 block = followOffset;
            Vector3 mouse = InputExtensions.localMousePosition;
            Vector3 movement;
            
            movement = new Vector3(
                0,
                0,
                Mathf.Clamp(Mathf.RoundToInt(mouse.z - block.z), -1, 1)
            );
            if (movement != Vector3.zero && GetComponent<Movable>().CanMoveBy(movement)) {
                transform.position += movement;
                followOffset += movement;
                hasMoved = true;
                return;
            }

            movement = new Vector3(
                Mathf.Clamp(Mathf.RoundToInt(mouse.x - block.x), -1, 1),
                0,
                0
            );
            if (movement != Vector3.zero && GetComponent<Movable>().CanMoveBy(movement)) {
                transform.position += movement;
                followOffset += movement;
                hasMoved = true;
                return;
            }
        }
    }

    public void OnMouseDown() {
        if (parentDraggable == null) {
            followPointer = true;
            followOffset = InputExtensions.localMousePosition;
        } else {
            parentDraggable.OnMouseDown();
        }
    }

    public void OnMouseUp() {
        if (parentDraggable == null) {
            followPointer = false;
        } else {
            parentDraggable.OnMouseUp();
        }
    }
}

using Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Vampire : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 1;

    [SerializeField]
    private float wateringRange = 1;

    private Animator animator;
    private Movable movable;
    private bool isMoving = false;
    public bool isAlive {
        get {
            return currentLife > 0;
        }
    }

    private float currentLife = 0;
    private float maximumLife = 5;
    private IBar lifeBar;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        movable = GetComponent<Movable>();
        lifeBar = transform.Find("LifeBar").GetComponent<IBar>();
        currentLife = maximumLife;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive) {
            if (isMoving) {
                var movement = transform.forward * Time.deltaTime * moveSpeed;
                if (movable.CanMoveBy(movement)) {
                    transform.position += movement;
                } else {
                    transform.Rotate(0, 90, 0);
                }
            }
            Physics.OverlapSphere(transform.position, wateringRange)
                .Select(collider => collider.transform.parent)
                .SelectMany(parent => parent.GetComponents<Flower>())
                .ForAll(flower => flower.WaterBy(Time.deltaTime));
        }
        lifeBar.size = Mathf.Max(currentLife, 0) / maximumLife;
    }

    public void OnMouseDown() {
        isMoving = !isMoving;
    }

    public void BurnBy(float delta) {
        currentLife -= delta;
    }
}

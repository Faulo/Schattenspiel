using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour {
    private Transform plant;

    [SerializeField]
    private Vector3 growthSpeed = new Vector3(0.01f, 0.1f, 0.01f);

    [SerializeField]
    private float currentGrowth = 0;

    [SerializeField]
    private float maximumGrowth = 8;

    private IBar growthBar;

    [SerializeField]
    private float currentWater = 0;

    [SerializeField]
    private float maximumWater = 6;

    private IBar waterBar;

    public bool isGrown {
        get {
            return currentGrowth >= maximumGrowth;
        }
    }

    // Start is called before the first frame update
    void Start() {
        plant = transform.Find("Plant");
        growthBar = transform.Find("GrowthBar").GetComponent<IBar>();
        waterBar = transform.Find("WaterBar").GetComponent<IBar>();
    }

    // Update is called once per frame
    void Update() {
        growthBar.size = currentGrowth / maximumGrowth;
        waterBar.size = currentWater / maximumWater;
    }

    public void GrowBy(float delta) {
        delta = Mathf.Min(delta, currentWater);
        delta = Mathf.Min(delta, maximumGrowth - currentGrowth);
        if (delta > 0) {
            currentWater -= delta;
            currentGrowth += delta;

            plant.localScale = growthSpeed * currentGrowth;
        }
    }
    public void WaterBy(float delta) {
        currentWater = Mathf.Min(currentWater + delta, maximumWater);
    }
}

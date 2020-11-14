using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalBar : MonoBehaviour, IBar {
    [SerializeField]
    private float initialSize = 1;

    [SerializeField]
    private Color initialColor = Color.white;

    public float size {
        set {
            bar.localScale = new Vector3(value, 1f, 1f);
        }
        get {
            return bar.localScale.x;
        }
    }

    public Color color {
        get {
            return barSprite.color;
        }
        set {
            barSprite.color = new Color(value.r, value.g, value.b, barSprite.color.a);
            backgroundSprite.color = new Color(value.r, value.g, value.b, backgroundSprite.color.a);
        }
    }

    private SpriteRenderer backgroundSprite;
    private Transform bar;
    private SpriteRenderer barSprite;

    // Start is called before the first frame update
    void Start() {
        backgroundSprite = transform.Find("Background").GetComponent<SpriteRenderer>();
        bar = transform.Find("Bar");
        barSprite = bar.Find("BarSprite").GetComponent<SpriteRenderer>();

        size = initialSize;
        color = initialColor;
    }
}

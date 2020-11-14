using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    private TextMeshProUGUI gui {
        get {
            return GetComponent<TextMeshProUGUI>();
        }
    }
    private string format;

    // Start is called before the first frame update
    void Start() {
        format = gui.text;
    }

    // Update is called once per frame
    void Update() {
        gui.text = GameController.instance.FormatScore(format);
    }
}

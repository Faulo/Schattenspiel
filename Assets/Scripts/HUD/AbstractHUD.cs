using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractHUD : MonoBehaviour
{
    protected GameController game {
        get {
            return transform.parent.GetComponent<GameController>();
        }
    }

    public bool visible {
        get {
            return GetComponent<Canvas>().enabled;
        }
        set {
            GetComponent<Canvas>().enabled = value;
        }
    }
}

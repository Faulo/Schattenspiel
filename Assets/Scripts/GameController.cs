using Extensions;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController instance { get; private set; }

    [SerializeField]
    private TextAsset[] levelsToLoad;

    public Animator animator { get; private set; }
    public LevelController levelController { get {
            return GetComponent<LevelController>();
        }
    }

    [SerializeField]
    private int dayLength = 1;

    private float unscaledTime = 0;
    public float scaledTime {
        get {
            return unscaledTime / dayLength;
        }
    }
    private IEnumerable<Animator> flowers {
        get {
            return GameObject.FindGameObjectsWithTag("Plant")
                .SelectMany(plant => plant.GetComponents<Animator>());
        }
    }
    private IEnumerable<Animator> vampires {
        get {
            return GameObject.FindGameObjectsWithTag("Vampire")
                .SelectMany(plant => plant.GetComponents<Animator>());
        }
    }
    public string FormatTime(string format) {
        var time = Mathf.RoundToInt(scaledTime * 86400);
        var timeSpan = TimeSpan.FromSeconds(time);
        return string.Format(format, timeSpan.Hours, timeSpan.Minutes);
    }
    public int currentFlowers {
        get {
            return flowers
                .Where(animator => animator.GetBool("hasBlossomed"))
                .Count();
        }
    }
    public int maximumFlowers {
        get {
            return SessionData.currentLevelData.flowerCount;
        }
    }
    public int currentVampires {
        get {
            return vampires
                .Where(animator => !animator.GetBool("isDead"))
                .Count();
        }
    }
    public int maximumVampires {
        get {
            return SessionData.currentLevelData.vampireCount;
        }
    }
    public bool hasWon {
        get {
            return flowers
                .Where(animator => !animator.GetBool("hasBlossomed"))
                .None();
        }
    }
    public string FormatScore(string format) {
        return string.Format(format, currentFlowers, maximumFlowers, currentVampires, maximumVampires);
    }
    public string FormatTitle(string format) {
        return string.Format(format, SessionData.currentLevel + 1, SessionData.currentLevelData.title);
    }
    public string FormatMission(string format) {
        return string.Format(format, SessionData.currentLevelData.flowerCount, SessionData.currentLevelData.vampireCount);
    }

    // Start is called before the first frame update
    void Awake() {
        if (instance != null) {
            throw new Exception("2 GameControllers?!");
        }
        instance = this;
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (animator.GetBool("isPlaying")) {
            unscaledTime += Time.deltaTime;
            while (unscaledTime > dayLength) {
                unscaledTime -= dayLength;
            }
            animator.SetBool("hasWon", hasWon);
        }
    }

    public LevelData FetchLevelData(int index) {
        if (index >= GameController.instance.levelsToLoad.Length) {
            throw new FileNotFoundException("levelsToLoad does not have a level " + index);
        }
        if (levelsToLoad[index].text == "") {
            throw new FileNotFoundException("levelsToLoad file " + index + " is empty ?");
        }
        return JsonConvert.DeserializeObject<LevelData>(levelsToLoad[index].text);
    }

    public MenuHUD menu {
        get {
            return FindObjectOfType<MenuHUD>();
        }
    }
    public LevelHUD level {
        get {
            return FindObjectOfType<LevelHUD>();
        }
    }
    public WinHUD win {
        get {
            return FindObjectOfType<WinHUD>();
        }
    }
}

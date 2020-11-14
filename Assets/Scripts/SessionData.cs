using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SessionData
{
    public static int currentLevel { get {
            return currentLevel_;
        }
        set {
            if (currentLevel_ != value) {
                currentLevel_ = value;
                currentLevelData_ = null;
            }
        }
    }
    private static int currentLevel_ = 0;

    public static LevelData currentLevelData {
        get {
            if (currentLevelData_ == null) {
                if (GameController.instance == null) {
                    Debug.Log("Trying to access GameController.instance before it exists!");
                }
                currentLevelData_ = GameController.instance.FetchLevelData(currentLevel);
            }
            return currentLevelData_;
        }
    }
    private static LevelData currentLevelData_;
}

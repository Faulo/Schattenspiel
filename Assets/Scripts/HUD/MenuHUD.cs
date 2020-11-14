using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHUD : AbstractHUD {
    public void OnPlay() {
        game.levelController.LoadLevel();
        game.animator.SetBool("isPlaying", true);
    }

    // Start is called before the first frame update
    void Start()
    {
        var data = SessionData.currentLevelData;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

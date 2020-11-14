using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinHUD : AbstractHUD
{
    public void OnConfirm() {
        game.levelController.UnloadLevel();
        SessionData.currentLevel++;
        game.animator.SetBool("isPlaying", false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

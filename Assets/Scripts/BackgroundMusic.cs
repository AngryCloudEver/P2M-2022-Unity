using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic bgm;
    private void Awake() {
        if(bgm!=null){
            Destroy(gameObject);
        }
        else{
            bgm = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}

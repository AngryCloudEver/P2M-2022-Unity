using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic bgm;
    public AudioSource bgmAudioSource;
    private void Awake() {
        if(bgm!=null){
            Destroy(gameObject);
        }
        else{
            bgm = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Update() {
        if(PlayerPrefs.HasKey("bgmVolume")){
            float bgmVolume = PlayerPrefs.GetFloat("bgmVolume",0.5f);
            bgmAudioSource.volume = bgmVolume;
        }
        
    }
}

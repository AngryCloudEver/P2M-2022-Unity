using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioSettings : MonoBehaviour
{
    
    public Slider bgmSlider,sfxSlider;
    public Text bgmText,sfxText;
    
    private void Awake() {
        LoadVolume();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LoadVolume(){
        bgmSlider.value = PlayerPrefs.GetFloat("bgmVolume",0.5f);
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume",0.5f);
        UpdateAudioDisplay();
    }
    public void UpdateBGMVolume(){
        float bgmValue = bgmSlider.value;
        PlayerPrefs.SetFloat("bgmVolume", bgmValue);
        UpdateBGMDisplay();
    }
    public void UpdateSFXVolume(){
        float sfxValue = sfxSlider.value;
        PlayerPrefs.SetFloat("sfxVolume", sfxValue);
        UpdateSFXDisplay();
    }
    void UpdateBGMDisplay(){
        int tempBgmValue = (int)(bgmSlider.value*100);
        bgmText.text = tempBgmValue.ToString();
    }
    void UpdateSFXDisplay(){
        int tempSfxValue = (int)(sfxSlider.value*100);
        sfxText.text = tempSfxValue.ToString();
    }
    void UpdateAudioDisplay(){
        UpdateBGMDisplay();
        UpdateSFXDisplay();
    }
    
}

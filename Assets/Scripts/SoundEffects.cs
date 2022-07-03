using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource hoverAudioSource,pickAudioSource,positiveAudioSource,negativeAudioSource,winAudioSource,loseAudioSource,newDayAudioSource;
    public float volume;

    private void Awake() {
        volume = PlayerPrefs.GetFloat("sfxVolume",0.5f);
    }
    
    private void Update() {
        volume = PlayerPrefs.GetFloat("sfxVolume",0.5f);
    }
    
    public void PlayHover(){
        hoverAudioSource.PlayOneShot(hoverAudioSource.clip,volume);
    }
    public void PlayPick(){
        pickAudioSource.PlayOneShot(pickAudioSource.clip,volume);
    }
    public void PlayPositive(){
        positiveAudioSource.PlayOneShot(positiveAudioSource.clip,volume);
    }
    public void PlayNegative(){
        negativeAudioSource.PlayOneShot(negativeAudioSource.clip,volume);
    }
    public void PlayWin(){
        winAudioSource.PlayOneShot(winAudioSource.clip,volume);
    }
    public void PlayLose(){
        loseAudioSource.PlayOneShot(loseAudioSource.clip,volume);
    }
    public void PlayNewDay(){
        newDayAudioSource.PlayOneShot(newDayAudioSource.clip,volume);
    }
}

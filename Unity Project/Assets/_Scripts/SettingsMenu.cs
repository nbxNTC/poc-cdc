using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SettingsMenu : MonoBehaviour
{

    [SerializeField]
    private AudioMixer _audioMixer;
    
    public void SetVolume(float volume) {
        _audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(float qualityIndex) {
        switch((int)qualityIndex) {            
            case 0: 
                QualitySettings.SetQualityLevel(0);
            break;
            case 1: 
                QualitySettings.SetQualityLevel(1);
            break;
            case 2: 
                QualitySettings.SetQualityLevel(2);
            break;
            default: 
                QualitySettings.SetQualityLevel(0);
            break;
        }
    }

}

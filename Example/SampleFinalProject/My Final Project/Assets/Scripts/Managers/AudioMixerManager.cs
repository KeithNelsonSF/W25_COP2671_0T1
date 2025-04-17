using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerManager : MonoBehaviour
{   
    [SerializeField] AudioMixer Master;
    [SerializeField] AudioMixerGroup SfxChannel;
    [SerializeField] AudioMixerGroup AchievementChannel;
    [SerializeField] AudioMixerGroup BackgroundChannel;

    bool muteSfx => sfxVolume > 0;
    float sfxVolume;
    float masterVolume;
    bool muteMaster => masterVolume > 0;

    private void Start()
    {
        SfxChannel.audioMixer.GetFloat("SFX", out sfxVolume);
        Master.GetFloat("Master", out masterVolume);
    }
    public void ToggleMasterChannel() 
    {
        if (muteMaster)
        {
            Master.SetFloat("Master", 0);
        }
        else
        {
            Master.SetFloat("Master", masterVolume);
        }
    }
    public void SetMasterVolume(float volumeLevel) 
    {
        Master.SetFloat("Master", volumeLevel);
        masterVolume = volumeLevel;
    }
    public void ToggleSfxChannel() 
    {
        if (muteSfx)
        {   
            SfxChannel.audioMixer.SetFloat("SFX", 0);
        }
        else
        {
            SfxChannel.audioMixer.SetFloat("SFX", sfxVolume);
        }
    }

}

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
    bool muteMaster = false;

    private void Start()
    {
        SfxChannel.audioMixer.GetFloat("SFXVol", out sfxVolume);
        Master.GetFloat("MasterVol", out masterVolume);
    }
    public void ToggleMasterChannel() 
    {
        AudioMixerSnapshot snap;
        if (muteMaster)
        {
            snap = Master.FindSnapshot("Snapshot - Mute Master");
        }
        else
        {
            snap = Master.FindSnapshot("Snapshot - DEFAULT");
        }
        snap.TransitionTo(0.2f);
    }
    public void SetMasterVolume(float volumeLevel) 
    {
        var volume = Mathf.Log10(volumeLevel) * 20;
        Master.SetFloat("MasterVol", volume);
        masterVolume = volume;
    }
    public void ToggleSfxChannel() 
    {
        Debug.Break();
        if (muteSfx)
        {   
            SfxChannel.audioMixer.SetFloat("SFXVol", 0);
        }
        else
        {
            SfxChannel.audioMixer.SetFloat("SFXVol", sfxVolume);
        }
    }

}

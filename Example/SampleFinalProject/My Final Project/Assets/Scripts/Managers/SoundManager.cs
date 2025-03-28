using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private float musicLevel;
    [SerializeField] AudioMixerGroup mixerGroup;

    public void AlterMusicVolume()
    {
        //mixerGroup.audioMixer.SetFloat("Volume", musicLevel);
    }
}

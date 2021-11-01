using UnityEngine;
using UnityEngine.Audio;
public class SoundVolume : MonoBehaviour
{
    [SerializeField]private AudioMixer mixer;
    public void SetMasterVolume(float vol)
    { mixer.SetFloat("Volume",Mathf.Log10(vol)*20);
       // mixer.SetFloat("Pitch",vol);
    }
}

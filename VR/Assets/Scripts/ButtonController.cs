using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void PlayStop()
    {
        AudioManager.instance.PlayStop();
   
    }

    public void NextTrack()
    {
        AudioManager.instance.NextTrack();
    }
    
    public void PrevTrack()
    {
        AudioManager.instance.PrevTrack();
    }

}

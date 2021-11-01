using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Milsugi : MonoBehaviour
{
    private GameObject[] allLights;
    private bool lightsOpen;
    void Start()
    {
        lightsOpen = true;
        allLights = GameObject.FindGameObjectsWithTag("Light");
    }

    // public void milsugis()
    // {
    //     AudioManager.instance.PitchChange(-1);
    //     Debug.Log("PitchChanger-1");
    // } 
    // public void milbei()
    // {
    //     AudioManager.instance.PitchChange(2);
    //     Debug.Log("PitchChanger+1");
    // }
    
    public void CloseLights()
    {
        if (lightsOpen)
        {
            foreach (var l in allLights)
            {
                l.SetActive(false);
            }

            lightsOpen = false;
        }
        else
        {
            foreach (var l in allLights)
            {
                l.SetActive(true);
            }

            lightsOpen = true;
        }
    }
    
}

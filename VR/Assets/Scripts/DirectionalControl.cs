using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalControl : MonoBehaviour
{
    [SerializeField] private Light directional;
    private bool opened;

    private void Start()
    {
        opened = false;
    }

    public void ToggleDirectional()
    {
        if (opened)
        {
            opened = false;
            directional.intensity = 0.2f;
            
        }
        else
        {
            opened = true;
            directional.intensity = 0.9f;
        }
        
    }
}

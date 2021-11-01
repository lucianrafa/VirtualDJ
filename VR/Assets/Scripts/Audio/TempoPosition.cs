using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempoPosition : MonoBehaviour
{
    // Start is called before the first frame update
[Tooltip("Configurable Joint limit e global nu local;trebuie schimbat cu scaleup")]
    [SerializeField] private Slider sld;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float pos = Math.Abs(transform.localPosition.z);
        float pp = pos * 100;
        //Debug.Log("Local position--- "+pp);
        sld.value = pp * 2;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{

    [SerializeField] private float treshhold=0.1f;
    [SerializeField] private float deadzone = 0.025f;

    private bool ispressed;
    private Vector3 startPosition;
    private ConfigurableJoint _joint;
    public UnityEvent onPressed, onRelease;

    void Start()
    {
        startPosition = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!ispressed&&GetValue()+treshhold>=1)
            Pressed();
        if(ispressed&&GetValue()-treshhold<=0)
            Release();
    }


    private float GetValue()
    {
        var value = Vector3.Distance(startPosition, transform.localPosition) / _joint.linearLimit.limit;

        if (Math.Abs(value) < deadzone)
            value = 0;
        return Mathf.Clamp(value, -1f, 1f);
    }
    private void Pressed()
    {
        ispressed = true;
        onPressed.Invoke();
       // Debug.Log("Pressed");
        
    }

    private void Release()
    {

        ispressed = false;
        onRelease.Invoke();
        //Debug.Log("Released");

    }
    
}

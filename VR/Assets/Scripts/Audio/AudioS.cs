using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioS : MonoBehaviour
{
    private int currentRotation;
    private int newRotation;
    [SerializeField]private AudioSource mixer;
    private float delay;
    void Start()
    {
        //currentRotation = transform.rotation.y;
        currentRotation = Mathf.RoundToInt(transform.rotation.normalized.y);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // delay = Time.deltaTime;
        // newRotation = Mathf.RoundToInt(transform.rotation.normalized.y*100);
        // if(currentRotation==newRotation)
        // {
        //     mixer.pitch=1;
        //     Debug.Log("nimic");
        // }
        // else if (currentRotation > newRotation)
        // {
        //     mixer.pitch=-1;
        //     currentRotation = newRotation;
        // }
        // else if (currentRotation < newRotation)
        // {
        //     mixer.pitch=1.2f;
        //     currentRotation = newRotation;
        // }

    }
}

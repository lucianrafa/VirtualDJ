using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOnOff : MonoBehaviour
{
    private GameObject[] allLights;

    void Start () {
        
        allLights= GameObject.FindGameObjectsWithTag ("Light");
        
        // foreach (GameObject i in allLights){
        //     i.SetActive(false);
        // }
    
    }

    
}

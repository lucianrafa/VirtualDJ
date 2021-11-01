using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameObj : MonoBehaviour
{

    [SerializeField] private GameObject obj;

    public void ToggleGameOjb()
    {
        if (obj.activeSelf)
        {
            obj.SetActive(false);
        }
        else
        {
            obj.SetActive(true);
        }
    }
}

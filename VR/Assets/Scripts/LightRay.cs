using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRay : MonoBehaviour
{

    [SerializeField]
    private Transform target;
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0,target.position);
    }
    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0,target.position);
        lineRenderer.SetPosition(1,transform.position);
    }
}

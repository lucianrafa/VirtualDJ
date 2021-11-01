using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSyncColor : AudioSyncer
{

    public Material mat;
    public float beatEmission;
    public float restEmission;

    private int m_randomIndx;

    private IEnumerator MoveToColor(float _target)
    {
        float _curr = mat.GetFloat("Vector1_df5303ff35f44c70ad33117e36a147a5");
        float _initial = _curr;
        float _timer = 0;
		
        while (_curr != _target)
        {
            _curr = Mathf.Lerp(_initial, _target, _timer / timeToBeat);
            _timer += Time.deltaTime;

            mat.SetFloat("Vector1_df5303ff35f44c70ad33117e36a147a5",_curr);

            yield return null;
        }

        m_isBeat = false;
    }

    // private Color RandomColor()
    // {
    //     if (beatColors == null || beatColors.Length == 0) return Color.white;
    //     m_randomIndx = Random.Range(0, beatColors.Length);
    //     return beatColors[m_randomIndx];
    // }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (m_isBeat) return;

        float ems = Mathf.Lerp(mat.GetFloat("Vector1_df5303ff35f44c70ad33117e36a147a5"), restEmission, restSmoothTime * Time.deltaTime);
        mat.SetFloat("Vector1_df5303ff35f44c70ad33117e36a147a5",ems);
    }

    public override void OnBeat()
    {
        base.OnBeat();

        float _c = beatEmission;

        StopCoroutine("MoveToColor");
        StartCoroutine("MoveToColor", _c);
    }

    // private void Start()
    // {
    //     mat = GetComponent<Image>();
    // }

    
}
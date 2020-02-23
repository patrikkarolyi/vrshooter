using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Material))]
public class AudioSyncColor : AudioSyncer
{
    public Material colorfulMat;
    public Color[] beatColors;
    public Color restColor;

    private int m_randomIndx;


    private IEnumerator MoveToColor(Color _target)
    {
        Color _curr = colorfulMat.GetColor("Color_FD583773");
        Color _initial = _curr;
        float _timer = 0;

        while (_curr != _target)
        {
            _curr = Color.Lerp(_initial, _target, _timer / timeToBeat);
            _timer += Time.deltaTime;

            //colorfulMat.color = _curr;
            colorfulMat.SetColor("Color_FD583773",_curr);

            yield return null;
        }

        m_isBeat = false;
    }

    private Color RandomColor()
    {
        if (beatColors == null || beatColors.Length == 0) return Color.white;
        m_randomIndx = Random.Range(0, beatColors.Length);
        return beatColors[m_randomIndx];
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (m_isBeat) return;

        //colorfulMat.color = Color.Lerp(colorfulMat.color, restColor, restSmoothTime * Time.deltaTime);
        colorfulMat.SetColor("Color_FD583773",Color.Lerp(colorfulMat.GetColor("Color_FD583773"), restColor, restSmoothTime * Time.deltaTime));
    }

    public override void OnBeat()
    {
        base.OnBeat();

        Color _c = RandomColor();

        StopCoroutine("MoveToColor");
        StartCoroutine("MoveToColor", _c);
    }


}
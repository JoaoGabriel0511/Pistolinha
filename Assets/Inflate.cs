using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inflate : MonoBehaviour
{
    [SerializeField] AnimationCurve _curve;
    [SerializeField] float _duration = 1;
    float _timer = 0;
    bool _doInflate = false;
    public void Update()
    {
        if (!_doInflate)
            return;

        _timer = Mathf.Clamp(_timer + Time.deltaTime, 0, _duration);

        transform.localScale = Vector3.one * _curve.Evaluate(_timer);

        if(_timer >= _duration)
        {
            _doInflate = false;
            _timer = 0;
        }
    }

    public void StartInflate()
    {
        _timer = 0;
        _doInflate = true;
    }
}

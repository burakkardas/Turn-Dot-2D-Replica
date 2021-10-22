using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake_Controller : MonoBehaviour
{
    [SerializeField] private Transform _cam;
    [SerializeField] private Vector3 _startPos;
    
    [SerializeField] private float _shakePower;
    [SerializeField] private float _shakeDuration;
    private float _initialDuration;
    [SerializeField] private float _downAmount;
    public bool _isShake = false;

    void Start()
    {
        _cam = Camera.main.transform;
        _startPos = _cam.localPosition;
        _initialDuration = _shakeDuration;
    }

    void Update()
    {
        if(_isShake) {
            if(_shakeDuration > 0) {
                _cam.localPosition = _startPos + Random.insideUnitSphere * _shakePower  ;
                _shakeDuration -= _downAmount * Time.deltaTime;
            }
            else {
                _isShake = false;
                _cam.localPosition = _startPos;
                _shakeDuration = _initialDuration;
            }
        }
    }
}

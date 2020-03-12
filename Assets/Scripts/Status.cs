using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    private static Image _madness;
    [SerializeField]
    private GameObject bomb;
    
    [SerializeField]
    private Text _text;

    private static float _maxMadness;
    private static float _currentMadness;

    public float MaxMadness
    {
        get { return _maxMadness; }
        set
        {
            _maxMadness = value;
            _currentMadness = value;
        }
    }

    public float CurrentMadness
    {
        get { return _currentMadness; }
        set
        {
            if (value > _maxMadness) _currentMadness = _maxMadness;
            else if (value < 0) _currentMadness = 0;
            else _currentMadness = value;
        }
    }

    // Start is called before the first frame update
    void Start()

    {
        if (_madness == null)
            _madness = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((int) _currentMadness != 0)
            _madness.fillAmount = _currentMadness / _maxMadness;
        else
        {
            _madness.fillAmount = 0;
            _text.enabled = true;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime;
    public string saveTime;
    public float startingTime = 0f;

    [SerializeField] public Text _timeText;
    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {
        _TimeCount();
    }

    public void _TimeCount()
    {
        currentTime += 1 * Time.deltaTime;
        _timeText.text = currentTime.ToString("0");
        saveTime= currentTime.ToString("0");
    }

    public string _aaa()
    {
        return saveTime;
    }
}

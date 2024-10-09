using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeDisplay : MonoBehaviour
{
    [SerializeField] private Text timeText;

    private void Start()
    {
        InvokeRepeating("UpdateTime", 0f, 1f);
    }

    private void UpdateTime()
    {
        DateTime currentTime = DateTime.Now;
        timeText.text = currentTime.ToString("HH:mm");
    }
}

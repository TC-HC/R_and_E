using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Input_angular_speed : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    public static double mortor_angular_speed = 10;

    public void OnEndEditEvent(string str)
    {
        double.TryParse(str, out mortor_angular_speed);
        if(str != null)
        {
            Debug.Log("모터 각속도 : " + (double)mortor_angular_speed);
        }
    }
}

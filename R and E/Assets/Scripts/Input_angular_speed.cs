using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Input_angular_speed : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    public static double mortor_angular_speed = 0;

    public void OnEndEditEvent(string str)
    {
        mortor_angular_speed = Convert.ToDouble(str);
        Debug.Log("���� ���ӵ� : "+ mortor_angular_speed);
    }
}

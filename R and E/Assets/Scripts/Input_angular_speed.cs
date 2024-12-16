using Chain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Input_angular_speed : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    public static double motor_angular_speed = 0;
    public static double Radius = 0;

    public void OnEndEditEvent(string str)
    {
        double.TryParse(str, out motor_angular_speed);
        if (str != null)
        {
            int size = Sort_Cogs.size;
            Sort_Cogs.cogs_array[size - 1].angular_speed = motor_angular_speed;
            for (int i = 0; i < size - 1; i++)
            {
                Sort_Cogs.cogs_array[i].angular_speed = (Sort_Cogs.cogs_array[size-1].Data.Radius / Sort_Cogs.cogs_array[i].Data.Radius) * Sort_Cogs.cogs_array[size-1].angular_speed;
                Debug.Log(i + "번째 기어의 각속도 : " + Sort_Cogs.cogs_array[i].angular_speed);
            }
        }
    }
}

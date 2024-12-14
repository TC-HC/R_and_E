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
    public static double motor_angular_speed = 10;
    public static double Radius = 0;

    public void OnEndEditEvent(string str)
    {
        Calculate_Power calculate_Power = FindObjectOfType<Calculate_Power>();
        double.TryParse(str, out motor_angular_speed);
        if (str != null)
        {
            Debug.Log("모터 각속도 : " + (double)motor_angular_speed);
            calculate_Power.Calculate_cogs();
            Cogwheel[] Cogs_array = Calculate_Power.cogs_array;
            Cogs_array[Cogs_array.Length - 1].angular_speed = motor_angular_speed;
            Cogs_array[0].angular_speed = (Cogs_array[Cogs_array.Length - 1].Data.Radius / Cogs_array[0].Data.Radius) * Cogs_array[Cogs_array.Length - 1].angular_speed;
            for (int i = Cogs_array.Length - 1; i >= 0; i--)
            {
                Cogs_array[i].angular_speed = (Cogs_array[i].Data.Radius / Cogs_array[0].Data.Radius) * Cogs_array[0].angular_speed;
            }
            int j = Cogs_array.Length - 1;
            while (j > 0){
                
                Debug.Log("Radius = " + Cogs_array[j].Data.Radius);
                Debug.Log("Angular speed = " + Cogs_array[j].angular_speed);
                j--;
            }
        }
    }
}

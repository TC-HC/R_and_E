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
        double.TryParse(str, out motor_angular_speed);
        if (str != null)
        {
            Debug.Log("모터 각속도 : " + (double)motor_angular_speed);
            int size = Sort_Cogs.size;
            Debug.Log(size);
            Sort_Cogs.cogs_array[size - 1].angular_speed = motor_angular_speed;
            Sort_Cogs.cogs_array[0].angular_speed = (Sort_Cogs.cogs_array[size - 1].Data.Radius / Sort_Cogs.cogs_array[0].Data.Radius) * Sort_Cogs.cogs_array[size - 1].angular_speed;
            for (int i = size - 2; i > 0; i--)
            {
                Sort_Cogs.cogs_array[i].angular_speed = (Sort_Cogs.cogs_array[0].Data.Radius / Sort_Cogs.cogs_array[i].Data.Radius) * Sort_Cogs.cogs_array[0].angular_speed;
            }
            int j = size - 1;
            while (j >= 0){
                
                Debug.Log("Radius = " + Sort_Cogs.cogs_array[j].Data.Radius);
                Debug.Log("Angular speed = " + Sort_Cogs.cogs_array[j].angular_speed);
                j--;
            }
        }
    }
}

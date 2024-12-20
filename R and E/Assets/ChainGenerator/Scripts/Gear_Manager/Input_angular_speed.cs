using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

namespace Chain
{
    public class Input_angular_speed : MonoBehaviour
    {
        [SerializeField]
        public static double motor_angular_speed = 10;
        public static double Radius = 0;

        public void OnEndEditEvent(string str)
        {
            double.TryParse(str, out motor_angular_speed);
            if (str != null)
            {
                int size = Sort_Cogs.size;
                Machinery machinery = FindObjectOfType<Machinery>();
                CogMover cog_mover = FindObjectOfType<CogMover>();

                machinery.SetMovers();

                cog_mover.StopMotion();
                cog_mover.StartMotion();

                Sort_Cogs.cogs_array[size - 1].angular_speed = motor_angular_speed;
                for (int i = 0; i < size - 1; i++)
                {
                    Sort_Cogs.cogs_array[i].angular_speed = (Sort_Cogs.cogs_array[size - 1].Data.Radius / Sort_Cogs.cogs_array[i].Data.Radius) * Sort_Cogs.cogs_array[size - 1].angular_speed;
                }
            }
        }
    }
}

using Chain;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Calculate_Power : MonoBehaviour
{
    public static int size;

    public void Calculate_power()
    {
        int i = 0;
        size = Sort_Cogs.cogs_array.Length;

        Sort_Cogs.cogs_array[0].power = Input_extra_power.extra_power;

        for(i = 1; i<size; i++)
        {
            Sort_Cogs.cogs_array[i].power = (Sort_Cogs.cogs_array[i - 1].Data.TeethCount * Sort_Cogs.cogs_array[i - 1].Data.Radius / 8) * Sort_Cogs.cogs_array[i].Data.Radius * Mathf.Pow((float)Sort_Cogs.cogs_array[i].angular_speed, 3) + Sort_Cogs.cogs_array[i - 1].power;
        }
    }
}

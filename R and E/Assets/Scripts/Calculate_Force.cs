using Chain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculate_Force : MonoBehaviour
{
    public GearData Data;
    void Calculate_force()
    {
        int i = 0;
        for(i = 0; i < Sort_Cogs.cogs_array.Length; i++)
        {
            Sort_Cogs.cogs_array[i].force = Mathf.Sqrt(2) / (Sort_Cogs.cogs_array[i].Data.Radius * Sort_Cogs.cogs_array[i].angular_speed) * Sort_Cogs.cogs_array[i].power/(2/3 * Sort_Cogs.cogs_array[i].area);
        }
    }
}

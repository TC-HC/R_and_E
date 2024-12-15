using Chain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculate_Area : MonoBehaviour
{
    public GearData Data;
    public double depth;
    public double theta = Mathf.Asin(0.507f);
    public void Calculate_area()
    {
        int i = 0;
        double module, x, z, R;
        for(i = 0; i < Sort_Cogs.cogs_array.Length; i++)
        {
            depth = Input_Depth.Depth;
            module = 2 * Sort_Cogs.cogs_array[i].Data.Radius / (Sort_Cogs.cogs_array[i].Data.TeethCount - 2.5);
            x = 2.07 * module;
            z = 2.25 * module;
            R = 4.507 * module;
            Sort_Cogs.cogs_array[i].area = R * theta * depth;
        }
    }
}

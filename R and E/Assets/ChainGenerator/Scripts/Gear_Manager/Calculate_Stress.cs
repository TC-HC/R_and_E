using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chain
{
    public class Calculate_Stress : MonoBehaviour
    {
        public GearData Data;
        public void Calculate_stress()
        {
            Calculate_Area calculate_Area = FindObjectOfType<Calculate_Area>();
            calculate_Area.Calculate_area();

            Calculate_Power calculate_power = FindObjectOfType<Calculate_Power>();
            calculate_power.Calculate_power();

            int i = 0;
            int size = Sort_Cogs.cogs_array.Length;
            for (i = 0; i < size; i++)
            {
                Sort_Cogs.cogs_array[i].stress = Mathf.Sqrt(2) / (Sort_Cogs.cogs_array[i].Data.Radius * Sort_Cogs.cogs_array[i].angular_speed) * Sort_Cogs.cogs_array[i].power / (2 * Sort_Cogs.cogs_array[i].area) * 3;
            }
        }
    }
}

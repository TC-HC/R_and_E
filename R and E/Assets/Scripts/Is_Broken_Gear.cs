using Chain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Is_Broken_Gear : MonoBehaviour
{
    public GearData Date;
    public double max_stress;
    // Update is called once per frame
    void Update()
    {
        Calculate_Stress calculate_stress = FindObjectOfType<Calculate_Stress>();
        calculate_stress.Calculate_stress();

        int i = 0;
        int size = Sort_Cogs.cogs_array.Length;
        max_stress = Input_Max_stress.Max_stress;

        for(i = 0; i < size; i++)
        {
            if(max_stress <= Sort_Cogs.cogs_array[i].stress)
            {
                Debug.Log(Sort_Cogs.cogs_array[i] + " is broken!");
            }
        }
    }
}

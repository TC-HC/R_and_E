using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chain
{
    public class Input_Depth : MonoBehaviour
    {
        [SerializeField]
        public static double Depth;

        public void OnEndEditEvent(string str)
        {
            Calculate_Area calculate_Area = FindObjectOfType<Calculate_Area>();
            double.TryParse(str, out Depth);
            calculate_Area.Calculate_area();
        }
    }
}

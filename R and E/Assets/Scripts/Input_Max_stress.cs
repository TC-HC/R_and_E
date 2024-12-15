using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Max_stress : MonoBehaviour
{
    [SerializeField]
    public static double Max_stress = 0;
    public void OnEndEditEvent(string str)
    {
        double.TryParse(str, out Max_stress);
    }
}

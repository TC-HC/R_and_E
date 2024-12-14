using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_extra_power : MonoBehaviour
{
    [SerializeField]
    public static double extra_power = 0;
    public void OnEndEditEvent(string str)
    {
        double.TryParse(str, out extra_power);
    }
}

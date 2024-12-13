using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_angular_speed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        double angular_speed;
        double.TryParse(Console.ReadLine(), out angular_speed);
        Debug.Log("w = " +  angular_speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Input_angular_speed : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    public void OnEndEditEvent(string str)
    {
        text.text = $"End Edit : {str}";
    }
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

using Chain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainModifier : MonoBehaviour
{
    // Machinery 객체에 대한 참조
    public Machinery machinery;

    void Start()
    {
        // Machinery 객체를 찾는 방법 (예시로 태그를 통해 찾음)
        if (machinery == null)
        {
            machinery = GameObject.Find("Machinery Instance").GetComponent<Machinery>();
        }

        // machinery 객체가 유효하다면
        if (machinery != null)
        {
            // 기어 목록을 가져오기
            Cogwheel[] cogs = machinery.cogHolder.RestoreCogsInEditor();

            // 첫 번째 기어(Gear 0)의 ToothGap 값에 접근
            if (cogs.Length > 0 && cogs[0].Data != null)
            {
                float toothGap = cogs[0].Data.ToothGap;
                float radius = cogs[0].Data.Radius;
                Debug.Log("Gear 1의 ToothGap: " + toothGap);
                Debug.Log("Gear 1의 Radius: " + radius);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

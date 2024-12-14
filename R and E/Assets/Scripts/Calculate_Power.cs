using Chain;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Calculate_Power : MonoBehaviour
{
    public Machinery machinery;
    public GameObject prefab;
    GameObject shaft;

    public static Cogwheel[] cogs_array { get; private set; } 
    public static int size;

    public void Calculate_cogs()
    {
        prefab = Resources.Load<GameObject>("Prefab/Shaft"); // "Prefab/Shaft" 경로에 있는 게임 오브젝트를 불러옴

        if ( prefab == null )
        {
            Debug.LogError("Shaft를 찾을 수 없습니다. Shaft가 존재하는지 다시 한번 확인해주십시오.");
            return;
        }

        shaft = Instantiate(prefab);

        // Machinery 객체를 찾는 방법 (예시로 태그를 통해 찾음)
        if (machinery == null)
        {
            machinery = GameObject.Find("Machinery Instance").GetComponent<Machinery>();
        }

        // machinery 객체가 유효하다면
        if (machinery != null && shaft != null)
        {
            int i, j, k;
            // 기어 목록을 가져오기
            Cogwheel[] cogs = machinery.cogHolder.RestoreCogsInEditor();
            size = cogs.Length;
            Cogwheel[] cogs_array = new Cogwheel[size]; // size : 기어의 데이터를 저장하는 배열의 길이

            for(i=0; i < size; i++)
            {
                cogs_array[i] = cogs[i];
            }

            Vector3 shaftPosition = shaft.transform.position;

            //삽입 정렬 방식으로 shaft에서 떨어진 거리가 먼 순으로 기어 정렬
            for (i=1 ; i < size; i++)
            {
                Vector3 cogPosition = cogs_array[i].transform.position;
                double key_distance = Vector3.Distance(cogPosition, shaftPosition);
                Cogwheel key_cog = cogs[i];                

                for(j = 0; j < i; j++)
                {
                    double distance = Vector3.Distance(cogs_array[j].transform.position, shaftPosition);
                    if(distance < key_distance)
                    {
                        break;
                    }
                }
                for (k = i; k > j; k--)
                {
                    cogs_array[k] = cogs_array[k - 1];
                }
                cogs_array[j] = key_cog;
            }
            cogs_array[0].angular_speed = Input_angular_speed.motor_angular_speed;
            Debug.Log(cogs_array[0].Data.Radius);
        }
    }

    double Calculate_power(Cogwheel[] cogs_array, int n, int size)
    {
        if (n != 0)
        {
            return cogs_array[n].power = (cogs_array[n - 1].Data.TeethCount * cogs_array[n - 1].Data.Radius / 8) * cogs_array[size - 1].Data.Radius * Mathf.Pow((float)cogs_array[size - 1].angular_speed, 3) + Calculate_power(cogs_array, n - 1, size);
        }
        else
        {
            return 0;   //대충 0번째 기어에 작용하는 동력, 사용자가 입력할 수 있게 만들어야 함.(inputfield 만든게 있으니 그거 이용하면 될 듯)
        }
    }

    void Awake()
    {
        Calculate_cogs();
    }
}

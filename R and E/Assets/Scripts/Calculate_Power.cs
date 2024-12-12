using Chain;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Calculate_Power : MonoBehaviour
{
    public Machinery machinery;
    public GameObject prefab;
    GameObject shaft;

    // Start is called before the first frame update
    void Start()
    {
        prefab = Resources.Load<GameObject>("Prefab/Shaft");

        if( prefab == null)
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
            int size = cogs.Length;
            Cogwheel[] cogs_array = new Cogwheel[size];

            for(i=0; i < size; i++)
            {
                cogs_array[i] = cogs[i];
            }

            Vector3 shaftPosition = shaft.transform.position;

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
        }
    }
}

using Chain;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Sort_Cogs : MonoBehaviour
{
    public Machinery machinery;
    public GameObject prefab;
    GameObject shaft;

    public static Cogwheel[] cogs_array;
    public static int size;
    public void Sort_cogs()
    {

        // Machinery ��ü�� ã�� ��� (���÷� �±׸� ���� ã��)
        if (machinery == null)
        {
            machinery = GameObject.Find("Machinery Instance").GetComponent<Machinery>();
        }

        // machinery ��ü�� ��ȿ�ϴٸ�
        if (machinery != null && shaft != null)
        {
            int i, j, k;
            // ��� ����� ��������
            Cogwheel[] cogs = machinery.cogHolder.RestoreCogsInEditor();
            size = cogs.Length;
            cogs_array = new Cogwheel[size]; // size : ����� �����͸� �����ϴ� �迭�� ����

            for (i = 0; i < size; i++)
            {
                cogs_array[i] = cogs[i];
            }

            Vector3 shaftPosition = shaft.transform.position;

            //���� ���� ������� shaft���� ������ �Ÿ��� �� ������ ��� ����
            for (i = 1; i < size; i++)
            {
                Vector3 cogPosition = cogs_array[i].transform.position;
                double key_distance = Vector3.Distance(cogPosition, shaftPosition);
                Cogwheel key_cog = cogs[i];

                for (j = 0; j < i; j++)
                {
                    double distance = Vector3.Distance(cogs_array[j].transform.position, shaftPosition);
                    if (distance < key_distance)
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
    void Start()
    {
        prefab = Resources.Load<GameObject>("Prefab/Shaft"); // "Prefab/Shaft" ��ο� �ִ� ���� ������Ʈ�� �ҷ���

        if (prefab == null)
        {
            Debug.LogError("Shaft�� ã�� �� �����ϴ�. Shaft�� �����ϴ��� �ٽ� �ѹ� Ȯ�����ֽʽÿ�.");
            return;
        }
        shaft = Instantiate(prefab);

        Sort_cogs();
    }
}
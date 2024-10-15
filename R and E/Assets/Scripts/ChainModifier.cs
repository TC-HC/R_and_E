using Chain;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChainModifier : MonoBehaviour
{
    // Machinery ��ü�� ���� ����
    public Machinery machinery;
    public GameObject Col;

    void Start()
    {
        // Machinery ��ü�� ã�� ��� (���÷� �±׸� ���� ã��)
        if (machinery == null)
        {
            machinery = GameObject.Find("Machinery Instance").GetComponent<Machinery>();
        }

        // machinery ��ü�� ��ȿ�ϴٸ�
        if (machinery != null)
        {
            // ��� ����� ��������
            Cogwheel[] cogs = machinery.cogHolder.RestoreCogsInEditor();

            // ù ��° ���(Gear 0)�� ToothGap ���� ����
            if (cogs.Length > 0 && cogs[0].Data != null)
            {
                float toothGap = cogs[0].Data.ToothGap;
                float radius = cogs[0].Data.Radius;
                Debug.Log("Gear 1�� ToothGap: " + toothGap);
                Debug.Log("Gear 1�� Radius: " + radius);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Cogwheel[] cogs = machinery.cogHolder.RestoreCogsInEditor();
        float toothGap = cogs[0].Data.ToothGap;
        Vector3 thispos = this.transform.position;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < toothGap; i++)
            {
                Instantiate(Col);

            }
        }
    }
}

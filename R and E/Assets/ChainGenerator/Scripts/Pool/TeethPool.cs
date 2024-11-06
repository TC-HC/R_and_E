using System.Linq;
using GenericHelper;
using UnityEngine;
using UnityEngine.UIElements;


namespace Chain
{
    [ExecuteInEditMode]
    public class TeethPool : Pool<Tooth>
    {
        // TeethPool Ŭ���� �� ActivatePool���� Collider �߰� Ȯ��
        public void ActivatePool()
        {
            // ���� ��� ���� Collider ����
            foreach (var col in GetComponentsInChildren<BoxCollider>())
            {
                DestroyImmediate(col);
            }

            if (pool.Count > 0) return;

            var poolChildren = GetComponentsInChildren<Tooth>(true).ToList();

            foreach (var child in poolChildren)
            {
                // Collider�� ������ �߰�
                if (child.GetComponent<Collider>() == null)
                {
                    child.gameObject.AddComponent<BoxCollider>(); // ���ϴ� Collider�� ��ü ����
                }
            }

            if (poolChildren.Count > 0)
                RestorePool(poolChildren.ToArray());
        }




        public void DeletePool()
        {
            DestroyImmediate(gameObject, true);
        }
    }

}

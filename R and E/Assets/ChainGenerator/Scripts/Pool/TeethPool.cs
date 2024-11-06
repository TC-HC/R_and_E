using System.Linq;
using GenericHelper;
using UnityEngine;
using UnityEngine.UIElements;


namespace Chain
{
    [ExecuteInEditMode]
    public class TeethPool : Pool<Tooth>
    {
        // TeethPool 클래스 내 ActivatePool에서 Collider 추가 확인
        public void ActivatePool()
        {
            // 먼저 모든 기존 Collider 삭제
            foreach (var col in GetComponentsInChildren<BoxCollider>())
            {
                DestroyImmediate(col);
            }

            if (pool.Count > 0) return;

            var poolChildren = GetComponentsInChildren<Tooth>(true).ToList();

            foreach (var child in poolChildren)
            {
                // Collider가 없으면 추가
                if (child.GetComponent<Collider>() == null)
                {
                    child.gameObject.AddComponent<BoxCollider>(); // 원하는 Collider로 대체 가능
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

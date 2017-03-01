using UnityEngine;

namespace Pooling
{
    public class ObjectToPool : MonoBehaviour
    {
        void OnDisable()
        {
            PoolingManager.Instance.Add(gameObject.name, this.gameObject);
        }

    }
}


using UnityEngine;

namespace Pooling
{
    public class ObjectToPool : MonoBehaviour
    {
        void OnDisable()
        {
            PoolingManager.T.Add(gameObject.name, this.gameObject);
        }

    }
}


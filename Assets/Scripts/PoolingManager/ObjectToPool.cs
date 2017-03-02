using UnityEngine;
namespace Pooling
{
    //Attach this script to any object you wish you pool
    public class ObjectToPool : MonoBehaviour
    {
        void OnDisable()
        {
            //Adds this gameobject to the Pool
            PoolingManager.Instance.Add(gameObject.name, this.gameObject);
        }

    }
}


using System.Collections.Generic;
using UnityEngine;

namespace Pooling
{
    //Attach this script to a gameobject to use
    public class PoolingManager : MonoBehaviour
    {
        //Enables the pooling manager to be used anywhere
        public static PoolingManager Instance
        {
            get { return _instance; }
        }

        private static PoolingManager _instance;

        //Defines what folders to use from the Resource directory
        public string[] ResourceName;

        //To hold pooled objects
        private Dictionary<string, List<GameObject>> _objectPool;
        private Dictionary<string, GameObject> _resourceMapper;
        private Dictionary<string, GameObject> _objectHolder;

        //Parent of all instantiated objects
        private GameObject _masterHolder;

        void Awake()
        {
            //Make sure there is only one instance of PoolingManager
            if(_instance == null)
                _instance = this;
            else
            {
                Destroy(this);
            }

            _objectPool = new Dictionary<string, List<GameObject>>();
            _objectHolder = new Dictionary<string, GameObject>();
            _resourceMapper = new Dictionary<string, GameObject>();
           _masterHolder = new GameObject("PoolingManagerHolder");

            foreach (string resource in ResourceName)
            {
                GameObject[] test = Resources.LoadAll<GameObject>(resource);
                foreach (GameObject goGameObject in test)
                {
                    _resourceMapper.Add(goGameObject.name, goGameObject);
                }
            }


        }

        //Adds the gameobject back to the pool
        public void Add(string className, GameObject objectToAdd)
        {
            if (!className.Contains("(Clone)"))
            {
                className = objectToAdd.name + "(Clone)";
            }
            CreateIfDoesNotExist(className);
            _objectPool[className].Add(objectToAdd);
        }

        //Creates Key in Dictionary if it does not exist
        void CreateIfDoesNotExist(string className)
        {
            if (!_objectPool.ContainsKey(className))
            {
                _objectPool.Add(className, new List<GameObject>());
            }
        }

        //Instantiate object by name
        public GameObject Instantiate(string objectToSpawn, Vector3 startingSpawn, Quaternion rotation)
        {
            string className = objectToSpawn;
            CheckIfHolderExists(objectToSpawn);
            if (!className.Contains("(Clone)"))
            {
                className = objectToSpawn + "(Clone)";
            }

            CreateIfDoesNotExist(className);
            if (_objectPool[className].Count > 0)
            {
                var temp = _objectPool[className][0];
                if (temp == null)
                {
                    GameObject spawnedObject =
                        (GameObject) Instantiate(_resourceMapper[objectToSpawn], startingSpawn, rotation);
                    spawnedObject.transform.parent = _objectHolder[objectToSpawn].transform;
                    return spawnedObject;
                }
                if (temp.activeSelf)
                {
                    GameObject spawnedObject =
                        (GameObject) Instantiate(_resourceMapper[objectToSpawn], startingSpawn, rotation);
                    spawnedObject.transform.parent = _objectHolder[objectToSpawn].transform;
                    return spawnedObject;
                }
                temp.transform.position = startingSpawn;
                temp.transform.rotation = rotation;

                _objectPool[className].RemoveAt(0);
                temp.SetActive(true);
                return temp;
            }
            else
            {
                GameObject spawnedObject =
                    (GameObject) Instantiate(_resourceMapper[objectToSpawn], startingSpawn, rotation);
                spawnedObject.transform.parent = _objectHolder[objectToSpawn].transform;
                return spawnedObject;
            }
        }

        //Instantiate object by name with parent
        public GameObject Instantiate(string objectToSpawn, Vector3 startingSpawn, Quaternion rotation, Transform parent)
        {
            string className = objectToSpawn;
            CheckIfHolderExists(objectToSpawn);
            if (!className.Contains("(Clone)"))
            {
                className = objectToSpawn + "(Clone)";
            }
            CreateIfDoesNotExist(className);
            if (_objectPool[className].Count > 0)
            {
                var temp = _objectPool[className][0];
                if (temp == null)
                    return Instantiate(Resources.Load(objectToSpawn), startingSpawn, rotation, parent) as GameObject;
                if (temp.activeSelf)
                    return Instantiate(Resources.Load(objectToSpawn), startingSpawn, rotation, parent) as GameObject;
                temp.transform.position = startingSpawn;
                temp.transform.rotation = rotation;

                _objectPool[className].RemoveAt(0);
                temp.SetActive(true);

                return temp;
            }
            else
            {
                return Instantiate(Resources.Load(objectToSpawn), startingSpawn, rotation, parent) as GameObject;

            }
        }

        //Creates child to hold different objects.
        public void CheckIfHolderExists(string objectToHold)
        {
            if (!_objectHolder.ContainsKey(objectToHold))
            {
                GameObject holderObject = new GameObject(objectToHold + "holder");
                holderObject.transform.parent = _masterHolder.transform;
                _objectHolder.Add(objectToHold, holderObject);
            }
        }
    }
}

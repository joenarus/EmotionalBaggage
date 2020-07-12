using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton
    public static ObjectPooling Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private Dictionary<string, List<GameObject>> activatedObjects;
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        activatedObjects = new Dictionary<string, List<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.transform.parent = transform.Find("Inactive/" + pool.tag);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag" + tag + " doesn't exist.");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.SetActive(true);

        IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();
        if (pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }
        poolDictionary[tag].Enqueue(objectToSpawn);
        if (!activatedObjects.ContainsKey(tag))
        {
            activatedObjects.Add(tag, new List<GameObject>());
        }

        activatedObjects[tag].Add(objectToSpawn);

        return objectToSpawn;
    }

    public void ResetPool()
    {
        foreach (string tag in activatedObjects.Keys)
        {
            foreach (GameObject activeObject in activatedObjects[tag])
            {
                activeObject.transform.parent = transform.Find("Inactive/" + tag);
                activeObject.transform.rotation = transform.rotation;
                activeObject.transform.position = transform.position;
                activeObject.SetActive(false);
            }
        }
    }

    public void ResetPoolObj(string tag, GameObject obj)
    {
        obj.transform.parent = transform.Find("Inactive/" + tag);
        obj.transform.rotation = transform.rotation;
        obj.transform.position = transform.position;
        obj.SetActive(false);
    }
}

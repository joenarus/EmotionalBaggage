using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    ObjectPooling objectPooling;
    // Start is called before the first frame update
    void Start()
    {
        objectPooling = ObjectPooling.Instance;    
    }

    private void FixedUpdate()
    {
        //objectPooling.SpawnFromPool("Bullet", transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

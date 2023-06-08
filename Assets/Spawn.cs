using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] prefabs;
    public Vector3 pos = new Vector3 (2.5f,1f,0.3f);
    private jump controller;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMan", 2, 2.1f);
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<jump>();
    }
    // Update is called once per frame
    
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnMan()
    {
        int rand = Random.Range(0,prefabs.Length);
        if (controller.loos != true)
          
            Instantiate(prefabs[rand], pos, prefabs[rand].transform.rotation);
    }
}

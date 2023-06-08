using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFly : MonoBehaviour
{
    public GameObject[] prefabs;
    private Vector3 pos;
     private jump controller;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMan", 3, 2.9f);
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<jump>();
    }
    // Update is called once per frame
    
    
    

    // Update is called once per frame
    void Update()
    {
       pos = new Vector3(20f, Random.Range(3f,6f), 0.3f);
    }
    void SpawnMan()
    {
        int rand = Random.Range(0,prefabs.Length);
        if (controller.loos != true)
          
            Instantiate(prefabs[rand], pos, prefabs[rand].transform.rotation);
    }
}

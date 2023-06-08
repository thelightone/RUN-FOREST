using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlow : MonoBehaviour
{
    public GameObject[] prefabs;
    private Vector3 pos;
    private Quaternion rot;
    private jump controller;
    public float bord1 = -1.8f;
    public float bord2 = -3.5f;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMan", 0.1f, time);
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<jump>();
    }
    // Update is called once per frame
    
    
    

    // Update is called once per frame
    void Update()
    {
       pos = new Vector3(25f, 0.2f, Random.Range(bord1,bord2));
      //  rot.y = Random.Range(0, 180);
       // rot.x =;
      //  rot.z = Random.Range(0, 180);
    }
    void SpawnMan()
    {
        int rand = Random.Range(0,prefabs.Length);
        if (controller.loos != true)
            rot.y = Random.Range(0, 180);
        Instantiate(prefabs[rand], pos, rot);
    }
}

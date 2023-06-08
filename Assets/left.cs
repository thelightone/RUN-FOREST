using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left : MonoBehaviour
{
    public float speed = 30f;
    public float speedy = 0.15f;
    private jump controller;
    public float border = -15f;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<jump>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {  float xx = transform.position.x - speedy;
     if (player.transform.position.y > 0.2)  
             xx = transform.position.x - (speedy*1.5f);
        if (controller.loos != true)
            transform.position = new Vector3(xx,transform.position.y,  transform.position.z);  
        if (transform.position.x < border &&( gameObject.CompareTag("Ground")|| gameObject.CompareTag("Bomb") || gameObject.CompareTag("Respawn")))
            Destroy(gameObject);
       
    }
}

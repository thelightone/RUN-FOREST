using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class right : MonoBehaviour
{
    public float speed = 30f;
    private jump controller;
    private float border = -25f;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        
      transform.Translate(Vector3.forward* speed*Time.deltaTime);
       
        if (transform.position.x > -border)
            Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
      //  if (collision.gameObject.CompareTag("Bomb"))
           
             //   Destroy(gameObject);
                collision.gameObject.GetComponent<lives>().FeedAnimal(1);

            
    }
}

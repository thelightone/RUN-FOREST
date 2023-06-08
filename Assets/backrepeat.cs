using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backrepeat : MonoBehaviour
{
    private Vector3 startPos;
    private float colWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; 
        colWidth = GetComponent<BoxCollider>().size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x< startPos.x-colWidth)
        {
            transform.position = startPos;
        }
    }
}

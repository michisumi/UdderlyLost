using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestroys : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //if we enter a collision and the object we collided with is tagged item
        //destroy the gameobject we hit
        if (col.gameObject.tag == "coin")
        {
            Destroy(col.gameObject);
            Debug.Log("Destroyed");
        }
    }
}


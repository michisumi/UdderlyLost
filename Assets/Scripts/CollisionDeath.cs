using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDeath : MonoBehaviour
{
    //Which AudioSource are we using
    //Set this in the inspector on the script
    public AudioSource Source;

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
        //if we detect a collision, and the object we collided with is the player
        //play the AudioSource 
        if (col.gameObject.tag == "Player")
        {
            Source.Play();
            Debug.Log("Played sound");
        }
    }

}

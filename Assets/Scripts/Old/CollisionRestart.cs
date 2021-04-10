using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionRestart : MonoBehaviour
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
        //when we detect a collision, if the object we collided with is called enemy
        //reload the level
        if (col.gameObject.tag == "enemy")
        {
            SceneManager.LoadScene("Level1");
            Debug.Log("Restarted");
        }
    }

}


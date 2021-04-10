using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

//this script detects a collision between the player character and any gameobject tagged as "character"
//when the collision is detected, it activates a UI Canvas, which is parented to the player character and shows dialogue
//there are two dialogues which can be shown, dialogue1 and dialogue 2. these can we written within the inspector
public class CollisionEnables : MonoBehaviour
{
    public Canvas myDialogueBox;
    private Text myDialogue;

    // Start is called before the first frame update
    void Start()
    {
        //when the game starts, set the canvas called myDialogueBox to inactive
        myDialogueBox.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //when entering the collision, the UI Canvas is enabled
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            myDialogueBox.gameObject.SetActive(true);

        }
    }

    //when exiting the collision, the UI Canvas is disabled
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            myDialogueBox.gameObject.SetActive(false);

        }

    }
}

fusing System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformerController : MonoBehaviour
{

    //Speed of character movement and height of the jump. Set these values in the inspector.
    public float speed;
    public float jumpHeight;
    private bool isFacingRight = true;

    //Assigning a variable where we'll store the Rigidbody2D component.
    private Rigidbody2D rb;
    public Animator animator;

    private bool onGround;
    private bool canJump;
    private int doubleJump = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Sets our variable 'rb' to the Rigidbody2D component on the game object where this script is attached.
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the player is on the ground. If we are, then we are able to jump.
        if (onGround == true || doubleJump < 2)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
        //If we're able to jump and the player has pressed the space bar, then we jump!
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true && doubleJump < 2)
        {
            rb.velocity = Vector2.up * jumpHeight;
            doubleJump = doubleJump + 1;
        }


        //Movement code for left and right arrow keys.
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (isFacingRight == true) //x ==1 is checking if x equals 1 || x = 1 is setting x to now equal 1 || 
            {
                Flip();
                isFacingRight = false;
            }
        }

        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(+speed, rb.velocity.y);
            if (isFacingRight == false)
            { 
                Flip();
                isFacingRight = true;
            }
        }
        //ELSE if we're not pressing an arrow key, our velocity is 0 along the X axis, and whatever the Y velocity is (determined by jump)
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        //Animation code for walking.
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));

        animator.SetFloat("jump", Mathf.Abs(rb.velocity.y));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If we collide with an object tagged "ground" then our jump resets and we can now jump.
        if (collision.gameObject.tag == "ground")
        {
            onGround = true;
            doubleJump = 0;
            print(onGround);
            //print statements print to the Console panel in Unity. 
            //This will print the value of onGround, which is a boolean, so either True or False.
        }

        //if we enter a collision and the object we collided with is tagged item
        //destroy the gameobject we hit
        if (collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
            Debug.Log("Destroyed");
        }

        //when we detect a collision, if the object we collided with is called enemy
        //reload the level
        if (collision.gameObject.tag == "enemy")
        {
            SceneManager.LoadScene("Level1");
            Debug.Log("Restarted");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //If we exit our collision with the "ground" object, then we are unable to jump.
        if (collision.gameObject.tag == "ground")
        {
            onGround = false;
            print(onGround);
        }
    }

    private void Flip()
    {
        Vector2 ourScale = transform.localScale;
        ourScale.x = ourScale.x * -1;
        transform.localScale = ourScale;
    }

}

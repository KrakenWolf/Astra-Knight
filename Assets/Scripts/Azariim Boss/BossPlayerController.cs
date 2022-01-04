using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlayerController : MonoBehaviour
{
    // These are the main game objects the player uses for movement and animation.
    private Rigidbody playerRb;
    private Animator anim;

    // Game object to add the jet pack's jump effect
    public GameObject jets;
    // game object for the guns effects.
    public GameObject flash;
    public GameObject shot;

    // These are float variables that provide the base for all player movement interactions.
    private float speed = 5.0f;
    private float yBound = -0.1f;
    private float jumpForce = 20.0f;
    private float rotationSpeed = 10.0f;

    // Tells the game whether the player is on the ground or in the air.
    public bool isOnGround;
    public bool isJumping;

    // Sets the starting position from where the character is when the level loads.
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        // Jet effect is disabled on start and will become active when the player jumps.
        jets.SetActive(false);
        // Sets The guns effect to false on start.
        flash.SetActive(false);
        shot.SetActive(false);
    }

    private void Awake()
    {
        //Sets the player rigidbody component from (private Rigidbody plsyerRb;)
        playerRb = GetComponent<Rigidbody>();
        // Sets the start position as the position to which you'll respawn on death.
        startPos = this.transform.position;
        // calls the animator component attatched to the object.
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // These call the custom methods needed in each frame for the player to be able to play the game.
        MovePlayer();
        RestartPlayerPos();
        Jump();
        FireTheLazaaa();
    }
    // Moves the player
    void MovePlayer()
    {
        // Gets the imput controls for the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Adds force to move the player directionally
        playerRb.transform.Rotate(Vector3.up * speed * horizontalInput * rotationSpeed * Time.deltaTime);
        playerRb.transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);

            //Controls the running animation.
            if (verticalInput != 0) anim.SetBool("Running", true);
        else anim.SetBool("Running", false);
    }

    // Constrains the player to the boundary set in the yBound float.
    void RestartPlayerPos()
    {
        // If player drops below the boundary they will respawn at the start position.
        if (transform.position.y < yBound)
        {
            this.transform.position = startPos;
        }
    }

    // This lets the game know the player is grounded and runs the appropriate animations.
    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
        isOnGround = true;
        Debug.Log("On Ground");

        // Runs animation for running while player is grounded.
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }

    }

    // This will let the game know the player has left the ground.
    private void OnCollisionExit(Collision collision)
    {
        isJumping = true;
        isOnGround = false;
        Debug.Log("Is off ground");
    }

    private IEnumerator WaitForSec()
    {
        // Sets an animation controller for the effect of the jetpack to switch off after x amount of seconds.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            yield return new WaitForSeconds(1);
            jets.SetActive(false);
        }
    }

    private IEnumerator WaitForSecgun()
    {
        yield return new WaitForSeconds(0.2f);
        flash.SetActive(false);
        shot.SetActive(false);
        StopCoroutine("WaitForSecgun");
    }

    void Jump()
    {
        // If the player is on the ground they are able to jump using the space bar.
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false && isOnGround == true)
        {
            WaitForSec();
            StartCoroutine("WaitForSec");
            playerRb.AddForce(Vector3.up * speed * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("Jumping");
            jets.SetActive(true);
        }
    }

    void FireTheLazaaa()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            flash.SetActive(true);
            shot.SetActive(true);
            StartCoroutine("WaitForSecgun");
        }
    }
}
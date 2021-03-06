                           using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Move Speed")]
    public float playerSpeed;
    public float rotationSpeed = 15;

    Rigidbody2D myRb;
    Transform PlayerTransform;
    public Transform playerSprite;
    public Animator myAnim;
    public AudioSource footSteps;

    // Start is called before the first frame update
    void Start()
    {
        myRb = gameObject.GetComponent<Rigidbody2D>();
        PlayerTransform = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput * playerSpeed, verticalInput * playerSpeed);
        myAnim.SetFloat("moveVelocity", moveDirection.magnitude);
        if (horizontalInput != 0 || verticalInput != 0)
        {
            PlayerTransform.Translate(moveDirection * Time.deltaTime);
            if (!footSteps.isPlaying)
            {
                AudioManager.instance.PlayFootSteps(footSteps);
            }
            playerSprite.rotation = Quaternion.Slerp(playerSprite.rotation, Quaternion.LookRotation(Vector3.forward, moveDirection), Time.deltaTime * rotationSpeed);
        }
        if(horizontalInput == 0 && verticalInput == 0)
        {
            AudioManager.instance.StopFootSteps(footSteps);
        }
    }
}

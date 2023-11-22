using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunning : MonoBehaviour
{
    private Vector3 moveVector;
    private bool isDead = false;
    private float gravity = 9.8f;
    private CharacterController player;
    [SerializeField] protected float speed = 5f;
    private float verticalVelocity = 0f;
    private float animTime = 2f;

    private void Awake()
    {
        player = GetComponent<CharacterController>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < animTime)
        {
            player.Move(Vector3.forward * speed * Time.deltaTime); // di chuyen theo truc Z
        }
        else
        {
            if (!isDead)
            {
                //if (Input.GetKeyDown(KeyCode.UpArrow))
                //{
                //    moveVector.y = speed;
                //}
                if (player.isGrounded)
                {
                    verticalVelocity = -0.5f;
                } else
                {
                    verticalVelocity -= gravity * Time.deltaTime;
                }

                //moveVector.z = Input.GetAxis("Horizontal") * 5;

                moveVector.x = Input.GetAxis("Horizontal") * 5;

                //moveVector.y = verticalVelocity;
                moveVector.z = speed;

                if (Input.GetKey(KeyCode.Space))
                {
                    moveVector.y = -verticalVelocity;
                } else
                {
                    moveVector.y = verticalVelocity;
                }

                player.Move(moveVector * Time.deltaTime);
            }
            else
            {

            }
        }
        
    }

    public void setSpeed (float v)
    {
        speed += v;
    }

    internal void Dead ()
    {
        isDead = true;
    }
}

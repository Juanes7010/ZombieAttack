using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float sphereRadius = 0.3f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float jumpHeihght = 3f;
    [SerializeField] float sensibility = 3f;
    [SerializeField] Animator rifleAnim;

    bool isGrounded;
    Health health;
    CharacterController characterController;
    Animator anim;
    Vector3 velocity;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X") * sensibility * Time.deltaTime;

        if (!health.ReturnGameOver())
        {
            //transform.Rotate(Vector3.up * mouseX);

            if (Input.GetKey(KeyCode.Mouse0))
            {
                anim.SetBool("Shoot", true);
                //rifleAnim.SetBool("Shoot", true);
            }
            else
            {
                anim.SetBool("Shoot", false);
                //rifleAnim.SetBool("Shoot", false);
            }

            if (x != 0 || z != 0)
            {
                anim.SetBool("Walk", true);
            }
            else
            {
                anim.SetBool("Walk", false);
            }

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            if (!isGrounded && velocity.y < 0 && !(x != 0 || z != 0))
            {
                anim.SetBool("Fall", true);
            }
            else
            {
                anim.SetBool("Fall", false);
            }

            Vector3 move = transform.right * x + transform.forward * z;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 4f;
                anim.SetBool("Run", true);
            }
            else
            {
                speed = 2f;
                anim.SetBool("Run", false);
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                if (move == new Vector3(0, 0, 0))
                {
                    jumpHeihght = 2;
                    anim.SetBool("Jump", true);
                    Invoke("Jump", 0.5f);
                }
                else
                {
                    jumpHeihght = 0.5f;
                    anim.SetBool("RunJump", true);
                    Jump();
                }

            }
            else
            {
                anim.SetBool("RunJump", false);
                anim.SetBool("Jump", false);
            }

            characterController.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            characterController.Move(velocity * Time.deltaTime);
        }
    }

    void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeihght * -2 * gravity);
    }
}

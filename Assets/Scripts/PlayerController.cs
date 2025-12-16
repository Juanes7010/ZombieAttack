using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float velocity = 2.5f;
    [SerializeField] float controlHorizontal;
    [SerializeField] float controlAdvance;
    [SerializeField] float turnVelocity = 10;
    [SerializeField] float forceJump = 450;
    [SerializeField] bool isGround = true;
    //[SerializeField] GameObject[] cameras;
    //[SerializeField] GameObject bulletPrefab;
    //[SerializeField] GameObject bulletPosition;
    //[SerializeField] GameObject cameraFollow;

    Animator anim;
    Rigidbody rbPlayer;
    float jumpDelay = 1.5f;
    float timeNextJump = 0;
    Health health;
    Vector2 entradaAngulos;
    Vector2 angulos;
    float sensibility = 150;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rbPlayer = GetComponent<Rigidbody>();
        health = GameObject.Find("Player").GetComponent<Health>();
        
    }

    // Update is called once per frame
    void Update()
    {
        controlHorizontal = Input.GetAxis("Horizontal");
        controlAdvance = Input.GetAxis("Vertical");
        entradaAngulos = new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")) * Time.deltaTime;
        angulos.x -= entradaAngulos.x * sensibility;
        angulos.y += entradaAngulos.y * sensibility;
        if (!health.ReturnGameOver())
        {
            transform.Translate(Vector3.forward * Time.deltaTime * velocity * controlAdvance);
            

            if (controlAdvance != 0)
            {
                //transform.Translate(Vector3.right * Time.deltaTime * velocity * controlHorizontal);
                transform.Rotate(new Vector3(0, 180, 0), Time.deltaTime * turnVelocity * angulos.y);
                anim.SetBool("Run", true);
                Jump();
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    velocity = 4;
                }
                else
                {
                    velocity = 2.5f;
                }
            }
            else
            {
                transform.Rotate(new Vector3(0, 180, 0), Time.deltaTime * turnVelocity * angulos.y);
                anim.SetBool("Run", false);
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                ChangeCamera();
            }
            RunShoot();
            Jump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            anim.SetBool("Jump", false);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround && Time.time > timeNextJump)
        {
            timeNextJump = Time.time + jumpDelay;
            rbPlayer.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
            isGround = false;
            anim.SetBool("Jump", true);
            anim.SetBool("Run", false);
        }
    }

    void RunShoot()
    {
        if (Input.GetKey(KeyCode.Mouse0) && controlAdvance != 0)
        {
            anim.SetBool("RunShoot", true);
            velocity = 1.5f;
        }
        else if(controlAdvance == 0)
        {
            anim.SetBool("RunShoot", false);
        }
        if (Input.GetKey(KeyCode.Mouse0) && controlAdvance == 0)
        {
            anim.SetBool("Shoot", true);
            
        }
        else if(Input.GetKey(KeyCode.Mouse0) && controlAdvance != 0)
        {
            anim.SetBool("Shoot", false);
            anim.SetBool("RunShoot", true);
            
            velocity = 1.5f;
        } else
        {
            anim.SetBool("Shoot", false);
            anim.SetBool("RunShoot", false);
        }
    }

    void ChangeCamera()
    {
        //if (cameras[0].activeInHierarchy)
        //{
        //    cameras[0].SetActive(false);
        //    cameras[1].SetActive(true);
        //}
        //else if(cameras[1].activeInHierarchy)
        //{
        //    cameras[0].SetActive(true);
        //    cameras[1].SetActive(false);
        //}
    }

    
}

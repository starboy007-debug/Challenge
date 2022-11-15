using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 8.0f;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    private float animationDuration = 3.0f;
    private bool isdead = false;
    private float Starttime;
    Animator anim;
    bool isjump = false;
    public static int coins = 0;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Starttime = Time.time;
        anim = GetComponent<Animator>();
    }

   
    void Update()
    {
        if (isdead)
            return;
        if(Time.time - Starttime < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = 15.0f;
        }
        else
        {
            isjump = true;
            verticalVelocity -= gravity * Time.deltaTime;

        }
       
        // x = right left
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        
        if (Input.GetMouseButtonDown(0))
        {
            if ((Input.mousePosition.x > Screen.width / 2) && (Input.mousePosition.y < Screen.height / 2))
                moveVector.x = speed+50f;
            if ((Input.mousePosition.x < Screen.width / 2) && (Input.mousePosition.y < Screen.height / 2))
                moveVector.x = -speed-50f;    
        }

        // y = up down
        moveVector.y = Input.GetAxisRaw("Jump") * verticalVelocity;
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.y > Screen.height / 2)
                moveVector.y = verticalVelocity + 25f;
            //    anim.SetBool("isjump", true);
            isjump = true;

        }

        if (isjump)
        {
            anim.SetInteger("condition", 1);
           // anim.SetBool("Running", false);
            isjump = false;
        }

        // z = forward backword
        moveVector.z = speed;
        anim.SetInteger("condition", 0);
       // anim.SetBool("Running", true);


        controller.Move(moveVector * Time.deltaTime);
    }

    public void setspeed(float modifier)
    {
        speed = 5.0f + modifier;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        //if (hit.point.z > transform.position.z + controller.radius)
        if (hit.gameObject.tag == "Enemy")
        {
            anim.SetInteger("condition", 2);
            StartCoroutine(Death());
        }

        if (hit.gameObject.tag == "Coin")
        {
            coins += 1;
        }

    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(1.5f);
        isdead = true;
        
        GetComponent<Score>().Ondeath();
    }
}

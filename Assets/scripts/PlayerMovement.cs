using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;
    Animator anim;

    void Start()
    {
    anim = GetComponent<Animator>();
    }
void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        anim.SetInteger("movement",(int)(movement.x+movement.y));
    }

void FixedUpdate() {

    rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    //get direction of mouse position
    Vector2 lookDir = mousePos - rb.position;
    //change the angle of the player 
    float angle = Mathf.Atan2(lookDir.y,lookDir.x)*Mathf.Rad2Deg-90f;
    rb.rotation = angle;

}
}

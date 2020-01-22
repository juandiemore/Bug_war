using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyFollow : MonoBehaviour
{
    public Transform goal;
    public float speed = 5f;
    public float angleSpeed = 1;
    private Vector2 movement;
    private Rigidbody2D rb;
    private playerHP php;
    public float damage = 15f;

     void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        php = goal.GetComponent<playerHP>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direccion = goal.position - transform.position;
        float angle = angleSpeed*( Mathf.Atan2(direccion.y,direccion.x) * Mathf.Rad2Deg -90);
        rb.rotation = angle;
        direccion.Normalize();
        movement = direccion;
    }
    
    void FixedUpdate()
    {   
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direccion){
        rb.MovePosition((Vector2) transform.position + (direccion * speed * Time.deltaTime));
    }

   
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player"){
        php.takeDamage(damage);
       // goal.rb.AddForce(goal.rb.transform.up*-10,ForceMode2D.Impulse);
        }
        
    }
    

}

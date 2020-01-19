using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyLife : MonoBehaviour
{
   [Header("Unity Stuff")]
    enemyFollow enemy;
    public Image healthBar;

    public GameObject diskPrefab;
    public float StartHealth= 100;
    public float health;

    // seteando imagen 
    public Image imagen;
    public Sprite bicho;
    
    Animator anim;
 

    // Start is called before the first frame update
    void Start()
    {
      
         health = StartHealth;
         enemy = GetComponent<enemyFollow>();
         anim = GetComponent<Animator>();
    }

void Update(){
//healthBar.fillAmount = health/StartHealth;
}
    // Update is called once per frame
private void OnCollisionEnter2D(Collision2D other) {
    
   
    if(other.gameObject.tag == "bullet"){
    imagen.gameObject.GetComponent<Image>().sprite = bicho;
        takeDamage(20);
    }
}

        void takeDamage(float amount){
        health-= amount;
        healthBar.fillAmount = health/StartHealth;
        if(health<= 0){
            Die();
        }
    }

    void Die(){
        enemy.speed = 0f;

          
        float r = Random.Range(1f, 10.0f);
        if(r >2){
            Instantiate(diskPrefab,transform.position,Quaternion.identity);
        } 
        anim.SetTrigger("Die");
        
        Destroy(gameObject,.7f);
    }
}

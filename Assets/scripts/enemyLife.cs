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

    public Transform posicion;

    // seteando imagen 
    public Image imagen;
    public Sprite bicho;
    bool death = true;
    AudioSource audi;
    Animator anim;
 

    // Start is called before the first frame update
    void Start()
    {
      
         health = StartHealth;
         enemy = GetComponent<enemyFollow>();
         anim = GetComponent<Animator>();
         audi = GetComponent<AudioSource>();
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
        if(health<= 0 && death == true){
            Die();
            
        }
    }

    void Die(){
        death = false;
        enemy.speed = 0f;
        audi.Play();

          
        float r = Random.Range(1f, 10.0f);
        if(r >2){
            Instantiate(diskPrefab,posicion.position,posicion.rotation);
            Debug.Log(transform.position);
        } 
        anim.SetTrigger("Die");
        
        Destroy(gameObject,.7f);
    }
}

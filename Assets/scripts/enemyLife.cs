using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
        if(health< 100 &&  (this.gameObject.tag == "enemy") ){
            anim.SetTrigger("electric");
            enemy.speed= enemy.speed *1.25f;
        }
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

           StartCoroutine(spawn());
            
        } 
        anim.SetTrigger("Die");
        if(gameObject.tag == "boss"){
           StartCoroutine(endles());
        }
        Destroy(gameObject,.7f);
    }

IEnumerator endles(){
     yield return new WaitForSeconds(.68f);
    SceneManager.LoadScene("end");
}
    IEnumerator spawn(){
        yield return new WaitForSeconds(.68f);
         Instantiate(diskPrefab,posicion.position,posicion.rotation);
    }
}

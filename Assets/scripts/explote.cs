using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explote : MonoBehaviour
{
    private enemyLife life;
    public GameObject explosion;
     AudioSource audi;
     bool estallo = true;
    // Start is called before the first frame update
    void Start()
    {
        life = GetComponent<enemyLife>();
        audi = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(life.health <= 0 &&  estallo == true){
            GameObject efect = Instantiate(explosion,transform.position, Quaternion.identity);
           // audi.Play();
            Destroy(efect,.5f);
            estallo = false;
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explote : MonoBehaviour
{
    private enemyLife life;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        life = GetComponent<enemyLife>();
    }

    // Update is called once per frame
    void Update()
    {
        if(life.health <= 2){
            GameObject efect = Instantiate(explosion,transform.position, Quaternion.identity);
            Destroy(efect,.5f);
            Destroy(gameObject,.01f);
        }
    }
}

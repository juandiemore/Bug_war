using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poison : MonoBehaviour
{
    //public GameObject player;
    //Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

  void OnTriggerEnter2D(Collider2D other)
  {
      if(other.gameObject.tag == "Player"){
          //TODO sonido y vida

          other.GetComponent<Animator>().SetTrigger("poisoned");
      }
  }
}

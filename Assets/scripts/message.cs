using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class message : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }
   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.gameObject.tag == "Player"){
panel.SetActive(true);
       }
   }

      void OnTriggerExit2D(Collider2D other)
   {
       if(other.gameObject.tag == "Player"){
panel.SetActive(false);
       }
   }
}

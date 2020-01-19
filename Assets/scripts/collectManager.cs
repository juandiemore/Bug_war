using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class collectManager : MonoBehaviour
{
    public Text diskText;
    private shooting sh;

    public GameObject diskStack;
    public GameObject recarga;
    AudioSource audio;
    Animator animDiskStack;
    // Start is called before the first frame update

    //bool aux = true;
    void Start()
    {
        sh = GetComponent<shooting>();
        animDiskStack = diskStack.GetComponent<Animator>();
        audio = recarga.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        animDiskStack.SetInteger("disks",sh.inventoryBullets);
        if(sh.inventoryBullets <10){
        diskText.text = "0"+sh.inventoryBullets.ToString();
        }else{
            diskText.text = sh.inventoryBullets.ToString();
        }
    }
  
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "colectable" ){
            audio.Play();
          
            Destroy(other.gameObject,.01f);
            sh.inventoryBullets+=3;
        }
        
    }
}

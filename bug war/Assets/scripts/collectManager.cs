using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class collectManager : MonoBehaviour
{
    public Text diskText;
    private shooting sh;

    public GameObject diskStack;
    Animator animDiskStack;
    // Start is called before the first frame update


    void Start()
    {
        sh = GetComponent<shooting>();
        animDiskStack = diskStack.GetComponent<Animator>();
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
        if(other.gameObject.tag == "colectable"){
            Destroy(other.gameObject,.2f);
            sh.inventoryBullets+=3;
        }
        
    }
}

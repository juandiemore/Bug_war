using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class skip1 : MonoBehaviour
{
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
            if(Input.anyKey)
        {
            SceneManager.LoadScene("level");
        }
    }
}

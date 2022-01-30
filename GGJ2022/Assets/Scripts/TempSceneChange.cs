using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempSceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void ClickSound()
    {

        AkSoundEngine.PostEvent("Button", gameObject);

    }
   
    public void Jugar()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

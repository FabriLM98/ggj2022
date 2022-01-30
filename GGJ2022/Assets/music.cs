using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
     // Start is called before the first frame update
  private static GameObject instance;


 void Start() 
 {
     DontDestroyOnLoad(gameObject);
     if (instance == null){
         instance = gameObject;
         AkSoundEngine.SetState("Music", "Intro");
          AkSoundEngine.PostEvent("Play_Music", gameObject);
     }

     else{
         Destroy(gameObject);
     }
 }

    // Update is called once per frame
    void Update()
    {
        
    }
}

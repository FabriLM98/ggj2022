using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField] Text highScoreText;
    float highScore = 0;
    public float HighScoreValue
    {
        get
        {
            return highScore;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        highScore += Time.deltaTime;
        
        highScoreText.text = "Puntaje: " + (highScore).ToString("F2");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezManager : MonoBehaviour
{
    [SerializeField] GameObject pezPrefab;
    float timer = 0;
    [SerializeField] float timeBetweenSpawn = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenSpawn)
        {
            timer = 0;
            HacerAparecerPez();
        }
    }
    void HacerAparecerPez()
    {
        GameObject instancia = Instantiate(pezPrefab);
        instancia.transform.position = new Vector3(Random.Range(-2.3f, 2.3f), this.transform.position.y, 0);
    }
}

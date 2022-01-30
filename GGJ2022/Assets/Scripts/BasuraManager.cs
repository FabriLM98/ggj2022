using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasuraManager : MonoBehaviour
{
    [SerializeField] GameObject[] basuraPrefabs;
    float timer = 0;
    [SerializeField] float timeBetweenSpawn = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timeBetweenSpawn)
        {
            timer = 0;
            HacerAparecerBasura();
        }
    }
    void HacerAparecerBasura()
    {
        GameObject instancia = Instantiate(basuraPrefabs[Random.Range(0,basuraPrefabs.Length)]);
        instancia.transform.position = new Vector3(Random.Range(-2.8f,2.8f),this.transform.position.y,0);
        if (GameObject.Find("Pato").GetComponent<Pato>().DebajoDelAgua()) instancia.GetComponent<Basura>().HacerTrasparente();
    }
}

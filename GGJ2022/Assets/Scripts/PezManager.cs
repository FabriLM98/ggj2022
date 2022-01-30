using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezManager : MonoBehaviour
{
    [SerializeField] GameObject pezPrefab;
    [SerializeField] GameObject pezDoradoPrefab;
    float timer = 0;
    [SerializeField] float timeBetweenSpawn = 0.5f;

    float pezEmergenciaTimer = 10;
    float tiempoMaxEntrePezEmergencia = 10f;
    // Start is called before the first frame update
    private void OnEnable()
    {
        BarraEnergia.AdvertenciaBarraEnergia += AparecerPezDeAyudaSiCorresponde;
    }
    private void OnDisable()
    {
        BarraEnergia.AdvertenciaBarraEnergia -= AparecerPezDeAyudaSiCorresponde;
    }
    void Start()
    {

    }
    void Update()
    {
        if (pezEmergenciaTimer <= tiempoMaxEntrePezEmergencia) pezEmergenciaTimer += Time.deltaTime;

        timer += Time.deltaTime;
        if (timer > timeBetweenSpawn)
        {
            timer = 0;
            HacerAparecerPez();
        }
    }
    void AparecerPezDeAyudaSiCorresponde(float porcentaje)
    {
        if(pezEmergenciaTimer >= tiempoMaxEntrePezEmergencia)
        {
            pezEmergenciaTimer = 0;
            Invoke("HacerAparecerPezDorado", 1f);
        }
    }
    void HacerAparecerPezDorado()
    {
        GameObject instancia = Instantiate(pezDoradoPrefab);
        instancia.transform.position = new Vector3(Random.Range(-2.3f, 2.3f), this.transform.position.y, 0);
    }
    void HacerAparecerPez()
    {
        GameObject instancia = null;
        if (Random.Range(0f, 1f) < 0.07f)
        {
            instancia = Instantiate(pezDoradoPrefab);
        }
        else instancia = Instantiate(pezPrefab);
        instancia.transform.position = new Vector3(Random.Range(-2.3f, 2.3f), this.transform.position.y, 0);
    }
}

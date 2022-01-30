using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pez : MonoBehaviour
{
    bool comestible = false;
    [SerializeField] float speed = 2f;

    float energiaAportada = 20f;
    public delegate void ComerPez(float energiaAportada);
    public static event ComerPez PezComido;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    public void DesaparecioDePantalla()
    {
        Destroy(this.gameObject);
    }

    private void OnEnable()
    {
        Pato.SeZambullio += HacerComestible;
        Pato.SacoCabeza += HacerNoComestible;
    }
    private void OnDisable()
    {
        Pato.SeZambullio -= HacerComestible;
        Pato.SacoCabeza -= HacerNoComestible;
    }

    void HacerComestible()
    {
        comestible = true;
    }
    void HacerNoComestible()
    {
        comestible = false;
    }
    private void OnMouseDown()
    {
        if (EsComestible() && EstaEnRango())
        {
            PezComido(energiaAportada);
            Comido();
            //Invoke("Comido",0.2f);
        }
    }
    bool EstaEnRango()
    {
        return Vector2.Distance(GameObject.Find("Pato").transform.position, transform.position) <= 2.4f;
    }
    bool EsComestible()
    {
        return GameObject.Find("Pato").GetComponent<Pato>().DebajoDelAgua();
    }
    void Comido()
    {
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaDestruccion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Basura")
        {
            Basura basuraScript = collision.gameObject.GetComponent<Basura>();
            basuraScript.DesaparecioDePantalla();
        }
        if(collision.tag == "Pez")
        {
            Pez pezScript = collision.gameObject.GetComponent<Pez>();
            pezScript.DesaparecioDePantalla();
        }
    }
}

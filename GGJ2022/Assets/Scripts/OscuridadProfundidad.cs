using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscuridadProfundidad : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] float speed;
    bool oscurecer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (oscurecer)
        {
            HacerOpaco();
        }
        else HacerTrasparente();
    }
    private void OnEnable()
    {
        Pato.SeZambullio += Oscurecer;
        Pato.SacoCabeza += Aclarar;
    }
    private void OnDisable()
    {
        Pato.SeZambullio -= Oscurecer;
        Pato.SacoCabeza -= Aclarar;
    }
    void Oscurecer()
    {
        oscurecer = true;
    }
    void Aclarar()
    {
        oscurecer = false;
    }
    public void HacerTrasparente()
    {
        if (sr.color.a <= 0) return;
        Color nuevoColor = sr.color;
        nuevoColor.a -= Time.deltaTime * speed;
        sr.color = nuevoColor;
    }
    public void HacerOpaco()
    {
        if (sr.color.a >= 1f) return;
        Color nuevoColor = sr.color;
        nuevoColor.a += Time.deltaTime * speed;
        sr.color = nuevoColor;
    }
}

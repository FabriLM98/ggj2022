using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaLaguna : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] float speed;
    bool oscurecer = true;
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
        Pato.SeZambullio += Aclarar;
        Pato.SacoCabeza += Oscurecer;
    }
    private void OnDisable()
    {
        Pato.SeZambullio -= Aclarar;
        Pato.SacoCabeza -= Oscurecer;
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
        if (sr.color.a >= 0.6f) return;
        Color nuevoColor = sr.color;
        nuevoColor.a += Time.deltaTime * speed;
        sr.color = nuevoColor;
    }
}

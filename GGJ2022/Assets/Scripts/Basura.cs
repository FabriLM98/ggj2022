using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basura : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField]SpriteRenderer sr;

    [SerializeField]float damagePerHit = 10f;
    public float DamagePerHit
    {
        get
        {
            return damagePerHit;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * GameManager.globalSpeed* Time.deltaTime);
    }
    public void ColisionConPato()
    {
        Destroy(this.gameObject);
    }
    public void DesaparecioDePantalla()
    {
        Destroy(this.gameObject);
    }

    private void OnEnable()
    {
        Pato.SeZambullio += HacerTrasparente;
        Pato.SacoCabeza += HacerOpaco;
    }
    private void OnDisable()
    {
        Pato.SeZambullio -= HacerTrasparente;
        Pato.SacoCabeza -= HacerOpaco;
    }
    public void HacerTrasparente()
    {
        Color nuevoColor = sr.color;
        nuevoColor.a = 0.2f;
        sr.color = nuevoColor;
    }
    public void HacerOpaco()
    {
        Color nuevoColor = sr.color;
        nuevoColor.a = 1f;
        sr.color = nuevoColor;
    }
}

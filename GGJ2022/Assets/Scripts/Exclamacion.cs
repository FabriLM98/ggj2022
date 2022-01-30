using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exclamacion : MonoBehaviour
{
    [SerializeField] Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Mostrar()
    {
        anim.SetBool("visible", true);
    }
    public void Ocultar()
    {
        anim.SetBool("visible", false);
    }
    public bool EstaVisible()
    {
        return anim.GetBool("visible");
    }
}

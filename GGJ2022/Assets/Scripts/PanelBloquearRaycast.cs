using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBloquearRaycast : MonoBehaviour
{
    [SerializeField] Image panel;
    [SerializeField] float speed;
    [SerializeField] Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Encender()
    {
        anim.SetBool("visible", true);
        //StartCoroutine(transicionarEncender());
    }
    public void Apagar()
    {
        anim.SetBool("visible", false);
        //StartCoroutine(transicionarApagar());
    }
    IEnumerator transicionarEncender()
    {
        panel.raycastTarget = true;
        Color color = panel.color;
        while(color.a <= 1)
        {
            color.a += Time.deltaTime * speed;
            panel.color = color;
            yield return null;
        }

    }
    IEnumerator transicionarApagar()
    {
        panel.raycastTarget = false;
        Color color = panel.color;
        while (color.a > 0)
        {
            color.a -= Time.deltaTime * speed;
            panel.color = color;
            yield return null;
        }

    }
}

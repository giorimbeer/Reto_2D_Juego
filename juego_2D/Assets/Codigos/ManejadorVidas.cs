using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class ManejadorVidas : MonoBehaviour
{
    public List<Image> listaImgVidas = new List<Image>();
    public int contadorVidas = 0;

    public UnityEvent jugadorMurio;

    void Start()
    {
        contadorVidas = listaImgVidas.Count;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Morir"))
        {
            contadorVidas--;
            listaImgVidas[contadorVidas].gameObject.SetActive(false);
            if (contadorVidas == 0)
                jugadorMurio.Invoke();
        }
    }
}

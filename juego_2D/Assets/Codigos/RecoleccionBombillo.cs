using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class RecoleccionBombillo : MonoBehaviour
{
    public int cantidadBombillos;
    public int contadorBombillos;
    public Text txtContador;

    public UnityEvent terminoRecoleccion;

    private void Start()
    {
        txtContador.text = contadorBombillos + "/" + cantidadBombillos;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Bombillo")
        {
            contadorBombillos++;
            txtContador.text = contadorBombillos + "/" + cantidadBombillos;
            if (contadorBombillos == cantidadBombillos)
                terminoRecoleccion.Invoke();
        }
    }
}

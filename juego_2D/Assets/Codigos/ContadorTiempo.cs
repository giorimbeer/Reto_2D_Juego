using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ContadorTiempo : MonoBehaviour
{
    public float tiempoNivel;
    public Text txtTiempo;

    public UnityEvent tiempoTermino;
    // Start is called before the first frame update
    private bool estaCorriendo;
    void Start()
    {
        estaCorriendo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (estaCorriendo == true)
        {
            if (tiempoNivel > 0)
            {
                tiempoNivel -= Time.deltaTime;
                ConversionTiempo(tiempoNivel);
            }
            else {
                tiempoTermino.Invoke();
                tiempoNivel = 0;
                estaCorriendo = false;
            }
        }
    }

    private void ConversionTiempo(float tiempo)
    {
        tiempo += 1;
        float minutos = Mathf.FloorToInt(tiempo / 60);
        float segundos = Mathf.FloorToInt(tiempo % 60);
        txtTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}

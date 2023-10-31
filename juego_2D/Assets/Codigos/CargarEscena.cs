using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CargarEscena : MonoBehaviour
{
    public void Cargar(string nombre)
    {
        StartCoroutine(CargarAsincrona(nombre));
    }

    IEnumerator CargarAsincrona(string nombre)
    {
        AsyncOperation operacion = SceneManager.LoadSceneAsync(nombre);

        while (!operacion.isDone)
        {
            yield return null;
        }
    }
}

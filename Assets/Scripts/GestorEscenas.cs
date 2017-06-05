using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorEscenas : MonoBehaviour {

	public void cargarEscenaCrear()
    {
        SceneManager.LoadScene("Crear");
    }

    public void cargarEscenaJugar()
    {
        SceneManager.LoadScene("Jugar");
    }
}

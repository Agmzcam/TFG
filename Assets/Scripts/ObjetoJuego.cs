using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjetoJuego {

    public string nombrePartida;
    public List<string> nombresSimbolos = new List<string>();
    public List<bool[,]> matricesSimbolos = new List<bool[,]>();

    public ObjetoJuego(string nPartida)
    {
        nombrePartida = nPartida;
    }

    public void setPartida(string nSimbolo, bool[,] matrizSimbolo)
    {
        nombresSimbolos.Add(nSimbolo);
        matricesSimbolos.Add(matrizSimbolo);
    }

    public void guardarPartida()
    {
        GestorPersistencia.guardarDatos(this);
    }
}

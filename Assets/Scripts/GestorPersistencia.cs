using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GestorPersistencia {

	public static bool guardarDatos(ObjetoJuego partida)
    {
        try
        {
            string nombreFichero = partida.nombrePartida;
            BinaryFormatter formateador = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/" + nombreFichero + ".dat");
            Debug.Log("Se guarda en: " + Application.persistentDataPath + "/" + nombreFichero + ".dat");

            
            formateador.Serialize(file, partida);
            file.Close();
            return true;

        }
        catch (Exception e)
        {
            Debug.Log("Error Guardando: " + e);
            return false;
        }
    }

    public static ObjetoJuego cargarDatos(string nombrePartida)
    {
        if (File.Exists(nombrePartida))
        {
            BinaryFormatter formateador = new BinaryFormatter();
            FileStream file = File.Open(nombrePartida, FileMode.Open);
            ObjetoJuego data = (ObjetoJuego)formateador.Deserialize(file);
            file.Close();
            return data;
        }
        else
        {
            Debug.Log("El fichero no existe");
            return null;
        }
    }
}

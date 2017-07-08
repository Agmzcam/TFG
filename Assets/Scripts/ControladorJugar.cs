using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorJugar : MonoBehaviour {

    public GameObject panelPartidas;
    public GameObject panelInGame;
    public GameObject partidaBoton;
    public GameObject partidaBotonPadre;
    public GameObject lienzo;
    public GameObject pistaPostit;
    public GameObject pistaLibro;
    public GameObject pistaBola;
    public List<Text> textSimbolos;
    public GameObject imagenLienzo;

    private EjemploLeerFicheros ejemploLeerFicherosScript;
    private CreateStrokeMatrix createStrokeMatrixComponente;
    private Draw drawComponente;
    private List<ObjetoSimbolo> simbolos;
    private int[,] matrizCorrecta;

    void Start () {
        panelPartidas.SetActive(true);
        panelInGame.SetActive(false);
        pistaBola.SetActive(false);
        pistaLibro.SetActive(false);
        pistaPostit.SetActive(false);
        ejemploLeerFicherosScript = GetComponent<EjemploLeerFicheros>();
        ejemploLeerFicherosScript.MostrarPartidas(partidaBoton, partidaBotonPadre);
        createStrokeMatrixComponente = lienzo.GetComponent<CreateStrokeMatrix>();
        drawComponente = GetComponent<Draw>();
        createStrokeMatrixComponente.enabled = false;
        drawComponente.enabled = false;
        imagenLienzo.SetActive(false);
        simbolos = new List<ObjetoSimbolo>();
    }

    public void CargarPartida(string fich)
    {
        pistaLibro.SetActive(true);
        panelPartidas.SetActive(false);
        panelInGame.SetActive(true);
        simbolos = ejemploLeerFicherosScript.LeerPartida(fich);
        List<string> nombreSimbolos = new List<string>();
        foreach (ObjetoSimbolo s in simbolos)
        {
            nombreSimbolos.Add(s.nombre);
        }
        List<string> listaSimbolosAleatrorizada = AleatorizarSimbolos(nombreSimbolos);
        for (int i = 0; i < listaSimbolosAleatrorizada.Count; i++)
        {
            textSimbolos[i].text = listaSimbolosAleatrorizada[i];
        }
    }

    private List<string> AleatorizarSimbolos(List<string> nombres) //luego serán sprites
    {
        //List<string> listaSimbolos = ejemploLeerFicherosScript.LeerPartida(fichero);
        for (int i = 0; i < nombres.Count; i++)
        {
            string temp = nombres[i];
            int indiceRandom = Random.Range(0, nombres.Count);
            nombres[i] = nombres[indiceRandom];
            nombres[indiceRandom] = temp;
        }
        return nombres;
    }

    public void IntroducirClave (Button objeto)
    {
        Sprite clave = objeto.GetComponentInChildren<SpriteRenderer>().sprite; //imágenes de la clave
        GameObject pista = GameObject.Find(clave.name); // buscar la pista que tiene esa imagen
        string n = pista.GetComponentInChildren<Text>().text;
        matrizCorrecta = simbolos.Find(s => s.nombre == n).matriz;
        panelInGame.SetActive(false);
        lienzo.SetActive(true);
        drawComponente.enabled = true;
        createStrokeMatrixComponente.enabled = true;
        createStrokeMatrixComponente.CrearDibujoGO();
        imagenLienzo.SetActive(true);
    }

    public void ComprobarDibujo()
    {
        
    }

}

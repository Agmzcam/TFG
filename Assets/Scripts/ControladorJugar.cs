using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorJugar : MonoBehaviour {

    public GameObject panelPartidas;
    public GameObject partidaBoton;
    public GameObject partidaBotonPadre;
    public GameObject panelNegro;
    public GameObject lienzo;
    public GameObject pistaPostit;
    public GameObject pistaLibro;
    public GameObject pistaBola;
    public GameObject papel;
    public List<Text> textSimbolos;
    public Camera cam;
    public Camera mainCamara;
    public Button validar;
    public Button descartar;
    public bool taquillaAbierta = false;
    public bool tengoDestornillador = false;
    public Text tiempoText;

    private EjemploLeerFicheros ejemploLeerFicherosScript;
    private CreateStrokeMatrix createStrokeMatrixComponente;
    private Draw drawComponente;
    private List<ObjetoSimbolo> simbolos;
    private ControlCamara controladorCamaraScript;
    private int[,] matrizCorrecta;
    private int celdas = 10;
    private int threshold = 72;
    private int aciertosTaquilla = 0;
    private int aciertosTablet = 0;
    private int aciertosPuerta = 0;
    private Text pista;
    private GameObject claveActual;
    private AbrirObjetosCerrados abrirObjetosCerradosScript;
    private Stopwatch time;



    void Start () {
        time = new Stopwatch();
        panelPartidas.SetActive(true);
        panelNegro.SetActive(true);
        pistaBola.SetActive(false);
        pistaLibro.SetActive(false);
        pistaPostit.SetActive(false);
        ejemploLeerFicherosScript = GetComponent<EjemploLeerFicheros>();
        ejemploLeerFicherosScript.MostrarPartidas(partidaBoton, partidaBotonPadre);
        createStrokeMatrixComponente = lienzo.GetComponent<CreateStrokeMatrix>();
        drawComponente = GetComponent<Draw>();
        createStrokeMatrixComponente.enabled = false;
        drawComponente.enabled = false;
        simbolos = new List<ObjetoSimbolo>();
        controladorCamaraScript = cam.GetComponent<ControlCamara>();
        controladorCamaraScript.enabled = false;
        validar.gameObject.SetActive(false);
        descartar.gameObject.SetActive(false);
        abrirObjetosCerradosScript = GetComponent<AbrirObjetosCerrados>();
    }

    public void CargarPartida(string fich)
    {
        time.Start();
        papel.SetActive(false);
        panelNegro.SetActive(false);
        panelPartidas.SetActive(false);
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
        controladorCamaraScript.enabled = true;

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

    public void IntroducirClave (GameObject clave)
    {
        //Sprite clave = objeto.GetComponentInChildren<SpriteRenderer>().sprite; //imágenes de la clave  
        //GameObject pista = GameObject.Find(clave.name); // buscar la pista que tiene esa imagen
        claveActual = clave;
        cam.enabled = false;
        mainCamara.enabled = true;
        ClickClave.clickEnClave = false;
        papel.SetActive(true);
        pista = textSimbolos.Find(no => no.name == clave.name);
        string n = pista.GetComponentInChildren<Text>().text;
        print("el símbolo correcto es el que está en " + pista.name + "y es " + n);
        print("simbolo correcto " + n);
        matrizCorrecta = simbolos.Find(s => s.nombre == n).matriz;
        lienzo.SetActive(true);
        drawComponente.enabled = true;
        createStrokeMatrixComponente.enabled = true;
        createStrokeMatrixComponente.CrearDibujoGO();
        validar.gameObject.SetActive(true);
        descartar.gameObject.SetActive(false);
    }

    private void ActivarCamaraMundo()
    {
        cam.enabled = true;
        mainCamara.enabled = false;
        validar.gameObject.SetActive(false);
        lienzo.SetActive(false);
    }

    public void ComprobarDibujo()
    {
        int[,] m = new int[celdas, celdas];
        for (int f = 0; f < celdas; f++)
        {
            for (int c = 0; c < celdas; c++)
            {
                m[f, c] = createStrokeMatrixComponente.matrix[f, c];
            }
        }
        
        //float aciertos = CalcularPorcentajeAciertos(m);
        float aciertos = CalcularPorcentaje(m);
        print("aciertos: " + aciertos);
        if (aciertos >= threshold)
        {
            print("es correcto");
            print(claveActual.name);
            SpriteRenderer claSR = claveActual.GetComponent<SpriteRenderer>();
            claSR.color = Color.green;
            AddAciertos();
        }
        else
        {
            print("no es correcto");
        }
        createStrokeMatrixComponente.ResetMatriz();
        EliminarTrazo();
        ActivarCamaraMundo();
        ClickClave.clickEnClave = false;
    }

    private void AddAciertos()
    {
        switch(claveActual.name)
        {
            case "diap3":
                aciertosTablet += 1;
                break;
            case "rec1":
                aciertosTablet += 1;
                break;
            case "rec2":
                aciertosTablet += 1;
                break;
            case "dia3":
                aciertosTablet += 1;
                break;
            case "diap1":
                aciertosTaquilla += 1;
                break;
            case "rec3":
                aciertosTaquilla += 1;
                break;
            case "rec4":
                aciertosPuerta += 1;
                break;
            case "diap2":
                aciertosPuerta += 1;
                break;
            case "diap4":
                aciertosPuerta += 1;
                break;
            case "dia2":
                aciertosPuerta += 1;
                break;
            case "dia4":
                aciertosPuerta += 1;
                break;
            case "dia1":
                aciertosPuerta += 1;
                break;
        }
        ComprobarAbrirObjeto();
    }

    private void ComprobarAbrirObjeto()
    {
        print("comprobando abrir objetos");
        if (aciertosPuerta == 6)
        {
            time.Stop();
            string tiempo = time.Elapsed.ToString();
            tiempoText.text = "HAS CONSEGUIDO SALIR EN " + tiempo;
        }
        else if (aciertosTablet == 4)
        {
            abrirObjetosCerradosScript.ActivarClavePuerta();
        }
        else if (aciertosTaquilla == 2)
        {
            taquillaAbierta = true;
            abrirObjetosCerradosScript.AbrirTaquilla();
        }
    }

    private float CalcularPorcentaje (int[,] matrizJugador)
    {
        return Coincidencias(matrizJugador, matrizCorrecta);
    }

    public float CalcularPorcentajeAciertos (int [,] matrizJugador)
    {
        print("calculando porcentaje de aciertos");
        float porcentajeMaximoAciertos = 0;
        string nombreSimboloCercano = "";
        float aciertosActuales;
        for (int matriz = 0; matriz < simbolos.Count; matriz++)
        {
            //aciertosActuales = SumaAciertosMultiplicacion(matrizJugador, simbolos[matriz].matriz);
            aciertosActuales = Coincidencias(matrizJugador, simbolos[matriz].matriz);
            print("aciertos con " + simbolos[matriz].nombre + " " + aciertosActuales);
            if (aciertosActuales > porcentajeMaximoAciertos)
            {
                porcentajeMaximoAciertos = aciertosActuales;
                nombreSimboloCercano = simbolos[matriz].nombre;
                print("porcentaje maximo de aciertos: " + porcentajeMaximoAciertos);
                print("por ahora se acerca más a símbolo: " + nombreSimboloCercano);
            }
           
        }

        return porcentajeMaximoAciertos;
    }

    private float Coincidencias(int[,] m1, int[,] m2)
    {
        float aciertos = 0;
        for (int f = 0; f < celdas; f++)
        {
            for (int c = 0; c < celdas; c++)
            {
                if (m1[f, c] == m2[f, c])
                    aciertos += 1;
            }
        }
        return aciertos * 100/(celdas* celdas);
    }

    public float SumaAciertosMultiplicacion(int[,]m1, int[,]m2)
    {
        print("en sumaaciertos multiplicacion");
        int[,] multiplicacion = new int[celdas, celdas];
        int columna = 0;
        int resultado = 0;
        int f = 0;
        float aciertos = 0;
        while (f < celdas)
        {
            for (int c = 0; c < celdas; c++)
            {
                resultado += m1[f, c] * m2[c, columna];
            }
            multiplicacion[f, columna] = resultado;
            resultado = 0;
            if (columna == celdas-1)
            {
                columna = 0;
                f++;
            }
            else
            {
                columna += 1;
            }

        }
       
        for (int fi = 0; fi < celdas; fi++)
        {
            for (int c = 0; c < celdas; c++)
            {
                if (multiplicacion[fi, c] != 0)
                {
                    aciertos += multiplicacion[fi,c];
                }
                    
            }
        }
        return aciertos;
    }


    public void Borrar()
    {
        EliminarTrazo();
        createStrokeMatrixComponente.CrearDibujoGO();
    }

    public void EliminarTrazo()
    {
        GameObject drawGO = GameObject.FindGameObjectWithTag("drawObject");
        if (drawGO)
            Destroy(drawGO);
    }

    public void CogerDestornillador()
    {
        tengoDestornillador = true;
    }

}

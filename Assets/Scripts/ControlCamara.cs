using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour {
    public float smooth = 2.0F;
    public float tiltAngle = 30.0F;
    public bool zoom = false;
    public GameObject tablet;

    public Vector3 posicionInicial;
    Quaternion rotacionInicial;
    bool hacerClick = true;
    

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(1) && hacerClick)
        {

            Debug.Log("intentando girar");

            hacerClick = false;
            if (zoom)
                StartCoroutine(Zoom(posicionInicial));
            else
                StartCoroutine(RotarCamaraDerecha());
        }

    }

    private IEnumerator RotarCamaraDerecha() {

        float initialAngle = this.gameObject.transform.eulerAngles.y;
        float actualAngle = initialAngle;
        float desiredAngle = initialAngle + 90;
        float turningSpeed = 2f;

        

        while (actualAngle < desiredAngle)
        {
            actualAngle += turningSpeed;

            this.gameObject.transform.rotation = Quaternion.Euler(0, actualAngle, 0);

            yield return null;
        }
        hacerClick = true;

    }

    public IEnumerator Zoom(Vector3 target)
    {
        bool girar;
        print("haciendo zoom");
        if (posicionInicial == target)
        {
            girar = false;
            if (ClickEnTablet.mirandoTablet)
            {
                print("alejandonme de tablet");
                float actualAngle = this.gameObject.transform.eulerAngles.x;
                float desiredAngle = this.gameObject.transform.eulerAngles.x - 90;
                while (actualAngle > desiredAngle)
                {
                    actualAngle -= 2f;

                    this.gameObject.transform.rotation = Quaternion.Euler(actualAngle, 0, 0);
                    yield return null;
                }
            }
            ClickEnTablet.mirandoTablet = false;
        }
        else
        {
            posicionInicial = this.transform.position;
            rotacionInicial = this.transform.rotation;
            girar = true;
        }

        float velocidad = 2f;

        while (Vector3.Distance(transform.position, target) > 0.05f) {

            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * velocidad);

            yield return null;

        }
        print("termina zoom, zoom es: "+ zoom);
        zoom = girar;
        hacerClick = true;
        if (ClickEnTablet.mirandoTablet)
        {
            float actualAngle = this.gameObject.transform.eulerAngles.x;
            float desiredAngle = this.gameObject.transform.eulerAngles.x + 90;
            while (actualAngle < desiredAngle)
            {
                actualAngle += 2f;

                this.gameObject.transform.rotation = Quaternion.Euler(actualAngle, 0, 0);
                yield return null;
            }
        }

    }

 

}

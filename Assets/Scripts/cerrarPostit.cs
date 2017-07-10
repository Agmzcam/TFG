using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class cerrarPostit : MonoBehaviour, IPointerClickHandler
{
    public GameObject panelNegro;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (ClickenPistaPostit.pistaAbierta)
        {
            panelNegro.SetActive(false);
            this.gameObject.SetActive(false);
            ClickenPistaPostit.pistaAbierta = false;
        }
    }
}

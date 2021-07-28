using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class Conector : MonoBehaviour,IPointerClickHandler
{
    public static event Action<GameObject> Onclick;
    [SerializeField]public bool estado { get; set; }
    private bool estadoInterno;
    private Publicador publicador;
    public void OnPointerClick(PointerEventData eventData)
    {
        Onclick?.Invoke(gameObject);
    }

    private void Awake()
    {
        estado = false;
        estadoInterno = estado;
        publicador = GetComponent<Publicador>();
    }
    // Update is called once per frame
    void Update()
    {
        if(estadoInterno != estado)
        {
            estadoInterno = estado;
            publicador.notificar(estado);
        }
        if (estado)
        {
            GetComponent<Image>().color = Color.red;
        }
        else
        {
            GetComponent<Image>().color = Color.black;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assinante : MonoBehaviour
{

    private Conector conector;
    // Start is called before the first frame update
    void Start()
    {
        conector = GetComponent<Conector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void atualizar(bool estado)
    {
        conector.estado = estado;
    }
}

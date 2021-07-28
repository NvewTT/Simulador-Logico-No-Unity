using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
using CodeMonkey.Utils;
public class LineControl : MonoBehaviour
{
    Transform comecoDaLinha;
    Transform finalDaLinha;
    SpriteRenderer sprite;
    Line line;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        sprite.color = Color.black;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (comecoDaLinha != null && finalDaLinha != null)
        {
            setPosicao();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnMouseEnter()
    {
        if (GameControler.lixeiraLigada)
        {
            sprite.color = Color.red;
        }
    }
    private void OnMouseExit()
    {
        if (GameControler.lixeiraLigada)
        {
            sprite.color = Color.black;
        }
    }
    private void OnMouseDown()
    {
        if (GameControler.lixeiraLigada)
        {
            Destroy(gameObject);
        }
    }

    private void desconectaConectores()
    {   
        Assinante conectorAssinante = finalDaLinha.GetComponent<Assinante>();
        Publicador connectorPublicador = comecoDaLinha.GetComponent<Publicador>();
        connectorPublicador.removeAssinante(conectorAssinante);
    }

    public void setComecoEFinalDaLinha(Transform comecoDaLinha, Transform finalDaLinha)
    {
        this.comecoDaLinha = comecoDaLinha;
        this.finalDaLinha = finalDaLinha;
        setPosicao();
    }

    private void setPosicao()
    {
        Vector3 direcao = (finalDaLinha.position - comecoDaLinha.position).normalized;
        float distancia = Vector3.Distance(comecoDaLinha.position, finalDaLinha.position);
        transform.position = new Vector3(comecoDaLinha.position.x, comecoDaLinha.position.y,0) ;
        transform.localScale = new Vector3(distancia, 0.5f, 1);
        float anguloEntreOPontoInicialEOFinal = UtilsClass.GetAngleFromVectorFloat(direcao);
        transform.localEulerAngles = new Vector3(0, 0, anguloEntreOPontoInicialEOFinal);
    }
    private void OnDestroy()
    {
        if(comecoDaLinha != null && finalDaLinha != null)
        {
            desconectaConectores();
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaComponent : MonoBehaviour
{

    private CriarEntradasESaidas criarEntradasESaidas;
    public List<GameObject> entradasComponentes;
    public GameObject saidaComponent;
    private Conector saidaConector;
    public ILogica logica;
    private void Awake()
    {
        criarEntradasESaidas = GetComponent<CriarEntradasESaidas>();
    }
    public void setLogica(ILogica logica)
    {
        this.logica = logica;
    }
    private void Start()
    {
        entradasComponentes = criarEntradasESaidas.entradasGameObjects;
        saidaComponent = criarEntradasESaidas.saidaComponent;
        saidaConector = saidaComponent.GetComponent<Conector>();

    }
    // Update is called once per frame
    void Update()
    {
        saidaConector.estado = logica.setSaida(entradasComponentes);
    }

    private void OnDestroy()
    {
        Publicador saidaPublicador = saidaComponent.GetComponent<Publicador>();
        saidaPublicador.notificar(false);
    }
}

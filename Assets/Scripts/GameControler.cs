using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System;

public class GameControler : MonoBehaviour
{
    [SerializeField] private Transform canvas;
    [SerializeField] private GameObject componentAndOuOrPrefab;
    [SerializeField] private GameObject componentNotPrefab;
    [SerializeField] private GameObject linhaPrefab;
    [SerializeField] private Transform entradaLayoutUI;
    [SerializeField] private Transform saidaLayoutUI;
    [SerializeField] private GameObject entradaUIPrefab;
    [SerializeField] private GameObject SaidaUIPrefab;
    private List<GameObject> conectores = new List<GameObject>();
    private Stack<GameObject> entradasUI = new Stack<GameObject>();
    private Stack<GameObject> saidasUI = new Stack<GameObject>();
    public static bool lixeiraLigada;
    [SerializeField] private Transform butaoAnd;
    [SerializeField] private Transform butaoOr;
    [SerializeField] private Transform butaoNot;
    [SerializeField] private Transform butaoAddEntrada;
    [SerializeField] private Transform butaoRemoveEntrada;
    [SerializeField] private Transform butaoAddSaida;
    [SerializeField] private Transform butaoRemoveSaida;


    private void Awake()
    {
        lixeiraLigada = false;

        var butaoAndobj = butaoAnd.GetComponent<Button_UI>();
        butaoAndobj.ClickFunc = () => { criaComponenteAndOuOr(new LogicaAND(), "AND"); };
        var butaoOrobj = butaoOr.GetComponent<Button_UI>();
        butaoOrobj.ClickFunc = () => { criaComponenteAndOuOr(new LogicaOR(), "OR"); };
        var butaoNotobj = butaoNot.GetComponent<Button_UI>();
        butaoNotobj.ClickFunc = () => { criaComponenteNot(new LogicaNot(), "NOT"); };
        var butaoAddEntradaobj = butaoAddEntrada.GetComponent<Button_UI>();
        butaoAddEntradaobj.ClickFunc = () => { criaEntradaUI(); };
        var butaoRemoveEntradaobj = butaoRemoveEntrada.GetComponent<Button_UI>();
        butaoRemoveEntradaobj.ClickFunc = () => { removeEntradaUI(); };
        var butaoAddSaidaobj = butaoAddSaida.GetComponent<Button_UI>();
        butaoAddSaidaobj.ClickFunc = () => { criaSaidaUI(); };
        var butaoRemoveSaidaobj = butaoRemoveSaida.GetComponent<Button_UI>();
        butaoRemoveSaidaobj.ClickFunc = () => { removeSaidaUI(); };
    }

    private void removeSaidaUI()
    {
        if(saidasUI.Count > 0) 
        {
            var saidaRemovida = saidasUI.Pop();
            Destroy(saidaRemovida);
        }

    }

    private void removeEntradaUI()
    {
        if(entradasUI.Count > 0)
        {
            var entradaRemovida = entradasUI.Pop();
            Destroy(entradaRemovida);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Conector.Onclick += handleClick;
        criaEntradaUI();
        criaSaidaUI();
    }

    private void handleClick(GameObject conector)
    {
        conectores.Add(conector);
    }

    // Update is called once per frame
    void Update()
    {
        if(conectores.Count == 2)
        {
            conectaConectores();
            criaLinhaEntreDuasEntradas(conectores[0].transform, conectores[1].transform);
            conectores.Clear();
        }

        if (Input.GetKeyDown("p"))
        {
            criaEntradaUI();
        }
        if (Input.GetKeyDown("s"))
        {
            criaSaidaUI();
        }     

    }

    private void conectaConectores()
    {
        Publicador publicador = conectores[0].GetComponent<Publicador>();
        publicador.adicionaAssinante(conectores[1].GetComponent<Assinante>());
        bool estadoDoPublicador = conectores[0].GetComponent<Conector>().estado;
        publicador.notificar(estadoDoPublicador);

    }

    private void criaLinhaEntreDuasEntradas(Transform entrada, Transform saida)
    {
        var linhaComponent = Instantiate(linhaPrefab);
        var linhaControl = linhaComponent.GetComponent<LineControl>();
        linhaControl.setComecoEFinalDaLinha(entrada, saida);
    }
    private void criaComponenteAndOuOr(ILogica logica,string nome)
    {
        var component = Instantiate(componentAndOuOrPrefab);
        component.transform.SetParent(canvas);
        component.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        var logicaComponent = component.GetComponent<LogicaComponent>();
        logicaComponent.setLogica(logica);
        var textMeshPro = component.GetComponent<SetName>();
        textMeshPro.setName(nome);
        var dragComponent = component.GetComponent<Drag>();
        dragComponent.setCanvas(canvas.GetComponent<Canvas>());
    }
    private void criaComponenteNot(ILogica logica, string nome)
    {
        var component = Instantiate(componentNotPrefab);
        component.transform.SetParent(canvas);
        component.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        var logicaComponent = component.GetComponent<LogicaComponent>();
        logicaComponent.setLogica(logica);
        var textMeshPro = component.GetComponent<SetName>();
        textMeshPro.setName(nome);
        var dragComponent = component.GetComponent<Drag>();
        dragComponent.setCanvas(canvas.GetComponent<Canvas>());
    }

    private void criaEntradaUI()
    {
        var entradaUIComponent = Instantiate(entradaUIPrefab);
        entradaUIComponent.transform.SetParent(entradaLayoutUI);
        entradaUIComponent.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        entradasUI.Push(entradaUIComponent);
    }
    private void criaSaidaUI()
    {
        var saidadaUIComponent = Instantiate(SaidaUIPrefab);
        saidadaUIComponent.transform.SetParent(saidaLayoutUI);
        saidadaUIComponent.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        saidasUI.Push(saidadaUIComponent);
    }
    public void ligarLixeira()
    {
        lixeiraLigada = !lixeiraLigada;
    }


}

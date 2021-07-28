using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriarEntradasESaidas : MonoBehaviour
{
    [SerializeField] private ComponentConfig componentConfig;
    public Transform entradaPosicao;
    public Transform saidaPosicao;
    public GameObject saidaComponent { get; private set; }
    public List<GameObject> entradasGameObjects { get; private set; }

    private void Awake()
    {
        entradasGameObjects = new List<GameObject>();
        for(int i = 0; i < componentConfig.quantidadeDeEntradas; i++)
        {
            var entrada = Instantiate(componentConfig.entradaPrefab);
            entrada.transform.SetParent(entradaPosicao);
            entrada.transform.localScale = new Vector3(1, 1, 1);
            entradasGameObjects.Add(entrada);
        }

        var saida = Instantiate(componentConfig.saidaPrefab);
        saida.transform.SetParent(saidaPosicao);
        saida.transform.localScale = new Vector3(1, 1, 1);
        saidaComponent = saida;

    }

}

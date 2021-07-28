using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SaidaUI : MonoBehaviour
{
    [SerializeField] private GameObject conector;
    [SerializeField] private Sprite botaoOff;
    [SerializeField] private Sprite botaoOn;
    private Image imagem;
    private Conector conetorComponent;

    private void Awake()
    {
        conetorComponent = conector.GetComponent<Conector>();
        imagem = GetComponent<Image>();
        imagem.sprite = botaoOff;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (conetorComponent.estado)
        {
            imagem.sprite = botaoOn;
        }
        else
        {
            imagem.sprite = botaoOff;
        }
    }
}

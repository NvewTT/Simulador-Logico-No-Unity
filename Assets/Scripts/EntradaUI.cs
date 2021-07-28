using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class EntradaUI : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private GameObject conector;
    [SerializeField] private Sprite botaoOff;
    [SerializeField] private Sprite botaoOn;
    private Image imagem;
    private Conector conetorComponent;
    private bool estado;

    public void OnPointerClick(PointerEventData eventData)
    {
        estado = !estado;
        conetorComponent.estado = estado;
    }

    private void Awake()
    {
        estado = false;
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
        if (estado)
        {
            imagem.sprite = botaoOn;
        }
        else
        {
            imagem.sprite = botaoOff;
        }
    }
}

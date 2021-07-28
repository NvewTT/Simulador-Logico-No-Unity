using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ClickLixeira : MonoBehaviour,IPointerClickHandler
{
    Image image;
    private bool estado;
    public void OnPointerClick(PointerEventData eventData)
    {
        estado = !estado;
    }
    private void Awake()
    {
        image = transform.GetChild(0).GetComponent<Image>();
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
            image.color = Color.red;
        }
        else
        {
            image.color = Color.black;
        }
    }
}

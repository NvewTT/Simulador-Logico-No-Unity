using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetName : MonoBehaviour
{
    public TMP_Text titulo;

    public void setName(string nome)
    {
        titulo.text = nome;
    }
}

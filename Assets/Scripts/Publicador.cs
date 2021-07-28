using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Publicador : MonoBehaviour
{
    [SerializeField] List<Assinante> assinantes = new List<Assinante>();
    public void adicionaAssinante(Assinante assinante)
    {
        assinantes.Add(assinante);
    }
    public void removeAssinante(Assinante assinante)
    {
        if (assinantes.Contains(assinante))
        {
            assinantes.Remove(assinante);
        }
    }
    public void notificar(bool estado)
    {
        for (int i = assinantes.Count - 1; i >= 0; i--)
        {
            if (assinantes[i] == null)
            {
                assinantes.RemoveAt(i);
            }
            else
            {
                assinantes[i].atualizar(estado);
            }
        }
    }
    private void OnDestroy()
    {
        assinantes.Clear();
    }
}

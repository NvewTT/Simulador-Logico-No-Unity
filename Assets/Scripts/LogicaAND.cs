using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaAND : ILogica
{
 
    public bool setSaida(List<GameObject> entradasComponentes)
    {
        var somaTodosOsEstados = 0;
        foreach (var entradaComponent in entradasComponentes)
        {
            var entradaConector = entradaComponent.GetComponent<Conector>();
            somaTodosOsEstados += entradaConector.estado ? 1 : 0;
        }
        if (somaTodosOsEstados == entradasComponentes.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

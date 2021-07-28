using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ComponentConfig")]
public class ComponentConfig : ScriptableObject
{
    public GameObject entradaPrefab;
    public GameObject saidaPrefab;
    public int quantidadeDeEntradas;
}

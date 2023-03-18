using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{

    [SerializeField] private List<Renderer> _renderer;

    public void SetMaterial(Material material) 
    {
        foreach (Renderer render in _renderer)
        {
            render.material = material;
        }
    }

}

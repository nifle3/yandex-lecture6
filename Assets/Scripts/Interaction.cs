using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    [SerializeField] private Camera _camera;

    void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit)) 
        {
            if (hit.collider.TryGetComponent(out Clickable clickable)) 
            {
                if (Input.GetMouseButtonDown(0))
                {
                    clickable.ClickSpawn();
                }
            }

            else if (hit.collider.TryGetComponent(out Coin3D coin3D))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    coin3D.Hit();
                }
            }
        }

    }
}
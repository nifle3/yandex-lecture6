using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin3DSpawner : MonoBehaviour
{
    [SerializeField] private Coin3D _coin3dPrefab;
    [SerializeField] private Resources _res;

    public void ToSpawnCoin()
    {
        System.Random rnd = new System.Random();

        Vector3 targetPosition = new Vector3(rnd.Next(-2,4), 0, rnd.Next(-2,4));
        Coin3D newCoin3D = Instantiate(_coin3dPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        newCoin3D.Resources = _res;

        newCoin3D.Move(targetPosition);
    }
}

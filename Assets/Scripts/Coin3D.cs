using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin3D : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private HitEffect _hitEffectPrefab;

    static private int _coinsPerClick = 1;

    public Resources Resources { set; get; }

    public void Move(Vector3 targetPositon)
    {
        StartCoroutine(MoveTo(targetPositon, transform.position));
    }

    private IEnumerator MoveTo(Vector3 t, Vector3 o)
    {
        for (float time = 0; time < 2f; time += Time.deltaTime)
        {
            float x = Mathf.Lerp(o.x, t.x, time);

            float z = Mathf.Lerp(o.z, t.z, time);

            float y = _curve.Evaluate(time);

            Vector3 position = new Vector3(x, y, z);
            transform.position = position;
            yield return null;
        }
    }

    public void Hit()
    {
        HitEffect hitEffect = Instantiate(_hitEffectPrefab, new Vector3(0,0,0), Quaternion.identity);
        hitEffect.Init(_coinsPerClick);
        Resources.CollectCoins(1, transform.position);

        Destroy(gameObject);
    }

    public void AddCoinsPerClick(int value)
    {
        _coinsPerClick += value;
    }
}

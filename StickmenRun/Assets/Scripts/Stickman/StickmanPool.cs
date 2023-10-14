using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StickmanPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _poolSize;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject stickman = Instantiate(prefab, _container.transform);
            stickman.SetActive(false);
            _pool.Add(stickman);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.First(p => p.activeSelf == false);
        return result != null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bounse : MonoBehaviour
{
    [SerializeField] private int _maxBounse;
    [SerializeField] private TMP_Text _text;
    
    private int _bounse;

    public int BounseValue => _bounse;

    private void Start()
    {
        _bounse = Random.Range(1,_maxBounse);
        _text.text = _bounse.ToString();
    }
}

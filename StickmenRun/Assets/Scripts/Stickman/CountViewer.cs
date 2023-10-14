using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountViewer : MonoBehaviour
{
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void FixedUpdate()
    {
        _text.text = AiManager.Instance.Units.Count.ToString();
    }
}

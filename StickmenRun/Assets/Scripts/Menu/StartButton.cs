using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private StickmanMovement _stickmanMovement;

    public void StartLevel()
    {
        _stickmanMovement.enabled = true;
        _menu.SetActive(false);
    }
}

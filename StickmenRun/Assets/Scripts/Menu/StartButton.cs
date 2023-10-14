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

        foreach (AiUnit unit in AiManager.Instance.Units)
        {
            unit.SetAnim(8);
        }
        _menu.SetActive(false);
    }
}

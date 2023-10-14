using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent),typeof(Character_control))]
[DefaultExecutionOrder(1)]
public class AiUnit : MonoBehaviour
{
    [SerializeField] private GameObject _bolt;

    private Character_control _characterControl;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _characterControl = GetComponent<Character_control>();
    }

    public void SetAnim(int numberAnimation)
    {
        _characterControl.animationNumber = numberAnimation;
        _characterControl.StartAnimation();
    }

    public void MoveTo(Vector3 position)
    {
        _agent.SetDestination(position);
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    private void OnEnable()
    {
        AiManager.Instance.Units.Add(this);
    }

    private void OnDisable()
    {
        AiManager.Instance.Units.Remove(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Trap trap))
        {
            GameObject bolt = Instantiate(_bolt, transform.parent);
            bolt.transform.position = new Vector3(transform.position.x, 0.01f, transform.position.z);
            gameObject.SetActive(false);
        }

        if (other.gameObject.TryGetComponent(out Bounse bounse))
        {
            AiManager.Instance.AddStickman(bounse.BounseValue);
            bounse.gameObject.SetActive(false);
        }
    }
}

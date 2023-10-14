using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(0)]
public class AiManager : StickmanPool
{
    private static AiManager _instance;

    public static AiManager Instance
    {
        get
        {
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }

    [SerializeField] private Transform _target;
    [SerializeField] private float _radiusAroundTarget = 0.5f;
    [SerializeField] private GameObject _stickmanPrefab;
    [SerializeField] private int _countStickman;
    public List<AiUnit> Units = new List<AiUnit>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    private void Start()
    {
        Initialize(_stickmanPrefab);

        for (int i = 0; i < _countStickman; i++)
        {
            if (TryGetObject(out GameObject stickman))
            {
                SetStickman(stickman, _target.position);
            }
        }
        SetStartPositionTarget();
    }

    public void AddStickman(int value)
    {
        for (int i = 0; i < value; i++)
        {
            if (TryGetObject(out GameObject stickman))
            {
                SetStickman(stickman,_target.position);
                AiUnit aiUnit = stickman.GetComponent<AiUnit>();
                aiUnit.SetAnim(8);
            }
        }
    }

    private void SetStickman(GameObject stickman, Vector3 position)
    {
        stickman.SetActive(true);
        stickman.transform.position = position;
    }

    private void FixedUpdate()
    {
        MakeAgentsCircleTarget();
    }

    private void SetStartPositionTarget()
    {
        float goldenAngle = Mathf.PI * (3 - Mathf.Sqrt(5));

        for (int i = 0; i < Units.Count; i++)
        {
            float theta = i * goldenAngle;
            float radius = Mathf.Sqrt(i * (Units.Count * _radiusAroundTarget)) / Mathf.Sqrt(Units.Count);

            Units[i].SetPosition(new Vector3(
                _target.position.x + radius * Mathf.Cos(theta),
                _target.position.y,
                _target.position.z + radius * Mathf.Sin(theta)
                ));
        }
    }

    private void MakeAgentsCircleTarget()
    {
        float goldenAngle = Mathf.PI * (3 - Mathf.Sqrt(5));

        for (int i = 0; i < Units.Count; i++)
        {
            float theta = i * goldenAngle;
            float radius = Mathf.Sqrt(i * (Units.Count * _radiusAroundTarget)) / Mathf.Sqrt(Units.Count);

            Units[i].MoveTo(new Vector3(
                _target.position.x + radius * Mathf.Cos(theta),
                _target.position.y,
                _target.position.z + radius * Mathf.Sin(theta)
                ));
        }
    }

    private void OnDrawGizmos()
    {
        float goldenAngle = Mathf.PI * (3 - Mathf.Sqrt(5));

        for (int i = 0; i < Units.Count; i++)
        {
            float theta = i * goldenAngle;
            float radius = Mathf.Sqrt(i * (Units.Count * _radiusAroundTarget)) / Mathf.Sqrt(Units.Count);

            Gizmos.DrawCube(new Vector3(
                _target.position.x + radius * Mathf.Cos(theta),
                _target.position.y,
                _target.position.z + radius * Mathf.Sin(theta)
                ), new Vector3(0.1f, 0.1f, 0.1f));
        }
    }
}

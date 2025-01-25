using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ìGÇÃä«óù
/// </summary>
public class EnemyController : BaseUpdatable
{
   [SerializeField] private List<BaseEnemy> _baseEnemy = new List<BaseEnemy>();
    private EnemyStateController _stateManager;
    private EnemyAnimatorController _animatorController;
    private Rigidbody2D _rb;

    [SerializeField] private float walkSpeed = 2f;
    public static EnemyController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void EnemyRegister(BaseEnemy baseEnemy)
    {
        if (!_baseEnemy.Contains(baseEnemy))
        {
            _baseEnemy.Add(baseEnemy);
        }
    }
    public void EnemyUnregister(BaseEnemy baseEnemy)
    {
        if (_baseEnemy.Contains(baseEnemy))
        {
            _baseEnemy.Remove(baseEnemy);
        }
    }
    public override void OnUpdate()
    {
        foreach(BaseEnemy baseEnemy in _baseEnemy)
        {
            baseEnemy.EnemyUpadate();
        }
    }
}

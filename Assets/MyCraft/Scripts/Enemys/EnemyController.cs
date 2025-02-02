using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// “G‚ÌŠÇ—
/// </summary>
public class EnemyController : BaseUpdatable
{
   [SerializeField] private List<BaseEnemy> _baseEnemy = new List<BaseEnemy>();

    [SerializeField] private float walkSpeed = 2f;

   
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
            baseEnemy.EnemyUpdate();
        }
    }
}

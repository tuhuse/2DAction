using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    private BaseBodyEquipment _baseBodyEquipment;
    private BaseWeapon _weapon;
    private BaseDistanceEnemy _distanceEnemy;
    public int BodyDeffence => _baseBodyEquipment.Deffence;
    private void Start()
    {
        // 必要なコンポーネントを取得
        _baseBodyEquipment = GetComponent<NomalBodyEquipment>();
        _weapon = GetComponent<SordWeapon>();
        _distanceEnemy = GetComponent<BaseDistanceEnemy>();
        // コンポーネントが存在しない場合の警告
        if (_baseBodyEquipment== null) Debug.LogWarning("BasePlayerWalk component is missing!");
        if (_weapon == null) Debug.LogWarning("BasePlayerAttack component is missing!");
    }

    public void RightWalk()
    {
        if (_baseBodyEquipment != null)
        {
            _baseBodyEquipment.RightWalk();
        }
        else
        {
            _baseBodyEquipment = gameObject.AddComponent<NomalBodyEquipment>();
        }
    }

    public void LeftWalk()
    {
        if (_baseBodyEquipment != null)
        {
            _baseBodyEquipment.LeftWalk();
        }
        else
        {
            _baseBodyEquipment = gameObject.AddComponent<NomalBodyEquipment>();
        }
    }

    public void Jump()
    {
        if (_baseBodyEquipment != null)
        {
            _baseBodyEquipment.Jump();
        }
        else
        {
            _baseBodyEquipment = gameObject.AddComponent<NomalBodyEquipment>();
        }
    }

    public void Attack()
    {
        if (_distanceEnemy.CanAttack)
        {
            if (_weapon != null)
            {
                _weapon.TryAttack();
            }
            else
            {
                _weapon = gameObject.AddComponent<SordWeapon>();
            }
            
        }
        
    }
}

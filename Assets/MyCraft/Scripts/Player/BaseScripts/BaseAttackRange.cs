using UnityEngine;
/// <summary>
/// Uออ
/// </summary>
public abstract class BaseAttackRange : MonoBehaviour
{
    [SerializeField]
    protected Transform[] _enemies;          // GฬTransformz๑
    protected Transform _nearestEnemy;       // ๊ิ฿ขGฬTransform
    protected const float DETECTION_RADIUS = 10f;  // G๐oท้ลๅฃ
    public bool CanAttack { get; set; }
   

   protected void Update()
    {
        FindNearestEnemy();
   
    }

    /// <summary>
    /// ลเ฿ขG๐ฉยฏ้
    /// </summary>
    protected abstract void FindNearestEnemy();
}

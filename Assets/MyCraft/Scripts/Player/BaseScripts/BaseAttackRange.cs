using UnityEngine;
/// <summary>
/// UŒ‚”ÍˆÍ
/// </summary>
public abstract class BaseAttackRange : MonoBehaviour
{
    [SerializeField]
    protected Transform[] _enemies;          // “G‚ÌTransform”z—ñ
    protected Transform _nearestEnemy;       // ˆê”Ô‹ß‚¢“G‚ÌTransform
    protected const float DETECTION_RADIUS = 10f;  // “G‚ğŒŸo‚·‚éÅ‘å‹——£
    public bool CanAttack { get; set; }
   

   protected void Update()
    {
        FindNearestEnemy();
   
    }

    /// <summary>
    /// Å‚à‹ß‚¢“G‚ğŒ©‚Â‚¯‚éˆ—
    /// </summary>
    protected abstract void FindNearestEnemy();
}

using UnityEngine;
/// <summary>
/// �G�̃A�j���[�V�����Ǘ�
/// </summary>
public class EnemyAnimatorController : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayIdle()
    {
        _animator.SetTrigger("Idle");
    }

    public void PlayWalk()
    {
        _animator.SetTrigger("Walk");
    }

    public void PlayAttack()
    {
        _animator.SetTrigger("Attack");
    }

    public void PlayDie()
    {
        _animator.SetTrigger("Die");
    }

    public void SetMovementSpeed(float speed)
    {
        _animator.SetFloat("Speed", speed);
    }
}

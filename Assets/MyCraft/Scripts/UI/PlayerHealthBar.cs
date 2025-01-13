using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider; // HP�o�[�p�̃X���C�_�[
    private PlayerStatus _playerStatus;           // �v���C���[�̃X�e�[�^�X

    // ������
    public void Initialize(PlayerStatus status)
    {
        _playerStatus = status;
        _healthSlider.maxValue = PlayerStatus. BASE_HEALTH; // �X���C�_�[�̍ő�l��ݒ�
        _healthSlider.value = PlayerStatus.BASE_HEALTH;   // �X���C�_�[�̏����l��ݒ�
    }

    // HP�o�[���X�V
    public void UpdateHealthBar()
    {
        if (_playerStatus != null)
        {
            _healthSlider.value = _playerStatus.GetCurrentHealth(); // �X���C�_�[�̒l������HP�ɍ��킹��
        }
    }
}

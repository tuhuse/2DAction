

// �v���C���[�̊�{�C���^�[�t�F�[�X
public interface IPlayerAction
{
    
    void PlayerAction();
}

// �ړ��Ɋւ���C���^�[�t�F�[�X
public interface IWalk : IPlayerAction { }


// �W�����v�Ɋւ���C���^�[�t�F�[�X
public interface IJump : IPlayerAction { }

// �U���Ɋւ���C���^�[�t�F�[�X
public interface IAttack : IPlayerAction { }

// �X�L���Ɋւ���C���^�[�t�F�[�X
public interface ISkill : IPlayerAction { }

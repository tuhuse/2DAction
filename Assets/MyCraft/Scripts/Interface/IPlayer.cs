using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �v���C���[�̊�{�C���^�[�t�F�[�X
public interface IPlayer { }

// �ړ��Ɋւ���C���^�[�t�F�[�X
public interface IWalk
{
    void Walk();
}


// �W�����v�Ɋւ���C���^�[�t�F�[�X
public interface IJump
{
    void Jump();
}

// �U���Ɋւ���C���^�[�t�F�[�X
public interface IAttack
{
    void Attack();
}

// �X�L���Ɋւ���C���^�[�t�F�[�X
public interface ISkill
{
    void UseSkill();
}

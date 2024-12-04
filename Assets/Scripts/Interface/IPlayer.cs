using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// プレイヤーの基本インターフェース
public interface IPlayer { }

// 移動に関するインターフェース
public interface IWalk
{
    void Walk();
}


// ジャンプに関するインターフェース
public interface IJump
{
    void Jump();
}

// 攻撃に関するインターフェース
public interface IAttack
{
    void Attack();
}

// スキルに関するインターフェース
public interface ISkill
{
    void UseSkill();
}

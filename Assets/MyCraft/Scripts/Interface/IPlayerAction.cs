

// プレイヤーの基本インターフェース
public interface IPlayerAction
{
    void PlayerAction();
}

// 移動に関するインターフェース
public interface IWalk
{
    void RightWalk();
    void LeftWalk();

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
    void Skill();
}

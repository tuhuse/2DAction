

// プレイヤーの基本インターフェース
public interface IPlayerAction
{
    
    void PlayerAction();
}

// 移動に関するインターフェース
public interface IWalk : IPlayerAction { }


// ジャンプに関するインターフェース
public interface IJump : IPlayerAction { }

// 攻撃に関するインターフェース
public interface IAttack : IPlayerAction { }

// スキルに関するインターフェース
public interface ISkill : IPlayerAction { }

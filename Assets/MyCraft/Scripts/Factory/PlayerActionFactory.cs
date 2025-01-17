using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerActionFactory 
{
    public static T CreateAction<T>(string name) where T : Component, IPlayerAction
    {
        // 新しいGameObjectを作成
        GameObject obj = new GameObject(name);

        // Rigidbodyを追加
        Rigidbody rb = obj.AddComponent<Rigidbody>();

        // 動作クラスを追加
        T action = obj.AddComponent<T>();

        return action;
    }
}

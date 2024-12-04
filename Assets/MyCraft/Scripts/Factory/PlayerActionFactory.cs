using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerActionFactory 
{
    public static T CreateAction<T>(string name) where T : Component, IPlayerAction
    {
        // �V����GameObject���쐬
        GameObject obj = new GameObject(name);

        // Rigidbody��ǉ�
        Rigidbody rb = obj.AddComponent<Rigidbody>();

        // ����N���X��ǉ�
        T action = obj.AddComponent<T>();

        return action;
    }
}

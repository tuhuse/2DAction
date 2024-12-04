using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerActionFactory 
{
    public static T CreateAction<T>(string name) where T : Component, IPlayerAction
    {
        // V‚µ‚¢GameObject‚ğì¬
        GameObject obj = new GameObject(name);

        // Rigidbody‚ğ’Ç‰Á
        Rigidbody rb = obj.AddComponent<Rigidbody>();

        // “®ìƒNƒ‰ƒX‚ğ’Ç‰Á
        T action = obj.AddComponent<T>();

        return action;
    }
}

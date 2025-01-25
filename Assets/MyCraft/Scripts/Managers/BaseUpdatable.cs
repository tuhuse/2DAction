using UnityEngine;

public abstract class BaseUpdatable : MonoBehaviour
{

    private void OnEnable()
    {
            UpdateManager.Instance.Register(this);
    }

    private void OnDisable()
    {
            UpdateManager.Instance.Unregister(this);
    }

    public abstract void OnUpdate();
}

using System.Collections.Generic;
using UnityEngine;

/// <summary>
///アップデートここで流す
/// </summary>
public class UpdateManager : MonoBehaviour
{
   [SerializeField] private List<BaseUpdatable> _updatables = new List<BaseUpdatable>();
    public static UpdateManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    public void Register(BaseUpdatable updatable)
    {
        if (!_updatables.Contains(updatable))
        {
            _updatables.Add(updatable);
        }
    }

    public void Unregister(BaseUpdatable updatable)
    {
        if (_updatables.Contains(updatable))
        {
            _updatables.Remove(updatable);
        }
    }

    private void Update()
    {
        foreach (BaseUpdatable updatable in _updatables)
        {
            updatable.OnUpdate();
        }
    }
}

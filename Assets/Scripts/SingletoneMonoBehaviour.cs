using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
    public static T Instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }

            _instance = FindObjectOfType<T>();

            if (_instance != null)
            {
                return _instance;
            }

            _instance = new GameObject(typeof(T).Name).AddComponent<T>();
            return _instance;
        }
    }

    private static T _instance;

    protected virtual void OnAwakeSingleton()
    {
    }

    protected virtual void OnDestroySingleton()
    {
    }

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(this);
            return;
        }

        OnAwakeSingleton();
    }

    private void OnDestroy()
    {
        if (_instance != this)
        {
            return;
        }

        OnDestroySingleton();
        _instance = null;
    }
}
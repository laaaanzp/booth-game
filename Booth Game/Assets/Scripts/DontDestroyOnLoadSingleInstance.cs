using UnityEngine;

public class DontDestroyOnLoadSingleInstance : MonoBehaviour
{
    private static DontDestroyOnLoadSingleInstance instance;


    void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

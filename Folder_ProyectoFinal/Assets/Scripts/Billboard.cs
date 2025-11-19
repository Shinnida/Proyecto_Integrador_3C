using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] Transform target;
    void Start()
    {
        
    }

    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }
    }
}

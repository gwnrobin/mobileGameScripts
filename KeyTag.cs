using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTag : MonoBehaviour
{ 
    [SerializeField]
    private GameObject door;
    public bool doDestroy = false;

    void Update()
    {
        if(doDestroy)
        {
            Destroy(door);
            Destroy(this.gameObject);
        }
    }
}

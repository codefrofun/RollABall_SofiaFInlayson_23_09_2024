using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretCollectable : MonoBehaviour
{
    public bool FindSecret = false;

    void OnTriggerEnter(Collider other)
    {
        FindSecret = true;
    }
}

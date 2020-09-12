using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivatePickUP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Deactivate", Random.Range(3f, 6f));
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}

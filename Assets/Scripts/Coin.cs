using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private MeshCollider meshCollider;

    private void Awake()
    {
        meshCollider = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, 1); // quay coin sang phai
    }

    public void Dead ()
    {
        Destroy(gameObject);
    }
}

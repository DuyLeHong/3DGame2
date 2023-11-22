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
        transform.Rotate(Vector3.right, 5); // quay coin sang phai - theo truc X
    }

    public void Dead ()
    {
        Destroy(gameObject);
    }
}

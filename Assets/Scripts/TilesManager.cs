using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{

    public GameObject[] tilesPrefabs;
    private Transform player;
    private List<GameObject> activeTiles; // cac dia hinh dang active
    private float tileLength = 44f; // chieu dai dia hinh
    private float spawnZ = -1f;

    private int tilesOnScreen = 4; // so dia hinh dong thoi hien thi tren man hinh

    // ham tao dia hinh
    private void TaoDiaHinh (int index = -1)
    {
        GameObject gameObject;
        if (index == 0)
        {
            gameObject = Instantiate(tilesPrefabs[0]); // dua dia hinh so 0 vao
        }
        else // lay ngau nhien 1 dia hinh trong mang de tao
        {
            gameObject = Instantiate(tilesPrefabs[Random.Range(0, tilesPrefabs.Length)]);
        }

        // dua dia hinh moi tao vao game
        gameObject.transform.SetParent(transform);

        gameObject.transform.position = Vector3.forward * spawnZ;
        // xac dinh vi tri moi
        spawnZ += tileLength;

        activeTiles.Add(gameObject);
    }

    //ham xoa dia hinh
    private void XoaDiaHinh()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    void Start()
    {

        if (spawnZ == -1)
        {
            spawnZ = tileLength / 2 - 3;
        }

        activeTiles = new List<GameObject>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i=0; i < tilesOnScreen; i++)
        {
            if (i < 1)
            {
                TaoDiaHinh(0);
            }
            else
            {
                TaoDiaHinh();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // tao dia hinh khi nhan vat den va xoa khi di qua
        if ((player.position.z - tileLength) > (spawnZ - tileLength * tilesOnScreen))
        {
            TaoDiaHinh();
            XoaDiaHinh();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private Text locationText;
    public AudioClip collectSound; // xu ly am thanh khi va cham
    private bool isHitStone = true; // trang thai va cham

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Coin")
        {
            hit.gameObject.GetComponent<Coin>().Dead(); // goi ham dead tu Coin

        }
        else if (hit.gameObject.tag == "Stone")
        {
            //tru diem
            StartCoroutine(EnableCollider(hit, 1));
        }

        //update len Text canvas
        if (hit.gameObject.tag == "MushroomLocation")
        {
            locationText.text = "Mushroom: Location";
        }
        else if (hit.gameObject.tag == "StoneLocation")
        {
            locationText.text = "Stone: Location";
        }
        else if (hit.gameObject.tag == "HouseLocation")
        {
            locationText.text = "House: Location";
        }
    }

    private IEnumerator EnableCollider (ControllerColliderHit hit, float second)
    {
        isHitStone = false;
        yield return new WaitForSeconds(second); // sleep 1s
        isHitStone = true;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

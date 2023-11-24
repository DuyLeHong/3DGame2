using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private Text locationText;

    //private bool isHitStone = true; // trang thai va cham

    public int maxHealth = 100;
    public int currentHealth = 100;

    private bool stoneCollisionProcessed = false;

    public GameObject gameOver;
    public HealthBar healthBar;

    public AudioSource collectSound; // xu ly am thanh khi va cham
    public AudioSource chamda;
    public AudioSource gameover;
    public AudioSource running;


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Coin")
        {
            // play sound khi va cham coin

            hit.gameObject.GetComponent<Coin>().Dead(); // goi ham dead tu Coin

            // tang diem
            GetComponent<ScoreManager>().TangDiem(1);

            collectSound.Play();

        }
        else if (hit.gameObject.tag == "MushroomLocation"
            || hit.gameObject.tag == "StoneLocation")
        {
            //tru diem
            //StartCoroutine(EnableCollider(hit, 1));

            chamda.Play();


            // Kiểm tra xem đã xử lý va chạm với đá chưa
            if (!stoneCollisionProcessed)
            {
                StartCoroutine(EnableColliderAfterDelay(hit, 1f));
                locationText.text = "Chuong ngai vat";
                GetComponent<ScoreManager>().TangDiem(-1);
                TakeDamage(10);
                // Đặt cờ để chỉ đánh giá va chạm với đá một lần
                stoneCollisionProcessed = true;
            }

            if (currentHealth <= 0)
            {
                gameover.Play();
                running.Stop();
                Time.timeScale = 0;
                gameOver.SetActive(true);
            }
        }

        //update len Text canvas
        if (hit.gameObject.tag == "MushroomLocation")
        {
            locationText.text = "Mushroom: Location";
        }
        else if (hit.gameObject.tag == "StoneLocation")
        {
            locationText.text = "Stone: Location";
            //GetComponent<ScoreManager>().TangDiem(-1);
        }
        else if (hit.gameObject.tag == "HouseLocation")
        {
            locationText.text = "House: Location";
            //GetComponent<ScoreManager>().TangDiem(-1);
        }
    }

    private IEnumerator EnableColliderAfterDelay(ControllerColliderHit hit, float seconds)
    {
        // Đợi sau một khoảng thời gian
        yield return new WaitForSeconds(seconds);

        // Bật lại collider sau khi đã đợi
        hit.collider.enabled = true;

        // Đặt lại cờ isHitStone
        //isHitStone = true;

        // Reset cờ xử lý va chạm đá
        stoneCollisionProcessed = false;
    }

    //private IEnumerator EnableCollider(ControllerColliderHit hit, float second)
    //{
    //    isHitStone = false;
    //    yield return new WaitForSeconds(second); // sleep 1s
    //    isHitStone = true;
    //}

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void Start()
    {
        healthBar.SetHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

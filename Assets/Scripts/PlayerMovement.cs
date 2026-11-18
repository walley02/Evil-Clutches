using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4;
    private int scoreVal = 0;

    public float spawnDistance = 1;
    public GameObject fireballplayer;
    private float fireballTimer = 0;
    private float fireballWait = 2;

    public TextMeshProUGUI scoreBox;

    public string gameOverSceneName = "GameOver";


   
    void Update()
    {
        fireballTimer += Time.deltaTime;

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-transform.up * speed * Time.deltaTime);
        }
        if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) )&& transform.position.x > -7)
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
        if((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && transform.position.x < 0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4f, 3.4f), transform.position.z);

        //fireball
        if (Input.GetKey(KeyCode.Space) && fireballTimer > fireballWait)
        {
            Vector2 spawnPos = (Vector2)transform.position + (Vector2)transform.right * spawnDistance;
            Instantiate(fireballplayer, spawnPos, transform.rotation);
            fireballTimer = 0;
        }

        if (scoreVal > 4999 || scoreVal <-4999)
        {
            SceneManager.LoadScene(gameOverSceneName);
        }

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            if(collision.GetComponent<ProjectileMove>() != null)
            {
                scoreVal += collision.GetComponent<ProjectileMove>().points;
                scoreBox.text = "score: " + scoreVal;
            }
            Destroy(collision.gameObject);
        }

    }
}

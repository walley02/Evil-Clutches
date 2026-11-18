using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonMovement : MonoBehaviour
{
    public float spawnDistance = -2;
    public float speed = 5;
    public bool goingUp = true;

    //rat/fireball timers
    private float ratWait = 3, fireballWait = .5f;
    private float ratTimer = 0, fireballTimer = 0;

    public GameObject rat;
    public GameObject fireball;

    public TextMeshProUGUI dragonDamage;
    private int scoreDam = 0;

    public string gameOverSceneName = "GameOver";

    void Update()
    {
        //spawning
        ratTimer += Time.deltaTime;
        fireballTimer += Time.deltaTime;

        if(ratTimer > ratWait)
        {
            Vector2 spawnPos = (Vector2)transform.position + (Vector2)transform.right * spawnDistance;
            Instantiate(rat, spawnPos, transform.rotation);
            ratTimer = 0;
            ratWait = Random.Range(2f, 4f);
        }

        if(fireballTimer > fireballWait)
        {
            Vector2 spawnPos = (Vector2)transform.position + (Vector2)transform.right * spawnDistance;
            Instantiate(fireball, spawnPos, transform.rotation);
            fireballTimer = 0;
            fireballWait = Random.Range(.05f, .65f);
        }

        transform.Translate(transform.up * speed * Time.deltaTime);

        if(transform.position.y > 4 && goingUp == true)
        {
            goingUp = false;
            speed *= -1;
        }

        if (transform.position.y < -4 && goingUp == false)
        {
            goingUp = true;
            speed *= -1;
        }

        if (scoreDam > 14999)
        {
            SceneManager.LoadScene(gameOverSceneName);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            if (collision.GetComponent<PlayerFireball>() != null)
            {
                scoreDam += collision.GetComponent<PlayerFireball>().points;
                dragonDamage.text = "dragon damage: " + scoreDam;
            }
            Destroy(collision.gameObject);
        }

    }
}

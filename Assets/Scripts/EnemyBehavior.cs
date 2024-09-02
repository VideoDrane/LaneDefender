using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float Speed;
    public int Lane;
    public int HealthPoints;
    public int EnemyType;
    public Rigidbody2D RB2D;
    public AudioClip Hurt;
    public AudioSource ASource;
    public GameObject DeathSound;
    public GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        RB2D.velocity = new Vector2(-Speed, 0);
        Lane = Random.Range(1, 6);
        if (Lane == 1)
        {
            transform.position = new Vector2(6.23f, -1.132f);
        }
        else if (Lane == 2)
        {
            transform.position = new Vector2(6.23f, -1.904f);
        }
        else if (Lane == 3)
        {
            transform.position = new Vector2(6.23f, -2.55f);
        }
        else if (Lane == 4)
        {
            transform.position = new Vector2(6.23f, -3.196f);
        }
        else
        {
            transform.position = new Vector2(6.23f, -3.943f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            collision.gameObject.GetComponent<BulletBehavior>().Hit();
            EnemyHurt();
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            GM.RemoveLife();
            Destroy(gameObject);
        }
    }

    public void EnemyHurt()
    {
        HurtAnim();
        HealthPoints--;
        if (HealthPoints <= 0)
        {
            Instantiate(DeathSound, transform.position, Quaternion.identity);
            GM.AddScore();
            Destroy(gameObject);
        }
        else
        {
            ASource.clip = Hurt;
            ASource.Play();
        }
    }

    public void HurtAnim()
    {
        if (EnemyType == 1)
        {
            gameObject.GetComponent<Animator>().Play("Enemy1Hurt");
        }
        else if (EnemyType == 2)
        {
            gameObject.GetComponent<Animator>().Play("Enemy2Hurt");
        }
        else if (EnemyType == 3)
        {
            gameObject.GetComponent<Animator>().Play("Enemy3Hurt");
        }
        RB2D.velocity = new Vector2(0, 0);
        Invoke("ResumeSpeed", 0.2f);
    }

    public void ResumeSpeed()
    {
        RB2D.velocity = new Vector2(-Speed, 0);
    }
}

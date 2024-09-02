using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public GameObject EFX;
    public float Speed;
    public Rigidbody2D RB2D;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(EFX, gameObject.transform.position, Quaternion.identity);
        RB2D.velocity = new Vector2(Speed, 0);
    }

    public void Hit()
    {
        Instantiate(EFX, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

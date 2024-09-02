using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    public Rigidbody2D RB2D;
    public float Speed;
    public float BulletCooldown;
    public PlayerInput PlayerI;
    public InputAction Movement;
    public InputAction Shoot;
    public bool IsMoving;
    public int MoveDirection;
    public bool IsShooting;
    public bool CanShoot;
    public GameObject Bullet;
    public GameObject BulletSpawner;
    public AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
        PlayerI = GetComponent<PlayerInput>();
        PlayerI.currentActionMap.Enable();
        Movement = PlayerI.currentActionMap.FindAction("Movement");
        Shoot = PlayerI.currentActionMap.FindAction("Shoot");

        Movement.started += Movement_started;
        Movement.canceled += Movement_canceled;
        Shoot.started += Shoot_started;
        Shoot.canceled += Shoot_canceled;
    }

    private void Shoot_started(InputAction.CallbackContext context)
    {
        IsShooting = true;
    }

    private void Shoot_canceled(InputAction.CallbackContext context)
    {
        IsShooting = false;
    }

    private void Movement_started(InputAction.CallbackContext context)
    {
        if (Movement.ReadValue<float>() > 0 && transform.position.y <= -1.26)
        {
            MoveDirection = 1;
            IsMoving = true;
        }
        else if (Movement.ReadValue<float>() < 0 && transform.position.y >= -4.16)
        {
            MoveDirection = -1;
            IsMoving = true;
        }
    }

    private void Movement_canceled(InputAction.CallbackContext context)
    {
        IsMoving = false;
        MoveDirection = 0;
    }

    public void BulletShoot()
    {
        if (CanShoot)
        {
            Instantiate(Bullet, BulletSpawner.GetComponent<Transform>().position, Quaternion.identity);
            CanShoot = false;
            AS.Play();
            Invoke("ResetCanShoot", .17f);
        }
    }

    public void ResetCanShoot()
    {
        CanShoot = true;
    }

    private void FixedUpdate()
    {
        if (IsShooting)
        {
            BulletShoot();
        }
        if (IsMoving)
        {
            if (Movement.ReadValue<float>() > 0 && transform.position.y >= -1.3 || 
                Movement.ReadValue<float>() < 0 && transform.position.y <= -4)
            {
                IsMoving = false;
            }
            RB2D.velocity = new Vector2(0, MoveDirection * Speed);
        }
        else
        {
            RB2D.velocity = new Vector2(0, 0);
        }
    }
}

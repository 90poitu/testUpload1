using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    private static Player instance;

    public CharacterController controller;
    public Camera cam;
    [Range(0, 50)] public float speed;
    public float canShoot;
    [Range(0, 10)] public float resetShot;
    public GameObject bulletPrefab;

    public GameObject spawnShurikenPos;

    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance;
    public bool isGrounded;
    [Range(-1000, 1000)] public float gravity = -9.81f;

    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;

    public float jumpHeight;
    public float doubleJumpCD = 4;

    public float rotationSpeed;

    Vector3 velocity;

    public Vector3 resetPosition;

    public bool start;

    public Animator animator;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        gameStart();

        if (start)
        {
            Time.timeScale = 1;
            movement();
            shooting();
            jumping();
            reset();
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    void movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 move = new Vector3(horizontal, 0, cam.transform.forward.z);

        float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
        float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothTime, turnSmoothTime);

        transform.rotation = Quaternion.Euler(0f, Angle, 0f);

        Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

        controller.Move(moveDirection * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    void shooting()
    {
        if (canShoot <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                animator.SetTrigger("attacking");
                attackingObject();
                canShoot = resetShot;
            }
        }
        else
        {
            canShoot -= Time.deltaTime;
        }
    }
    void jumping()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("isJumping");
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
        else
        {
            if (doubleJumpCD >= 0)
            {
                doubleJumpCD -= Time.deltaTime;
            }

            if (Input.GetKeyDown(KeyCode.Space) && !isGrounded)
            {
                if (doubleJumpCD <= 0)
                {
                    animator.SetTrigger("double_jump");
                    velocity.y = Mathf.Sqrt(jumpHeight * 2 * -2f * gravity);
                    doubleJumpCD = 3.5f;
                }
            }
        }
    }

    void reset()
    {
        if (transform.position.y <= -10f)
        {
            transform.position = resetPosition;
            start = false;
        }
    }

    void gameStart()
    {
        if (!start)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                start = true;
            }
        }
    }

    void attackingObject()
    {
        GameObject Shuriken = Instantiate(bulletPrefab, spawnShurikenPos.transform.position, transform.rotation * Quaternion.Euler(90, 0, 0));
    }
}

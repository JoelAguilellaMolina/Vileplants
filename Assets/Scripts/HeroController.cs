using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public float speed = 7.0f;

    public int maxHealth = 1;
    public int maxFlowers = 3;
    public float timeInvincible = 2.0f;
    public GameObject projectilePrefab;

    public int health { get { return currentHealth; } }
    public int currentHealth;
    bool isInvincible;
    float invincibleTimer;

    public int flowers { get { return currentFlowers; } }
    public int currentFlowers;
    

    Rigidbody2D rigidbody2d;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
        currentFlowers = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        Vector2 position = rigidbody2d.position;

        position = position + move * speed * Time.deltaTime;

        rigidbody2d.MovePosition(position);

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Launch();
        }
    }

    public void ChangeHealth(int amount)
    {
        if (amount == -1)
        {
            currentHealth = maxHealth;
            transform.position = new Vector3(0, 0, 0);


        }

        if (amount == -2)
        {
            currentHealth = maxHealth;
            transform.position = new Vector3(-7, 78, 0);


        }

        if (amount == -3)
        {
            currentHealth = maxHealth;
            transform.position = new Vector3(-7, 46, 0);


        }

        if (amount == -4)
        {
            currentHealth = maxHealth;
            transform.position = new Vector3(-7, 122, 0);


        }

        if (amount == -5)
        {
            currentHealth = maxHealth;
            transform.position = new Vector3(-7, 105, 0);


        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        Debug.Log(currentHealth + "/" + maxHealth);

        

    }

    public void ChangeFlowers (int amount)
    {
        currentFlowers = Mathf.Clamp(currentFlowers + amount, 0, maxFlowers);
        UIHealthBar.instance.SetValue(currentFlowers / (float)maxFlowers);
        Debug.Log(currentFlowers + "/" + maxFlowers);
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.1f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");
    }
}
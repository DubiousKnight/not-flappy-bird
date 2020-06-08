using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rg;

    public Canvas RetryCanvas;
    public ScoreUI score;

    private ParticleSystem deathParticles;
    private SpriteRenderer playerSprite;
    public float verticalForce;

    public float topOfPlayArea;

    private bool isAlive;

    private Vector3 originalSpawnPos;

    // Start is called before the first frame update
    void Start()
    {
        this.originalSpawnPos = this.transform.position;
        this.isAlive = true;
        this.playerSprite = this.gameObject.GetComponent<SpriteRenderer>();
        this.deathParticles = this.gameObject.GetComponentInChildren<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        if (this.isAlive)
        {
            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
            {
                if (this.transform.position.y <= topOfPlayArea)
                {
                    rg.AddForce(new Vector2(0, verticalForce) * Time.deltaTime);
                }
                else
                {
                    rg.AddForce(new Vector2(0, -verticalForce) * Time.deltaTime);
                }
            }
        }
        else
        {
            StopTime();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (this.isAlive)
        {
            if (col.tag == "Obstacle")
            {
                Die();
            }

            if (col.tag == "Score")
            {
                this.score.UpdateScore();
            }
        }
    }
    void Die()
    {
        this.isAlive = false;
        this.deathParticles.Play();
        this.playerSprite.enabled = false;

        this.RetryCanvas.gameObject.SetActive(true);
    }

    void StopTime()
    {
        if (Time.timeScale >= 0.2)
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, 0, 5 * Time.deltaTime);
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
}

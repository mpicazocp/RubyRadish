using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Ruby : MonoBehaviour
{
    public float horizontal;
    public float speed = 2f;
    public float jumpingPower = 2f;
    public bool isFacingRight = false;
    public Animator myAnim;

    public int score = 0;
    public GameObject canvas;
    public GameObject ScoreKeeper;

    private bool ruby_is_dead;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start() {
        score = ScoreKeeper.GetComponent<ScoreKeeper>().playerScore;
        canvas.GetComponent<TMP_Text>().text = "Score: " + score.ToString();
        myAnim = GetComponent<Animator>();
        ruby_is_dead = false;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        if (ruby_is_dead) {
            rb.velocity = Vector2.zero;
            return;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    IEnumerator OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "DEATH") {
            ruby_is_dead = true;
            ScoreKeeper.GetComponent<ScoreKeeper>().playerScore = 0;
            myAnim.SetTrigger("Ruby-death");
            yield return new WaitForSeconds(1.5f);
            myAnim.ResetTrigger("Ruby-death");
            SceneManager.LoadScene("YouLose");
        }
        if (other.gameObject.tag == "FIRE_DEATH") {
            ruby_is_dead = true;
            ScoreKeeper.GetComponent<ScoreKeeper>().playerScore = 0;
            myAnim.SetTrigger("Ruby-death-fire");
            yield return new WaitForSeconds(1.5f);
            myAnim.ResetTrigger("Ruby-death-fire");
            SceneManager.LoadScene("YouLose");
        }
        else if (other.gameObject.tag == "GOAL") {
            Destroy(other.gameObject);
            SceneManager.LoadScene("LevelTransition");
        }
        else if (other.gameObject.tag == "GOAL2") {
            Destroy(other.gameObject);
            SceneManager.LoadScene("Credits");
        }
        else if (other.gameObject.tag == "POINT") {
            score++;
            ScoreKeeper.GetComponent<ScoreKeeper>().playerScore = score;
            canvas.GetComponent<TMP_Text>().text = "Score: " + score.ToString();
            Destroy(other.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float power;
    public bool canMove;
    public int score;

    public GameObject scoreboard;
    public GameObject GameOverMessage;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canMove)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, power);
        }

        if (Mathf.Abs(transform.position.y) > 4.5f)
        {
            GameOver();
        }

        scoreboard.GetComponent<Text>().text = "점수 : " + score.ToString();

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void GameOver()
    {
        canMove = false;
        GameOverMessage.SetActive(true);
        Debug.Log("GameOver");
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            Debug.Log("collision");
            GameOver();
        }
    }
}

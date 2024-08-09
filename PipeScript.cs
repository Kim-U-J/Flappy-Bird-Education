using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float Speed;
    public float height;
    public bool canPipe;
    public bool canScore;
    public BirdScript bird;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        bird = FindObjectOfType<BirdScript>();
        canScore = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canPipe && bird.canMove)
        {
            float waitTime = Random.Range(1f, 1.5f);
            StartCoroutine(Pipe(waitTime));
        }

        if (transform.position.x < -5f && canScore)
        {
            canScore = false;
            bird.score += 1;
        }

        if (!bird.canMove)
        {
            rigid.velocity = new Vector2(0, 0);
        }
    }

    IEnumerator Pipe(float waitTime)
    {
        float currentHeight = transform.position.y;
        canPipe = false;

        height = Random.Range(currentHeight - 3f, currentHeight + 4f);
        height = Mathf.Clamp(height, -3f, 3f);

        transform.position = new Vector2(transform.position.x, height);

        GameObject temp = Instantiate(this.gameObject);
        Rigidbody2D tempRigidbody = temp.GetComponent<Rigidbody2D>();

        if (tempRigidbody != null)
        {
            tempRigidbody.velocity = new Vector2(-Speed, tempRigidbody.velocity.y);
        }

        Destroy(temp, 4f);

        yield return new WaitForSeconds(waitTime);

        canPipe = true;
    }
}

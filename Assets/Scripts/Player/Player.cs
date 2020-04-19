using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float speed = 0.01f;

    private Rigidbody2D rigid;
    private PlayerAnimation playerAnimation;
    private GameManager gameManger;
    private SpriteRenderer playerSprite;
    private SpriteRenderer torchSprite;

    private bool isInvinsible; // just to avoid the player from loosing several lifes at once. 
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerSprite = GetComponent<SpriteRenderer>();
        torchSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        gameManger = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManger.isPaused)
        {
            DetectMovement();
        }
    }

    private void DetectMovement()
    {
 
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        if(moveHorizontal > 0)
        {
            Flip(true);
        }
        else if(moveHorizontal < 0)
        {
            Flip(false);
        }

        // verify direction
        if(moveHorizontal != 0)
        {
            transform.position = new Vector2((transform.position.x + (speed * moveHorizontal)), transform.position.y);
            playerAnimation.Move(true);
        }
        if (moveVertical != 0)
        {
            transform.position = new Vector2(transform.position.x, (transform.position.y + (speed * moveVertical)));
            playerAnimation.Move(true);
        }
        if(moveHorizontal == 0 && moveVertical == 0)
        {
            playerAnimation.Move(false);
        }
    }

    void Flip(bool facingRight)
    {
        if (facingRight)
        {
            playerSprite.flipX = true;
            Vector3 newTorchPositon = torchSprite.transform.localPosition;
            newTorchPositon.x = 0.16f;
            torchSprite.transform.localPosition = newTorchPositon;
        }
        else
        {
            playerSprite.flipX = false;
            Vector3 newTorchPositon = torchSprite.transform.localPosition;
            newTorchPositon.x = -0.16f;
            torchSprite.transform.localPosition = newTorchPositon;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Spider"))
        {
            if (!isInvinsible)
            {
                StartCoroutine(LooseLife());
            }
        }
    }


    // Lose a life, but wait one second before loosing another
    private IEnumerator LooseLife()
    {
        isInvinsible = true;
        playerSprite.color = new Color(255.0f, 0.0f, 0.0f, 255.0f); // Red
        gameManger.Life--;
        yield return new WaitForSeconds(1.0f);
        playerSprite.color = new Color(255.0f, 255.0f, 255.0f, 255.0f); // White (normal colors)
        isInvinsible = false;
    }

}

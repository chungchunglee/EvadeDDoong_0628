using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D playerrigidbody2D;
    SpriteRenderer playerspriteRenderer;
    Animator playeranimator;
    [SerializeField]
    float speed = 0.05f;
    public bool isDead = false;

    void Start()
    {
        playerrigidbody2D = GetComponent<Rigidbody2D>();
        playerspriteRenderer = GetComponent<SpriteRenderer>();
        playeranimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput;
        xInput = Input.GetAxis("Horizontal");
        // 에니매이션 속도
        playeranimator.SetFloat("animationSpeed", xInput);

        if(xInput<0)
        {
            playerspriteRenderer.flipX = true;
        }
        else if(xInput>0)
        {
            playerspriteRenderer.flipX = false;
        }
        ////Debug.Log(xInput);    //X축 이동

        transform.Translate(new Vector3(speed * xInput, 0, 0));

    }
    public void Die()
    {
       isDead = true;
       gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Hit");
        if(other.tag == "DDong"&&!isDead)
        {
            //Debug.Log("Hit--Critical");
            Die();
            GameManager.instance.OnPlayerDead();
        }
    }
    
}

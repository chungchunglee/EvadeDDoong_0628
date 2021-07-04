using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D playerrigidbody2D;
    SpriteRenderer playerspriteRenderer;
    Animator playeranimator;
    [SerializeField]
    float speed = 0.5f;
    
    [SerializeField]
    private int unBeatTime = 2;

    [SerializeField]
    private int maxHp = 3;
    private int nowHP;
    private bool isUnBeatTime = false;
    public bool isDead = false;
    public Image HPBar;



    void Start()
    {
        playerrigidbody2D = GetComponent<Rigidbody2D>();
        playerspriteRenderer = GetComponent<SpriteRenderer>();
        playeranimator = GetComponent<Animator>();
        nowHP = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            return;
        }
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
        HPBar.fillAmount = (float)nowHP/ (float)maxHp;

    }
    public void Die()
    {
        playeranimator.SetTrigger("die");
        isDead = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Hit");
        if(other.tag == "DDong"&&!isDead&& !isUnBeatTime)
        {
            //Debug.Log("Hit--Critical");
            nowHP --;
            if(nowHP == 0)
            {
                HPBar.fillAmount = 0;
                Die();
                GameManager.instance.OnPlayerDead();
                return;
            }
            isUnBeatTime = true;
            StartCoroutine("UnbeatTime");
        }
    }
    IEnumerator UnbeatTime()
    {
        int countTime = 0;
        while (countTime < (unBeatTime/0.2))
        {
            if (countTime % 2 == 0)
            {
                playerspriteRenderer.color = new Color32(255, 255, 255, 90);
            }
            else
            {
                playerspriteRenderer.color = new Color32(255, 255, 255, 180);
            }
            yield return new WaitForSeconds(0.2f);
            countTime++;
        }
        playerspriteRenderer.color = new Color32(255, 255, 255, 255);

        isUnBeatTime = false;

        yield return null;
    }
}

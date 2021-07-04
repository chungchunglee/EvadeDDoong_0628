using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDong_Behavior : MonoBehaviour
{
    private Rigidbody2D DDong_rigidbody2D;
    public ParticleSystem explosion;
    // Start is called before the first frame update
    void Awake()
    {
        DDong_rigidbody2D= GetComponent<Rigidbody2D>();
        DDong_rigidbody2D.gravityScale = 0f;
        Debug.Log(DDong_rigidbody2D.gravityScale + "Gravity Is");
        //Debug.Log(DDong_rigidbody2D.gravityScale);
    }
    private void OnEnable()
    {
        //Debug.Log("this");
     //   Debug.Log(DDong_rigidbody2D.gravityScale + "Gravity Is");
        DDong_rigidbody2D.gravityScale = Random.Range(0.4f, 1f);
        
        //Debug.Log(DDong_rigidbody2D.gravityScale + "Gravity Is");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        /*
         *  1. 점수증가
         *  2. 에니메이션
         *  3. Active False
         */
        //Debug.Log("Hit");
        if (other.tag == "Finish")
        {
            Debug.Log(other + other.tag);
            // 점수 증가
            GameManager.instance.AddScore(1);
            // 에니메이션
            Instantiate(explosion,transform.position,Quaternion.identity);

            //Active
            gameObject.SetActive(false);

        }
    }
}

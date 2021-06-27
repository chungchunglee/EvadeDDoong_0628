using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D playerrigidbody2D;
    [SerializeField]
    float speed = 0.05f;
    public bool isDead = false;

    void Start()
    {
        playerrigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput;
        xInput = Input.GetAxis("Horizontal");
        //Debug.Log(xInput);    //X√‡ ¿Ãµø

        transform.Translate(new Vector3(speed * xInput, 0, 0));

    }
    void Die()
    {
       isDead = true;
       gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");
        if(other.tag == "DDong"&&!isDead)
        {
            Debug.Log("Hit--Critical");
            Die();
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDong_Behavior : MonoBehaviour
{
    private Rigidbody2D DDong_rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
         DDong_rigidbody2D= GetComponent<Rigidbody2D>();
        DDong_rigidbody2D.gravityScale = 0f;
        Debug.Log(DDong_rigidbody2D.gravityScale);
    }
    private void OnEnable()
    {
        Debug.Log("this");
        DDong_rigidbody2D.gravityScale = Random.Range(10, 100)/100f;
        Debug.Log(DDong_rigidbody2D.gravityScale + "Gravity Is");
    }


}

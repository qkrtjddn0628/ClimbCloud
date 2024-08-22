using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class CatController : MonoBehaviour
{

    public Rigidbody2D rd2D;
    public Animator animator;
    public float moveForce;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
       // Rigidbody2D rd2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isLeftArrowHold = Input.GetKey(KeyCode.LeftArrow);
        bool isRightArrowHold = Input.GetKey(KeyCode.RightArrow);

        if(isLeftArrowHold)
        {
            Debug.Log("왼쪽");
            this.rd2D.AddForce(new Vector2(-1 * this.moveForce, 0)); //*(위치 * 힘)
            this.transform.localScale = new Vector3(-1, 1, 1);

            this.animator.SetInteger("State", 1);
        }
        else if(isRightArrowHold)
        {
            Debug.Log("오른쪽");
            this.rd2D.AddForce(new Vector2(1 * this.moveForce, 0));
            this.transform.localScale = new Vector3(1, 1, 1);
            this.animator.SetInteger("State", 1);
        }
        else
        {
            this.animator.SetInteger("State", 0);
        }


        CatJump();
    }

    public void CatJump()
    {
        bool isDown = Input.GetKeyDown(KeyCode.Space);
        if (isDown)
        {
            Debug.Log("스페이스 버튼을 눌렀습니다...");
            this.rd2D.AddForce(new Vector2(0, +1 * this.jumpForce));
            //this.transform.Translate(0, 1, 0);
        }
    }

}

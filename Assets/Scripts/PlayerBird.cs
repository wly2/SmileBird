using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 2019.9.25  13:50
* 功能描述：     .................人物..............    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion
public class PlayerBird : MonoBehaviour
{
    bool isClick = false;//判断鼠标是否按下
    [SerializeField] Transform traSlingShotRightPosition;//弹弓右边原点
    [SerializeField] Transform traSlingShotLeftPosition;//弹弓左边原点
    [SerializeField] LineRenderer LineSlingShotRinght;
    [SerializeField] LineRenderer LineSlingShotLeft;
    [SerializeField] float maxBirdPossition = 0;//拖动鸟的最大距离
    public static SpringJoint2D sp;
    Rigidbody2D rg;



    void Start()
    {
        sp = GetComponent<SpringJoint2D>();
        rg = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        BirdMove();
        LineSlingShot();
    }

    /// <summary>
    /// 按下鼠标
    /// over the GUIElement or Collider.
    /// </summary>
    void OnMouseDown()
    {
        isClick = true;
        rg.isKinematic = true;
    }

    /// <summary>
    /// 松开鼠标
    /// </summary>
    void OnMouseUp()
    {
        isClick = false;
        rg.isKinematic = false;
        StartCoroutine(DeleySeconds(0.1f));
    }

    public IEnumerator DeleySeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        sp.enabled = false;

    }


    /// <summary>
    ///常按鼠标，鸟移动
    /// </summary>
    public void BirdMove()
    {
        if (isClick == true)
        {
            transform.localPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);//ScreenToWorldPoint将屏幕坐标转换为场景坐标
            transform.localPosition += new Vector3(0, 0, -Camera.main.transform.localPosition.z);
            // transform.localPosition += new Vector3(0,0,10);
        }

        //=============限制最大拖动长度====================//
        if (Vector3.Distance(transform.position, traSlingShotRightPosition.position) > maxBirdPossition)
        {
            Vector3 pos = (transform.position - traSlingShotRightPosition.position).normalized;//单位化向量
            pos *= maxBirdPossition;
            transform.position = pos + traSlingShotRightPosition.position;
        }
    }

    /// <summary>
    /// 弹弓皮筋
    /// </summary>
    public void LineSlingShot()
    {
        LineSlingShotRinght.SetPosition(0, traSlingShotRightPosition.position);
        LineSlingShotRinght.SetPosition(1, transform.position);

        LineSlingShotLeft.SetPosition(0, traSlingShotLeftPosition.position);
        LineSlingShotLeft.SetPosition(1, transform.position);

    }

}

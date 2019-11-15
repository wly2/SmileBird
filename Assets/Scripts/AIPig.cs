using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using System;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 2019.9.25  13:50
* 功能描述：     .................AI猪..............    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class AIPig : MonoBehaviour
{
    [SerializeField] float maxDamagePig = 100f;//最大承受伤害
    [SerializeField] float minDanagePig = 10f;//最小承受伤害
    SpriteRenderer render;//AI上的SpriteRender组件
    [SerializeField] Sprite spritePigState;//AI状态图
    [SerializeField] GameObject goBoom;//死亡特效
    [SerializeField] GameObject goScore;//得分


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D something)
    {
        if (something.relativeVelocity.magnitude > maxDamagePig)//something.relativeVelocity.magnitude碰撞值
        {
            MyDebug.Log("==================死亡伤害================" +something.relativeVelocity.magnitude);
            PigDeath();
        }
        else if (something.relativeVelocity.magnitude > minDanagePig && something.relativeVelocity.magnitude < maxDamagePig)
        {
            MyDebug.Log("==================受伤伤害================" +something.relativeVelocity.magnitude);
            PigHurt();
        }
    }

    /// <summary>
    /// 死亡
    /// </summary>
    public void PigDeath()
    {
        Destroy(gameObject);
        Instantiate(goBoom,transform.position,Quaternion.identity);
        GameObject go = Instantiate(goScore,transform.position,Quaternion.identity);

    }

    /// <summary>
    /// 受伤
    /// </summary>
    public void PigHurt()
    {
        render.sprite = spritePigState;

    }

}

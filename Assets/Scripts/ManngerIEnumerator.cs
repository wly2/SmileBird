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
* 功能描述：     .................协程管理..............    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class ManngerIEnumerator : MonoSingleton<ManngerIEnumerator>
{
   public IEnumerator DeleySeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}

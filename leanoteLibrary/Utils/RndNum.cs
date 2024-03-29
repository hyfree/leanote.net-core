﻿using System;
using System.Collections.Generic;
using System.Text;

namespace leanoteLibrary.Util
{
    /// <summary>
    /// 生产随机字符串的类
    /// </summary>
   public class RndNum
    {
        /// <summary>
        /// 生产随机字符串
        /// </summary>
        /// <param name="VcodeNum">随机字符串的长度</param>
        /// <returns>返回一个随机字符串</returns>
        public static string CreatRndNum(int VcodeNum)
        {
            //验证码可以显示的字符集合  
            var Vchar = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,p" +
                ",q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,P,P,Q" +
                ",R,S,T,U,V,W,X,Y,Z";
            var vcArray = Vchar.Split(new Char[] { ',' });//拆分成数组   
            var code = "";//产生的随机数  
            var temp = -1;//记录上次随机数值，尽量避避免生产几个一样的随机数  

            var random = new Random();
            //采用一个简单的算法以保证生成随机数的不同  
            for (int i = 1; i < VcodeNum + 1; i++)
            {
                if (temp != -1)
                {
                    random = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));//初始化随机类  
                }
                int t = random.Next(61);//获取随机数  
                if (temp != -1 && temp == t)
                {
                    return CreatRndNum(VcodeNum);//如果获取的随机数重复，则递归调用  
                }
                temp = t;//把本次产生的随机数记录起来  
                code += vcArray[t];//随机数的位数加一  
            }
            return code;
        }

     
     
    }
}

using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class To_Post
  {
   //To_Post���Ĭ�Ϲ��췽��
   public To_Post ()
   {

   }
   private int id;
   /// <summary>
   ///[To_Post]������
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private string postname;
   /// <summary>
   ///[To_Post]�� [postname]��
   /// </summary>
   public string Postname
   {
     get{ return postname; }
     set{ this.postname=value;}
   }
  }
}

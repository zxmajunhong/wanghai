using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class Menu
  {
   //Menu���Ĭ�Ϲ��췽��
   public Menu ()
   {

   }
   private int nodeid;
   /// <summary>
   ///[Menu]������
   /// [LoginUserLimit]���������
   /// ԭ����[nodeid]
   /// ԭ����[int]
   /// �����[LoginUserLimit]
   /// ������[nodeid]
   /// </summary>
   public int Nodeid
   {
     get{ return nodeid; }
     set{ this.nodeid=value;}
   }
   private string name;
   /// <summary>
   ///[Menu]�� [name]��
   /// </summary>
   public string Name
   {
     get{ return name; }
     set{ this.name=value;}
   }
   private string url;
   /// <summary>
   ///[Menu]�� [url]��
   /// </summary>
   public string Url
   {
     get{ return url; }
     set{ this.url=value;}
   }
   private int nodesort;
   /// <summary>
   ///[Menu]�� [nodesort]��
   /// </summary>
   public int Nodesort
   {
     get{ return nodesort; }
     set{ this.nodesort=value;}
   }
   private int parentnodeid;
   /// <summary>
   ///[Menu]�� [parentnodeid]��
   /// </summary>
   public int Parentnodeid
   {
     get{ return parentnodeid; }
     set{ this.parentnodeid=value;}
   }
  }
}

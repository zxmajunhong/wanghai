using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class SortInfo
  {
   //SortInfo���Ĭ�Ϲ��췽��
   public SortInfo ()
   {

   }
   private int sortid;
   /// <summary>
   ///[SortInfo]������
   /// [NoticeInfo]���������
   /// ԭ����[sortid]
   /// ԭ����[int]
   /// �����[NoticeInfo]
   /// ������[sortid]
   /// </summary>
   public int Sortid
   {
     get{ return sortid; }
     set{ this.sortid=value;}
   }
   private string sortname;
   /// <summary>
   ///[SortInfo]�� [sortname]��
   /// </summary>
   public string Sortname
   {
     get{ return sortname; }
     set{ this.sortname=value;}
   }
  }
}

using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class Sysdiagrams
  {
   //Sysdiagrams���Ĭ�Ϲ��췽��
   public Sysdiagrams ()
   {

   }
   private string name;
   /// <summary>
   ///[sysdiagrams]�� [name]��
   /// </summary>
   public string Name
   {
     get{ return name; }
     set{ this.name=value;}
   }
   private int principal_id;
   /// <summary>
   ///[sysdiagrams]�� [principal_id]��
   /// </summary>
   public int Principal_id
   {
     get{ return principal_id; }
     set{ this.principal_id=value;}
   }
   private int diagram_id;
   /// <summary>
   ///[sysdiagrams]������
   /// </summary>
   public int Diagram_id
   {
     get{ return diagram_id; }
     set{ this.diagram_id=value;}
   }
   private int version;
   /// <summary>
   ///[sysdiagrams]�� [version]��
   /// </summary>
   public int Version
   {
     get{ return version; }
     set{ this.version=value;}
   }
   private byte[] definition;
   /// <summary>
   ///[sysdiagrams]�� [definition]��
   /// </summary>
   public byte[] Definition
   {
     get{ return definition; }
     set{ this.definition=value;}
   }
  }
}

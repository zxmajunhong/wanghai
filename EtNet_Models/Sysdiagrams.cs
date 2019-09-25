using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class Sysdiagrams
  {
   //Sysdiagrams表的默认构造方法
   public Sysdiagrams ()
   {

   }
   private string name;
   /// <summary>
   ///[sysdiagrams]表 [name]列
   /// </summary>
   public string Name
   {
     get{ return name; }
     set{ this.name=value;}
   }
   private int principal_id;
   /// <summary>
   ///[sysdiagrams]表 [principal_id]列
   /// </summary>
   public int Principal_id
   {
     get{ return principal_id; }
     set{ this.principal_id=value;}
   }
   private int diagram_id;
   /// <summary>
   ///[sysdiagrams]表主键
   /// </summary>
   public int Diagram_id
   {
     get{ return diagram_id; }
     set{ this.diagram_id=value;}
   }
   private int version;
   /// <summary>
   ///[sysdiagrams]表 [version]列
   /// </summary>
   public int Version
   {
     get{ return version; }
     set{ this.version=value;}
   }
   private byte[] definition;
   /// <summary>
   ///[sysdiagrams]表 [definition]列
   /// </summary>
   public byte[] Definition
   {
     get{ return definition; }
     set{ this.definition=value;}
   }
  }
}

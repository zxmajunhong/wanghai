using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class FileInfo
  {
   //FileInfo表的默认构造方法
   public FileInfo ()
   {

   }
   private int fileid;
   /// <summary>
   ///[FileInfo]表主键
   /// </summary>
   public int Fileid
   {
     get{ return fileid; }
     set{ this.fileid=value;}
   }
   private string filename;
   /// <summary>
   ///[FileInfo]表 [filename]列
   /// </summary>
   public string Filename
   {
     get{ return filename; }
     set{ this.filename=value;}
   }
   private string filepath;
   /// <summary>
   ///[FileInfo]表 [filepath]列
   /// </summary>
   public string Filepath
   {
     get{ return filepath; }
     set{ this.filepath=value;}
   }
   private string fileextension;
   /// <summary>
   ///[FileInfo]表 [fileextension]列
   /// </summary>
   public string Fileextension
   {
     get{ return fileextension; }
     set{ this.fileextension=value;}
   }
   private DateTime createdate;
   /// <summary>
   ///[FileInfo]表 [createdate]列
   /// </summary>
   public DateTime Createdate
   {
     get{ return createdate; }
     set{ this.createdate=value;}
   }
   private LoginInfo ower;
   /// <summary>
   ///[FileInfo]表外键
   ///原列名[ower]
   ///原类型[int]
   ///主键表[LoginInfo]
   ///关联列[id]
   /// </summary>
   public LoginInfo Ower
   {
     get{ return ower; }
     set{ this.ower=value;}
   }
  }
}

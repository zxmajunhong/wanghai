using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class FileInfo
  {
   //FileInfo���Ĭ�Ϲ��췽��
   public FileInfo ()
   {

   }
   private int fileid;
   /// <summary>
   ///[FileInfo]������
   /// </summary>
   public int Fileid
   {
     get{ return fileid; }
     set{ this.fileid=value;}
   }
   private string filename;
   /// <summary>
   ///[FileInfo]�� [filename]��
   /// </summary>
   public string Filename
   {
     get{ return filename; }
     set{ this.filename=value;}
   }
   private string filepath;
   /// <summary>
   ///[FileInfo]�� [filepath]��
   /// </summary>
   public string Filepath
   {
     get{ return filepath; }
     set{ this.filepath=value;}
   }
   private string fileextension;
   /// <summary>
   ///[FileInfo]�� [fileextension]��
   /// </summary>
   public string Fileextension
   {
     get{ return fileextension; }
     set{ this.fileextension=value;}
   }
   private DateTime createdate;
   /// <summary>
   ///[FileInfo]�� [createdate]��
   /// </summary>
   public DateTime Createdate
   {
     get{ return createdate; }
     set{ this.createdate=value;}
   }
   private LoginInfo ower;
   /// <summary>
   ///[FileInfo]�����
   ///ԭ����[ower]
   ///ԭ����[int]
   ///������[LoginInfo]
   ///������[id]
   /// </summary>
   public LoginInfo Ower
   {
     get{ return ower; }
     set{ this.ower=value;}
   }
  }
}

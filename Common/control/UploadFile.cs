using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Common
{
    public class UploadFile
    {
        /// <summary>
        /// 图片上传（成功返回文件名，错误返回错误信息）
        /// </summary>
        /// <param name="ControlId">上传控件Id</param>
        /// <param name="FilePath">上传路径（如："upload/image"）</param>
        /// <param name="FileName">上传文件名（空默认问2011020303格式的时间串）</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="FileSize">上传文件最大值（以M为单位，如：5）</param>
        /// <param name="OriginalImg">是否保留原图</param>
        /// <returns></returns>
        public static string UploadImage(HtmlInputFile ControlId, string FilePath, int width, int height, float FileSize, bool OriginalImg = true)
        {
            string output = "";
            string err = uperror(ControlId, FileSize);
            if (err != "")
            {
                output = err;
            }
            else
            {
                string FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("/" + FilePath)))
                {
                    System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/" + FilePath));
                }
                string UploadFileName = HttpContext.Current.Server.MapPath("/" + FilePath + "/" + "temp" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg");
                ControlId.PostedFile.SaveAs(UploadFileName);
                output = FileName;
                System.Drawing.Image originalImage = System.Drawing.Image.FromFile(UploadFileName);
                int towidth = width;
                int toheight = height;
                int x = 0;
                int y = 0;
                int ow = originalImage.Width;
                int oh = originalImage.Height;
                if (originalImage.Width <= width && originalImage.Height <= height)  //原图
                {
                    toheight = originalImage.Height;
                    towidth = originalImage.Width;
                }
                else
                {
                    if (originalImage.Width > originalImage.Height)
                    {
                        toheight = originalImage.Height * width / originalImage.Width;
                        towidth = width;
                    }
                    else
                    {
                        towidth = originalImage.Width * height / originalImage.Height;
                        toheight = height;
                    }
                }
                System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);//新建一个bmp图片
                Graphics g = System.Drawing.Graphics.FromImage(bitmap);//新建一个画板
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High; //设置高质量插值法
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;//设置高质量,低速度呈现平滑程度
                g.Clear(Color.Transparent); //清空画布并以透明背景色填充
                g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight), new Rectangle(x, y, ow, oh), GraphicsUnit.Pixel);//在指定位置并且按指定大小绘制原图片的指定部分

                System.Drawing.Image bitmapoldpic = new System.Drawing.Bitmap(originalImage.Width, originalImage.Height);//新建一个bmp图片
                Graphics goldpic = System.Drawing.Graphics.FromImage(bitmapoldpic);//新建一个画板
                goldpic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High; //设置高质量插值法
                goldpic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;//设置高质量,低速度呈现平滑程度
                goldpic.Clear(Color.Transparent); //清空画布并以透明背景色填充
                goldpic.DrawImage(originalImage, new Rectangle(0, 0, originalImage.Width, originalImage.Height), new Rectangle(x, y, ow, oh), GraphicsUnit.Pixel);//在指定位置并且按指定大小绘制原图片的指定部分
                try
                {
                    if (!File.Exists(FileName))
                    {
                        if (OriginalImg)
                        {
                            bitmapoldpic.Save(HttpContext.Current.Server.MapPath("/" + FilePath + "/" + FileName), System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        string NewName = FileName.Substring(0, FileName.LastIndexOf(".")) + "_" + width + "_" + height + ".jpg";
                        bitmap.Save(HttpContext.Current.Server.MapPath("/" + FilePath + "/" + NewName), System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
                catch (System.Exception e)
                {
                    throw e;
                }
                finally
                {
                    originalImage.Dispose();
                    bitmap.Dispose();
                    g.Dispose();
                    System.IO.File.Delete(UploadFileName);
                }
            }

            return output;
        }

        private static string uperror(HtmlInputFile ControlId, float FileSize)
        {
            string output = "";
            string filename = ControlId.PostedFile.FileName;
            if (filename == "")
            {
                output = "请选择图片...";
            }
            else
            {
                float FileLength = float.Parse((float.Parse(ControlId.PostedFile.ContentLength.ToString()) / 1024 / 1024).ToString("#0.00"));
                if (FileLength > FileSize)
                {
                    output = "文件大小不得超过" + FileSize + "M" + "<font style=\"color:#000;\">(&nbsp;当前文件大小约为&nbsp;" + FileLength + "M&nbsp;)</font>";
                }
                FileExtension[] fe = { FileExtension.GIF, FileExtension.JPG, FileExtension.BMP };
                if (!FileValidation.IsAllowedExtension(ControlId, fe))
                {
                    string style = FileNodeName(fe);
                    output = "只支持" + style + "格式图片";
                }
                else
                {
                    output = "";
                }
            }
            return output;
        }

        private static string FileNodeName(FileExtension[] fe)
        {
            string output = "";
            for (int i = 0; i < fe.Length; i++)
            {
                output += fe[i].ToString().ToLower() + "、";
            }
            if (output != "")
            {
                output = output.Substring(0, output.LastIndexOf("、"));
            }
            return output;
        }
        private enum FileExtension
        {
            JPG = 255216,
            GIF = 7173,
            PNG = 13780,
            BMP = 6677,
            Office = 208207,     // xls.doc.ppt
            SWF = 6787,
            RAR = 8297,
            ZIP = 8075,
            _7Z = 55122,
            EXEandDLL = 7790,
            XML = 6063,
            HTML = 6033,
            ASPX = 239187,
            CS = 117115,
            JS = 119105,
            TXT = 210187,
            SQL = 255254,
            DataBase = 01,          //accdb,mdb       
            PSD = 5666,      // psd 
            BT = 10056       //bt种子 
            // 255216 jpg;
            // 7173 gif;
            // 6677 bmp,
            // 13780 png;
            // 6787 swf
            // 7790 exe dll,
            // 8297 rar
            // 8075 zip
            // 55122 7z
            // 6063 xml
            // 6033 html
            // 239187 aspx
            // 117115 cs
            // 119105 js
            // 102100 txt
            // 255254 sql
            // 255216 jpg;    
            // 7173 gif;    
            // 6677 bmp,    
            // 13780 png;    
            // 7790 exe dll,    
            // 8297 rar    
            // 6063 xml    
            // 6033 html    
            // 239187 aspx    
            // 117115 cs    
            // 119105 js    
            // 210187 txt    
            //255254 sql  

        }
        private class FileValidation
        {
            public static bool IsAllowedExtension(HtmlInputFile fu, FileExtension[] fileEx)
            {
                int fileLen = fu.PostedFile.ContentLength;
                byte[] imgArray = new byte[fileLen];
                fu.PostedFile.InputStream.Read(imgArray, 0, fileLen);
                MemoryStream ms = new MemoryStream(imgArray);
                System.IO.BinaryReader br = new System.IO.BinaryReader(ms);
                string fileclass = "";
                byte buffer;
                try
                {
                    buffer = br.ReadByte();
                    fileclass = buffer.ToString();
                    buffer = br.ReadByte();
                    fileclass += buffer.ToString();
                }
                catch
                {
                }
                br.Close();
                ms.Close();
                foreach (FileExtension fe in fileEx)
                {
                    if (Int32.Parse(fileclass) == (int)fe)
                        return true;
                }
                return false;
            }
        }

    }
}
using System;
namespace EtNet_Models
{
	/// <summary>
	/// FirmInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class FirmInfo
	{
		public FirmInfo()
		{}
		#region Model
		private int _id;
		private string _firmcode;
		private string _sname;
		private string _cname;
		private string _ename;
		private string _caddress;
		private string _eaddress;
		private string _telephone;
		private string _fax;
		private string _mailbox;
		private string _postalcode;
		private string _website;
		private string _taxnum;
		private string _orgcode;
		private string _imgpath;
		private string _remark;

		/// <summary>
		/// 主键
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 公司代码
		/// </summary>
		public string firmcode
		{
			set{ _firmcode=value;}
			get{return _firmcode;}
		}
		/// <summary>
		/// 公司简称
		/// </summary>
		public string sname
		{
			set{ _sname=value;}
			get{return _sname;}
		}
		/// <summary>
		/// 公司中文名称
		/// </summary>
		public string cname
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		/// <summary>
		/// 公司英文名称
		/// </summary>
		public string ename
		{
			set{ _ename=value;}
			get{return _ename;}
		}
		/// <summary>
		/// 公司中文地址
		/// </summary>
		public string caddress
		{
			set{ _caddress=value;}
			get{return _caddress;}
		}
		/// <summary>
		/// 公司英文地址
		/// </summary>
		public string eaddress
		{
			set{ _eaddress=value;}
			get{return _eaddress;}
		}
		/// <summary>
		/// 公司电话
		/// </summary>
		public string telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 传真号码
		/// </summary>
		public string fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string mailbox
		{
			set{ _mailbox=value;}
			get{return _mailbox;}
		}
		/// <summary>
		/// 邮政编码
		/// </summary>
		public string postalcode
		{
			set{ _postalcode=value;}
			get{return _postalcode;}
		}
		/// <summary>
		/// 公司网址
		/// </summary>
		public string website
		{
			set{ _website=value;}
			get{return _website;}
		}
		/// <summary>
		/// 税务登记号
		/// </summary>
		public string taxnum
		{
			set{ _taxnum=value;}
			get{return _taxnum;}
		}
		/// <summary>
		/// 机构代码
		/// </summary>
		public string orgcode
		{
			set{ _orgcode=value;}
			get{return _orgcode;}
		}
		/// <summary>
		/// 图像路径
		/// </summary>
		public string imgpath
		{
			set{ _imgpath=value;}
			get{return _imgpath;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}


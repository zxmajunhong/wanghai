using System;
namespace EtNet_Models
{
	/// <summary>
	/// Product:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Product
	{
		public Product()
		{}
		#region Model
		private int _prodid;
		private string _prodno;
		private string _prodname;
		private string _prodtypeid;
		private string _brief;
		private decimal? _premiumrate;
		private bool _flagmain;
		private string _remark;
		private decimal? _commrate;
		private decimal? _procrate;
		/// <summary>
		/// 
		/// </summary>
		public int ProdID
		{
			set{ _prodid=value;}
			get{return _prodid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProdNo
		{
			set{ _prodno=value;}
			get{return _prodno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProdName
		{
			set{ _prodname=value;}
			get{return _prodname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProdTypeID
		{
			set{ _prodtypeid=value;}
			get{return _prodtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Brief
		{
			set{ _brief=value;}
			get{return _brief;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PremiumRate
		{
			set{ _premiumrate=value;}
			get{return _premiumrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool FlagMain
		{
			set{ _flagmain=value;}
			get{return _flagmain;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? CommRate
		{
			set{ _commrate=value;}
			get{return _commrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ProcRate
		{
			set{ _procrate=value;}
			get{return _procrate;}
		}
		#endregion Model

	}
}


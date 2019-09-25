using System;
namespace EtNet_Models
{
	/// <summary>
	/// ProdClass:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProdClass
	{
		public ProdClass()
		{}
		#region Model
		private string _prodclassno;
		private string _prodclassname;
		private int? _prior;
		private bool _viewinreport;
		/// <summary>
		/// 
		/// </summary>
		public string ProdClassNo
		{
			set{ _prodclassno=value;}
			get{return _prodclassno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProdClassName
		{
			set{ _prodclassname=value;}
			get{return _prodclassname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Prior
		{
			set{ _prior=value;}
			get{return _prior;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool ViewInReport
		{
			set{ _viewinreport=value;}
			get{return _viewinreport;}
		}
		#endregion Model

	}
}


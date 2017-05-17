using System;
namespace EtNet_Models
{
	/// <summary>
	/// ProductType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProductType
	{
		public ProductType()
		{}
		#region Model
		private string _prodtypeno;
		private string _prodtypename;
		private string _parentid;
		private string _prodclass;
		private int? _targettypeid;
		/// <summary>
		/// 
		/// </summary>
		public string ProdTypeNo
		{
			set{ _prodtypeno=value;}
			get{return _prodtypeno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProdTypeName
		{
			set{ _prodtypename=value;}
			get{return _prodtypename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProdClass
		{
			set{ _prodclass=value;}
			get{return _prodclass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TargetTypeId
		{
			set{ _targettypeid=value;}
			get{return _targettypeid;}
		}
		#endregion Model

	}
}


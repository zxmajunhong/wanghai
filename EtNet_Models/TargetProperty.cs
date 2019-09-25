using System;
namespace EtNet_Models
{
	/// <summary>
	/// TargetProperty:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TargetProperty
	{
		public TargetProperty()
		{}
		#region Model
		private int _targettypeid;
		private int _propertyid;
		private string _propertyno;
		private string _propertyname;
		private int _propertytype;
		private bool? _mainflag;
        private int _enumTypeId;
        private bool? _isrequired; //是否必填
		/// <summary>
		/// 标的种类关联id
		/// </summary>
		public int TargetTypeId
		{
			set{ _targettypeid=value;}
			get{return _targettypeid;}
		}
		/// <summary>
		/// id
		/// </summary>
		public int PropertyId
		{
			set{ _propertyid=value;}
			get{return _propertyid;}
		}
		/// <summary>
		/// 标的编号
		/// </summary>
		public string PropertyNO
		{
			set{ _propertyno=value;}
			get{return _propertyno;}
		}
		/// <summary>
		/// 标的描述
		/// </summary>
		public string PropertyName
		{
			set{ _propertyname=value;}
			get{return _propertyname;}
		}
		/// <summary>
		/// 数据类型关联字段
		/// </summary>
		public int PropertyType
		{
			set{ _propertytype=value;}
			get{return _propertytype;}
		}
		/// <summary>
		/// 是否是主标
		/// </summary>
		public bool? MainFlag
		{
			set{ _mainflag=value;}
			get{return _mainflag;}
		}
        /// <summary>
		/// 标的属性关联id
		/// </summary>
        public int EnumTypeId
		{
			set{ _enumTypeId=value;}
			get{return _enumTypeId;}
		}

        /// <summary>
        /// 是否必填
        /// </summary>
        public bool? IsRequired
        {
            set { _isrequired = value; }
            get { return _isrequired; }
        }
		#endregion Model

	}
}


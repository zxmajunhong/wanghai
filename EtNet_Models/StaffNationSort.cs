﻿using System;
namespace EtNet_Models
{
	/// <summary>
	/// StaffNationSort:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class StaffNationSort
	{
		public StaffNationSort()
		{}
		#region Model
		private int _id;
		private string _txt;

		/// <summary>
		/// 主键
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 民族名称
		/// </summary>
		public string txt
		{
			set{ _txt=value;}
			get{return _txt;}
		}
		#endregion Model

	}
}


using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace EtNet_Models
{
    //TargetEnum
    public class TargetEnum
    {

        /// <summary>
        /// EnumTypeId
        /// </summary>		
        private int _enumtypeid;
        public int EnumTypeId
        {
            get { return _enumtypeid; }
            set { _enumtypeid = value; }
        }
        /// <summary>
        /// EnumId
        /// </summary>		
        private int _enumid;
        public int EnumId
        {
            get { return _enumid; }
            set { _enumid = value; }
        }
        /// <summary>
        /// EnumValue
        /// </summary>		
        private string _enumvalue;
        public string EnumValue
        {
            get { return _enumvalue; }
            set { _enumvalue = value; }
        }

    }
}
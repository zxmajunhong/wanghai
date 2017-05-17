using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtNet_Models
{
    public class ViewMenuByLogin
    {
        /// <summary>
        /// 视图信息
        /// </summary>
        private string loginid;

        public string Loginid
        {
            get { return loginid; }
            set { loginid = value; }
        }
        /// <summary>
        /// 父菜单
        /// </summary>
        public string parentId
        {
            get;
            set;
        }

        /// <summary>
        /// 子菜单
        /// </summary>
        public IList<ViewMenuByLogin> childsMenu
        {
            get;
            set;
        }

        public int childsCount
        {
            get;
            set;
        }



        /// <summary>
        /// 节点ID
        /// </summary>
        private int nodeid;

        public int Nodeid
        {
            get { return nodeid; }
            set { nodeid = value; }
        }

      
       

        /// <summary>
        /// 菜单名
        /// </summary>
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        /// <summary>
        /// 菜单URL
        /// </summary>
        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        /// <summary>
        /// 菜单排序
        /// </summary>
        private int nodesort;

        public int Nodesort
        {
            get { return nodesort; }
            set { nodesort = value; }
        }

        /// <summary>
        /// 父节点信息
        /// </summary>
        private int parentnodeid;

        public int Parentnodeid
        {
            get { return parentnodeid; }
            set { parentnodeid = value; }
        }

        private string icon;
        /// <summary>
        ///[FunctionMenu]表 [icon]列
        /// </summary>
        public string Icon
        {
            get { return icon == null ? "" : icon; }
            set { this.icon = value; }
        }

        public override string ToString()
        {
            string i = "{id : " + this.Nodeid + " , name: '" + this.Name + "',url: '" + this.Url + "',icon: '" + this.Icon + "',childsMenu:[";
            bool hasChilds = false;
            if ((hasChilds = this.childsMenu != null) && this.childsMenu.Count > 0)
            {
                foreach (var subMenu in this.childsMenu)
                {
                    i += subMenu.ToString() + ",";
                }
                i = i.Remove(i.Length - 1);
            }
            i += "]}";
            return i;
        }
    }
}

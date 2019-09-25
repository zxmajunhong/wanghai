using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using EtNet_DAL;
using EtNet_Models;
namespace EtNet_BLL
{
    public class NoticeInfoManager
    {
        public static int addNoticeInfo(NoticeInfo noticeinfo)
        {
            return NoticeInfoService.addNoticeInfo(noticeinfo);
        }

        public static int updateNoticeInfo(NoticeInfo noticeinfo)
        {
            return NoticeInfoService.updateNoticeInfoById(noticeinfo);
        }

        public static int deleteNoticeInfo(int noticeid)
        {
            return NoticeInfoService.deleteNoticeInfoById(noticeid);
        }

        public static NoticeInfo getNoticeInfoById(int noticeid)
        {
            return NoticeInfoService.getNoticeInfoById(noticeid);
        }

        public static IList<NoticeInfo> getNoticeInfoAll()
        {
            return NoticeInfoService.getNoticeInfoAll();
        }

        public static NoticeInfo getNoticeInfoBySql(string sql)
        {
            return NoticeInfoService.getNoticeInfoBySql(sql);
        }


        /// <summary>
        /// ���ع��������б�
        /// </summary>
        /// <param name="strfileds">���ص��ֶ�</param>
        /// <param name="strwhere">ɸѡ����</param>
        public static DataTable getlist(string strfileds, string strwhere)
        {
            return NoticeInfoService.getlist(strfileds, strwhere);
        }

    }
}

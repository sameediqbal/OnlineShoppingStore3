using OnlineShoppingStore3.DAL;
using OnlineShoppingStore3.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace OnlineShoppingStore3.Models.Home
{
    public class HomeIndexViewModel
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        dbMyOnlineShoppingEntities context = new dbMyOnlineShoppingEntities();
        public IPagedList<Tbl_Product> ListOfProduct { get; set; }
        public HomeIndexViewModel CreateModel(string search,int pageSize,int? page)
        {
            SqlParameter[] param=new SqlParameter[]{
                new SqlParameter("@search",search??(object)DBNull.Value)
            };
             IPagedList<Tbl_Product> data = context.Database.SqlQuery<Tbl_Product>("GetBySearch @Search", param).ToList().ToPagedList(page ?? 1, pageSize);
            return new HomeIndexViewModel
            {
                ListOfProduct = data
            };
        }
    }
}
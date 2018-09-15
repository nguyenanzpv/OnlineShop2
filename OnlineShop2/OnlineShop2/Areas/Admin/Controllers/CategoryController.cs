using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace OnlineShop2.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index(string searchString,int page=1, int pageSize=10)
        {
            var dao = new CategoryDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]//gui thong tin insert user len server
        public ActionResult Create(Category model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new CategoryDao();
                    long id = dao.Insert(model);
                    if (id > 0)
                    {
                        SetAlert("Thêm user thành công", "success");
                        return RedirectToAction("Index", "Category");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm không thành công");
                    }
                    return View("Index");
                }
                else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new CategoryDao();
            var cate = dao.ViewDetail(id);
            return View(cate);
        }

        [HttpPost]//gui thong tin insert user len server
        public ActionResult Edit(Category model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new CategoryDao();
                    
                    bool id = dao.Update(model);
                    if (id)
                    {
                        SetAlert("Cập nhật user thành công", "success");
                        return RedirectToAction("Index", "Category");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật không thành công");
                    }
                    return View("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
            
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new CategoryDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new CategoryDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}
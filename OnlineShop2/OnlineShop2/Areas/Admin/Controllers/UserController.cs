﻿using Model.Dao;
using Model.EF;
using OnlineShop2.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace OnlineShop2.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User: Default trieu goi form cho user nhap thong tin insert
        public ActionResult Index(string searchString,int page=1,int pageSize=10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString,page,pageSize);
            ViewBag.SearchString = searchString;//ViewBag luu gia tri controller qua View. Bi mat khi redirect. Session thi van luu qua lai giua cac controller
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var dao = new UserDao();
            var user = dao.ViewDetail(id);
            return View(user);
        }

        [HttpPost]//gui thong tin insert user len server
        public ActionResult Create(User model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new UserDao();
                    if (!string.IsNullOrEmpty(model.Password))
                    {
                        var encryptedMd5Pas = Encryptor.MD5Hash(model.Password);
                        model.Password = encryptedMd5Pas;
                    }
                    else
                    {
                        ModelState.AddModelError("", "Mật khẩu không được để trống");
                    }

                    long id = dao.Insert(model);
                    if (id > 0)
                    {
                        SetAlert("Thêm user thành công", "success");
                        return RedirectToAction("Index", "User");
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

        [HttpPost]//gui thong tin insert user len server
        public ActionResult Edit(User model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (!string.IsNullOrEmpty(model.Password))
                {
                    var encryptedMd5Pas = Encryptor.MD5Hash(model.Password);
                    model.Password = encryptedMd5Pas;
                }
                
                bool id = dao.Update(model);
                if (id)
                {
                    SetAlert("Cập nhật user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new {
                status = result
            });
        }
    }
}
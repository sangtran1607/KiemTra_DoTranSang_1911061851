using KiemTra_DoTranSang_1911061851.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiemTra_DoTranSang_1911061851.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVien
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult ListSV()
        {
            var all_sv = from ss in data.SinhViens select ss;
            return View(all_sv);
        }

        //Detail
        public ActionResult Detail(string id)
        {
            var D_sv = data.SinhViens.Where(m => m.MaSV == id).First();
            return View(D_sv);
        }

        //Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien s)
        {
            var E_MaSV = collection["MaSV"];
            var E_HoTen = collection["HoTen"];
            var E_GioiTinh = collection["GioiTinh"];
            var E_NgaySinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_Hinh = collection["Hinh"];
            var E_MaNganh = collection["MaNganh"];

            if (string.IsNullOrEmpty(E_HoTen))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.MaSV = E_MaSV.ToString();
                s.HoTen = E_HoTen.ToString();
                s.GioiTinh = E_GioiTinh.ToString();
                s.NgaySinh = E_NgaySinh;
                s.Hinh = E_Hinh.ToString();
                s.MaNganh = E_MaNganh.ToString();
                data.SinhViens.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("ListSV");
            }
            return this.Create();
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }
        //Delete
        public ActionResult Delete(string id)
        {
            var sinhviens = data.SinhViens.First(m => m.MaSV == id);
            return View(sinhviens);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var sinhviens = data.SinhViens.Where(m => m.MaSV == id).First();
            data.SinhViens.DeleteOnSubmit(sinhviens);
            data.SubmitChanges();
            return RedirectToAction("ListSV");
        }
        ////Edit
        public ActionResult Edit(string id)
        {
            var E_Sinhvien = data.SinhViens.First(m => m.MaSV == id);
            return View(E_Sinhvien);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var E_Id = data.SinhViens.First(m => m.MaSV == id);
            var E_Hoten = collection["Hoten"];
            var E_GioiTinh = collection["gioitinh"];
            var E_NgaySinh = Convert.ToDateTime(collection["ngaysinh"]);
            var E_Hinh = collection["hinh"];
            var E_MaNganh = collection["manganh"];
            E_Id.MaSV = id;
            if (string.IsNullOrEmpty(E_Hoten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_Id.HoTen = E_Hoten;
                E_Id.GioiTinh = E_GioiTinh;
                E_Id.NgaySinh = E_NgaySinh;
                E_Id.Hinh = E_Hinh;
                E_Id.MaNganh = E_MaNganh;
                UpdateModel(E_Id);
                data.SubmitChanges();
                return RedirectToAction("ListSV");
            }
            return this.Edit(id);
        }
    }
}
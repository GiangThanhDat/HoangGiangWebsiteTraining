using AutoMapper;
using Newtonsoft.Json.Linq;
using Platform.Model;
using Platform.Service;
using Platform.Web.infratructure.core;
using Platform.Web.infratructure.extensions;
using Platform.Web.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Platform.Web.Infrastructure.Core;

namespace Platform.Web.Api
{
    [RoutePrefix("api/khachhang-taikhoan")]
    [Authorize]
    public class KhachHang_TaiKhoanController : ApiControllerBase
    {
        IKhachHang_TaiKhoanService _khachHang_TaiKhoanService;

        public KhachHang_TaiKhoanController(ILoiService loiService, IKhachHang_TaiKhoanService khachHang_TaiKhoanService) : base(loiService)
        {
            this._khachHang_TaiKhoanService = khachHang_TaiKhoanService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<KhachHang_TaiKhoanViewModel> khachHang_TaiKhoanVM)
        //{


        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (!ModelState.IsValid)
        //        {
        //            response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            foreach (var item in khachHang_TaiKhoanVM)
        //            {
        //                var newThongBao = new KhachHang_TaiKhoan();
        //                newThongBao.UpdateKhachHang_TaiKhoan(item);

        //                _khachHang_TaiKhoanService.Add(newThongBao);
        //                _khachHang_TaiKhoanService.Save();
        //            }


        //            //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
        //            response = request.CreateResponse(HttpStatusCode.OK);
        //        }

        //        return response;
        //    });
        //}


        //[Route("update")]
        //[HttpPut]
        //[AllowAnonymous]
        //public HttpResponseMessage update(HttpRequestMessage request, KhachHang_TaiKhoanViewModel khachHang_TaiKhoanViewModel)

        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (!ModelState.IsValid)
        //        {
        //            request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {

        //            var vienchucDb = _khachHang_TaiKhoanService.getID(Convert.ToInt32(khachHang_TaiKhoanViewModel.ID));

        //            vienchucDb.UpdateKhachHang_TaiKhoan(khachHang_TaiKhoanViewModel);
        //            _khachHang_TaiKhoanService.Update(vienchucDb);
        //            _khachHang_TaiKhoanService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<KhachHang_TaiKhoanViewModel> khachHang_TaiKhoanVM)
        {


            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    foreach (var item in khachHang_TaiKhoanVM)
                    {
                        var newThongBao = new KhachHang_TaiKhoan();
                        newThongBao.UpdateKhachHang_TaiKhoan(item);

                        _khachHang_TaiKhoanService.Add(newThongBao);
                        _khachHang_TaiKhoanService.Save();
                    }
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });

        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _khachHang_TaiKhoanService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<KhachHang_TaiKhoan>,IEnumerable<KhachHang_TaiKhoanViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaKhachHang_TaiKhoan.Length + x.MaKhachHang_TaiKhoan);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }


      

        public HttpResponseMessage Post(HttpRequestMessage request, KhachHang_TaiKhoan khachHang_TaiKhoan)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _khachHang_TaiKhoanService.Add(khachHang_TaiKhoan);
                    _khachHang_TaiKhoanService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, KhachHang_TaiKhoan khachHang_TaiKhoan)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _khachHang_TaiKhoanService.Update(khachHang_TaiKhoan);
                    _khachHang_TaiKhoanService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _khachHang_TaiKhoanService.delete(id);
                    _khachHang_TaiKhoanService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

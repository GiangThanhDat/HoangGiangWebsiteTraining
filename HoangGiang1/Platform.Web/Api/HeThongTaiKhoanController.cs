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
    [RoutePrefix("api/hethongtaikhoan")]
    [Authorize]
    public class HeThongTaiKhoanController : ApiControllerBase
    {
        IHeThongTaiKhoanService _heThongTaiKhoanService;

        public HeThongTaiKhoanController(ILoiService loiService, IHeThongTaiKhoanService HeThongTaiKhoanService) : base(loiService)
        {
            this._heThongTaiKhoanService = HeThongTaiKhoanService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietChungTuMuaHangViewModel> chiTietChungTuMuaHangVM)
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
        //            foreach (var item in chiTietChungTuMuaHangVM)
        //            {
        //                var newThongBao = new ChiTietChungTuMuaHang();
        //                newThongBao.UpdateChiTietChungTuMuaHang(item);

        //                _heThongTaiKhoanService.Add(newThongBao);
        //                _heThongTaiKhoanService.Save();
        //            }


        //            //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
        //            response = request.CreateResponse(HttpStatusCode.OK);
        //        }

        //        return response;
        //    });
        //}
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, HeThongTaiKhoanViewModel heThongTaiKhoanViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else 
                {
                    var newThongBao = new HeThongTaiKhoan();
                    newThongBao.UpdateHeThongTaiKhoan(heThongTaiKhoanViewModel);

                    _heThongTaiKhoanService.Add(newThongBao);
                    _heThongTaiKhoanService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });

        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage update(HttpRequestMessage request, HeThongTaiKhoanViewModel heThongTaiKhoanViewModel)

        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {

                    var vienchucDb = _heThongTaiKhoanService.GetByID(heThongTaiKhoanViewModel.Id);

                    vienchucDb.UpdateHeThongTaiKhoan(heThongTaiKhoanViewModel);
                    _heThongTaiKhoanService.Update(vienchucDb);
                    _heThongTaiKhoanService.Commit();

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


                var listCategory = _heThongTaiKhoanService.GetAll();
           
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }




        public HttpResponseMessage Post(HttpRequestMessage request, HeThongTaiKhoan loaiCongCuDung)
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
                    _heThongTaiKhoanService.Add(loaiCongCuDung);
                    _heThongTaiKhoanService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, HeThongTaiKhoan loaiCongCuDung)
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
                    _heThongTaiKhoanService.Update(loaiCongCuDung);
                    _heThongTaiKhoanService.Commit();

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
                    _heThongTaiKhoanService.delete(id);
                    _heThongTaiKhoanService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

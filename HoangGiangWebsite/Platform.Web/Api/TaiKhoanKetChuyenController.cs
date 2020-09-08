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
    [RoutePrefix("api/taikhoanketchuyen")]
    [Authorize]
    public class TaiKhoanKetChuyenController : ApiControllerBase
    {
        ITaiKhoanKetChuyenService _taiKhoanKetChuyenService;

        public TaiKhoanKetChuyenController(ILoiService loiService, ITaiKhoanKetChuyenService TaiKhoanKetChuyenService) : base(loiService)
        {
            this._taiKhoanKetChuyenService = TaiKhoanKetChuyenService;
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

        //                _taiKhoanKetChuyenService.Add(newThongBao);
        //                _taiKhoanKetChuyenService.Save();
        //            }


        //            //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
        //            response = request.CreateResponse(HttpStatusCode.OK);
        //        }

        //        return response;
        //    });
        //}
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, TaiKhoanKetChuyenViewModel taiKhoanKetChuyenViewModel)
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
                    var newThongBao = new TaiKhoanKetChuyen();
                    newThongBao.UpdateTaiKhoanKetChuyen(taiKhoanKetChuyenViewModel);

                    _taiKhoanKetChuyenService.Add(newThongBao);
                    _taiKhoanKetChuyenService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });

        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage update(HttpRequestMessage request, TaiKhoanKetChuyenViewModel taiKhoanKetChuyenViewModel)

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

                    var vienchucDb = _taiKhoanKetChuyenService.GetByID(taiKhoanKetChuyenViewModel.Id);

                    vienchucDb.UpdateTaiKhoanKetChuyen(taiKhoanKetChuyenViewModel);
                    _taiKhoanKetChuyenService.Update(vienchucDb);
                    _taiKhoanKetChuyenService.Commit();

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


                var listCategory = _taiKhoanKetChuyenService.GetAll();
           
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }




        public HttpResponseMessage Post(HttpRequestMessage request, TaiKhoanKetChuyen loaiCongCuDung)
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
                    _taiKhoanKetChuyenService.Add(loaiCongCuDung);
                    _taiKhoanKetChuyenService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, TaiKhoanKetChuyen loaiCongCuDung)
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
                    _taiKhoanKetChuyenService.Update(loaiCongCuDung);
                    _taiKhoanKetChuyenService.Commit();

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
                    _taiKhoanKetChuyenService.delete(id);
                    _taiKhoanKetChuyenService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

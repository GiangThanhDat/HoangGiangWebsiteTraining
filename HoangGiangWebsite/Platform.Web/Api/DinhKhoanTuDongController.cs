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
    [RoutePrefix("api/dinhkhoantudong")]
    [Authorize]
    public class DinhKhoanTuDongController : ApiControllerBase
    {
        IDinhKhoanTuDongService _dinhKhoanTuDongService;

        public DinhKhoanTuDongController(ILoiService loiService, IDinhKhoanTuDongService DinhKhoanTuDongService) : base(loiService)
        {
            this._dinhKhoanTuDongService = DinhKhoanTuDongService;
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

        //                _dinhKhoanTuDongService.Add(newThongBao);
        //                _dinhKhoanTuDongService.Save();
        //            }


        //            //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
        //            response = request.CreateResponse(HttpStatusCode.OK);
        //        }

        //        return response;
        //    });
        //}
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, DinhKhoanTuDongViewModel dinhKhoanTuDongViewModel)
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
                    var newThongBao = new DinhKhoanTuDong();
                    newThongBao.UpdateDinhKhoanTuDong(dinhKhoanTuDongViewModel);

                    _dinhKhoanTuDongService.Add(newThongBao);
                    _dinhKhoanTuDongService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });

        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage update(HttpRequestMessage request, DinhKhoanTuDongViewModel dinhKhoanTuDongViewModel)

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

                    var vienchucDb = _dinhKhoanTuDongService.GetByID(dinhKhoanTuDongViewModel.Id);

                    vienchucDb.UpdateDinhKhoanTuDong(dinhKhoanTuDongViewModel);
                    _dinhKhoanTuDongService.Update(vienchucDb);
                    _dinhKhoanTuDongService.Commit();

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


                var listCategory = _dinhKhoanTuDongService.GetAll();
           
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }




        public HttpResponseMessage Post(HttpRequestMessage request, DinhKhoanTuDong loaiCongCuDung)
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
                    _dinhKhoanTuDongService.Add(loaiCongCuDung);
                    _dinhKhoanTuDongService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, DinhKhoanTuDong loaiCongCuDung)
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
                    _dinhKhoanTuDongService.Update(loaiCongCuDung);
                    _dinhKhoanTuDongService.Commit();

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
                    _dinhKhoanTuDongService.delete(id);
                    _dinhKhoanTuDongService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

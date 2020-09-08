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
    [RoutePrefix("api/loaicongcudungcu")]
    [Authorize]
    public class LoaiCongCuDungCuController : ApiControllerBase
    {
        ILoaiCongCuDungCuService _loaiCongCuDungCuService;

        public LoaiCongCuDungCuController(ILoiService loiService, ILoaiCongCuDungCuService loaiCongCuDungCuServiceService) : base(loiService)
        {
            this._loaiCongCuDungCuService = loaiCongCuDungCuServiceService;
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

        //                _loaiCongCuDungCuService.Add(newThongBao);
        //                _loaiCongCuDungCuService.Save();
        //            }


        //            //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
        //            response = request.CreateResponse(HttpStatusCode.OK);
        //        }

        //        return response;
        //    });
        //}
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, LoaiCongCuDungCuViewModel loaiCongCuDungCuView)
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
                    var newThongBao = new LoaiCongCuDungCu();
                    newThongBao.UpdateLoaiCongCuDungCu(loaiCongCuDungCuView);

                    _loaiCongCuDungCuService.Add(newThongBao);
                    _loaiCongCuDungCuService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });

        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage update(HttpRequestMessage request, LoaiCongCuDungCuViewModel loaiCongCuDungCuViewModel)

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

                    var vienchucDb = _loaiCongCuDungCuService.getID(loaiCongCuDungCuViewModel.MaLoaiCCDC);

                    vienchucDb.UpdateLoaiCongCuDungCu(loaiCongCuDungCuViewModel);
                    _loaiCongCuDungCuService.Update(vienchucDb);
                    _loaiCongCuDungCuService.Commit();

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


                var listCategory = _loaiCongCuDungCuService.GetAll();
                var a = listCategory.OrderBy(x => x.MaLoaiCCDC);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }




        public HttpResponseMessage Post(HttpRequestMessage request, LoaiCongCuDungCu loaiCongCuDung)
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
                    _loaiCongCuDungCuService.Add(loaiCongCuDung);
                    _loaiCongCuDungCuService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, LoaiCongCuDungCu loaiCongCuDung)
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
                    _loaiCongCuDungCuService.Update(loaiCongCuDung);
                    _loaiCongCuDungCuService.Commit();

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
                    _loaiCongCuDungCuService.delete(id);
                    _loaiCongCuDungCuService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

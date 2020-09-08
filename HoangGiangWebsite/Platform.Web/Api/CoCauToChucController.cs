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
    [RoutePrefix("api/cocautochuc")]
    [Authorize]
    public class CoCauToChucController : ApiControllerBase
    {
        ICoCauTocChucService _coCauToChucService;

        public CoCauToChucController(ILoiService loiService, ICoCauTocChucService CoCauTocChucService) : base(loiService)
        {
            this._coCauToChucService = CoCauTocChucService;
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

        //                _coCauToChucService.Add(newThongBao);
        //                _coCauToChucService.Save();
        //            }


        //            //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
        //            response = request.CreateResponse(HttpStatusCode.OK);
        //        }

        //        return response;
        //    });
        //}
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, CoCauToChucViewModel coCauToChucViewModel)
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
                    var newThongBao = new CoCauToChuc();
                    newThongBao.UpdateCoCauToChuc(coCauToChucViewModel);

                    _coCauToChucService.Add(newThongBao);
                    _coCauToChucService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });

        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage update(HttpRequestMessage request, CoCauToChucViewModel coCauToChucViewModel)

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

                    var vienchucDb = _coCauToChucService.getID(coCauToChucViewModel.MaDonVi);

                    vienchucDb.UpdateCoCauToChuc(coCauToChucViewModel);
                    _coCauToChucService.Update(vienchucDb);
                    _coCauToChucService.Commit();

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


                var listCategory = _coCauToChucService.GetAll();
           
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }




        public HttpResponseMessage Post(HttpRequestMessage request, CoCauToChuc loaiCongCuDung)
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
                    _coCauToChucService.Add(loaiCongCuDung);
                    _coCauToChucService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, CoCauToChuc loaiCongCuDung)
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
                    _coCauToChucService.Update(loaiCongCuDung);
                    _coCauToChucService.Commit();

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
                    _coCauToChucService.delete(id);
                    _coCauToChucService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

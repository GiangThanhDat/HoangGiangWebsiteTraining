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
    [RoutePrefix("api/chitietphieuchi")]
    [Authorize]
    public class ChiTietPhieuChiController : ApiControllerBase
    {
        IChiTietPhieuChiService _chiTietPhieuChiService;

        public ChiTietPhieuChiController(ILoiService loiService, IChiTietPhieuChiService chiTietPhieuChiService) : base(loiService)
        {
            this._chiTietPhieuChiService = chiTietPhieuChiService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietPhieuChiViewModel> chiTietPhieuChiVM)
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
        //            foreach (var item in chiTietPhieuChiVM)
        //            {
        //                var newThongBao = new ChiTietPhieuChi();
        //                newThongBao.UpdateChiTietPhieuChi(item);

        //                _chiTietPhieuChiService.Add(newThongBao);
        //                _chiTietPhieuChiService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, ChiTietPhieuChiViewModel chiTietPhieuChiViewModel)

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

        //            var vienchucDb = _chiTietPhieuChiService.getID(Convert.ToInt32(chiTietPhieuChiViewModel.ID));

        //            vienchucDb.UpdateChiTietPhieuChi(chiTietPhieuChiViewModel);
        //            _chiTietPhieuChiService.Update(vienchucDb);
        //            _chiTietPhieuChiService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}





        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietPhieuChiViewModel> chiTietHopDongMuaVM)
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
                    foreach (var item in chiTietHopDongMuaVM)
                    {
                        var newThongBao = new ChiTietPhieuChi();
                        newThongBao.UpdateChiTietPhieuChi(item);

                        _chiTietPhieuChiService.Add(newThongBao);
                        _chiTietPhieuChiService.Save();
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


                var listCategory = _chiTietPhieuChiService.GetAll();
              //  var responseData = Mapper.Map<IEnumerable<ChiTietPhieuChi>,IEnumerable<ChiTietPhieuChiViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("xemChiTietPhieuChi")]
        [HttpGet]
        public HttpResponseMessage xemChiTietPhieuChi(HttpRequestMessage request,string MaPC)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _chiTietPhieuChiService.xemChiTietPhieuChi(MaPC);
                //  var responseData = Mapper.Map<IEnumerable<ChiTietPhieuChi>,IEnumerable<ChiTietPhieuChiViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }



        public HttpResponseMessage Post(HttpRequestMessage request, ChiTietPhieuChi chiTietPhieuChi)
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
                    _chiTietPhieuChiService.Add(chiTietPhieuChi);
                    _chiTietPhieuChiService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, ChiTietPhieuChi chiTietPhieuChi)
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
                    _chiTietPhieuChiService.Update(chiTietPhieuChi);
                    _chiTietPhieuChiService.Commit();

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
                    _chiTietPhieuChiService.delete(id);
                    _chiTietPhieuChiService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

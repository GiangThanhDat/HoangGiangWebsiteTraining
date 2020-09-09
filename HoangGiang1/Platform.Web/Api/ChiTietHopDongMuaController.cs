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
    [RoutePrefix("api/chitiethopdongmua")]
    [Authorize]
    public class ChiTietHopDongMuaController : ApiControllerBase
    {
        IChiTietHopDongMuaService _chiTietHopDongMuaService;

        public ChiTietHopDongMuaController(ILoiService loiService, IChiTietHopDongMuaService chiTietHopDongMuaService) : base(loiService)
        {
            this._chiTietHopDongMuaService = chiTietHopDongMuaService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietHopDongMuaViewModel> chiTietHopDongMuaVM)
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
        //            foreach (var item in chiTietHopDongMuaVM)
        //            {
        //                var newThongBao = new ChiTietHopDongMua();
        //                newThongBao.UpdateChiTietHopDongMua(item);

        //                _chiTietHopDongMuaService.Add(newThongBao);
        //                _chiTietHopDongMuaService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, ChiTietHopDongMuaViewModel chiTietHopDongMuaViewModel)

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

        //            var vienchucDb = _chiTietHopDongMuaService.getID(Convert.ToInt32(chiTietHopDongMuaViewModel.ID));

        //            vienchucDb.UpdateChiTietHopDongMua(chiTietHopDongMuaViewModel);
        //            _chiTietHopDongMuaService.Update(vienchucDb);
        //            _chiTietHopDongMuaService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietHopDongMuaViewModel> chiTietHopDongMuaVM)
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
                        var newThongBao = new ChiTietHopDongMua();
                        newThongBao.UpdateChiTietHopDongMua(item);

                        _chiTietHopDongMuaService.Add(newThongBao);
                        _chiTietHopDongMuaService.Save();
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


                var listCategory = _chiTietHopDongMuaService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<ChiTietHopDongMua>,IEnumerable<ChiTietHopDongMuaViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaChiTietHopDongMua.Length + x.MaChiTietHopDongMua);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
         [Route("getchitiethopdongmua")]
        public HttpResponseMessage getchitiethopdongmua(HttpRequestMessage request,string maHD)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _chiTietHopDongMuaService.getchitiethopdongmua(maHD);
                //  var responseData = Mapper.Map<IEnumerable<ChiTietHopDongMua>,IEnumerable<ChiTietHopDongMuaViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaChiTietHopDongMua.Length + x.MaChiTietHopDongMua);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }


      

        public HttpResponseMessage Post(HttpRequestMessage request, ChiTietHopDongMua chiTietHopDongMua)
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
                    _chiTietHopDongMuaService.Add(chiTietHopDongMua);
                    _chiTietHopDongMuaService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, ChiTietHopDongMua chiTietHopDongMua)
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
                    _chiTietHopDongMuaService.Update(chiTietHopDongMua);
                    _chiTietHopDongMuaService.Commit();

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
                    _chiTietHopDongMuaService.delete(id);
                    _chiTietHopDongMuaService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

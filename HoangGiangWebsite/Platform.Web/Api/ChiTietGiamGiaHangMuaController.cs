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
    [RoutePrefix("api/chitietgiamgiahangmua")]
    [Authorize]
    public class ChiTietGiamGiaHangMuaController : ApiControllerBase
    {
        IChiTietGiamGiaHangMuaService _chiTietGiamGiaHangMuaService;

        public ChiTietGiamGiaHangMuaController(ILoiService loiService, IChiTietGiamGiaHangMuaService chiTietGiamGiaHangMuaService) : base(loiService)
        {
            this._chiTietGiamGiaHangMuaService = chiTietGiamGiaHangMuaService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietGiamGiaHangMuaViewModel> chiTietGiamGiaHangMuaVM)
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
        //            foreach (var item in chiTietGiamGiaHangMuaVM)
        //            {
        //                var newThongBao = new ChiTietGiamGiaHangMua();
        //                newThongBao.UpdateChiTietGiamGiaHangMua(item);

        //                _chiTietGiamGiaHangMuaService.Add(newThongBao);
        //                _chiTietGiamGiaHangMuaService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, ChiTietGiamGiaHangMuaViewModel chiTietGiamGiaHangMuaViewModel)

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

        //            var vienchucDb = _chiTietGiamGiaHangMuaService.getID(Convert.ToInt32(chiTietGiamGiaHangMuaViewModel.ID));

        //            vienchucDb.UpdateChiTietGiamGiaHangMua(chiTietGiamGiaHangMuaViewModel);
        //            _chiTietGiamGiaHangMuaService.Update(vienchucDb);
        //            _chiTietGiamGiaHangMuaService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietGiamGiaHangMuaViewModel> chiTietGiamGiaHangMuaVM)
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
                    foreach (var item in chiTietGiamGiaHangMuaVM)
                    {
                        var newThongBao = new ChiTietGiamGiaHangMua();
                        newThongBao.UpdateChiTietGiamGiaHangMua(item);

                        _chiTietGiamGiaHangMuaService.Add(newThongBao);
                        _chiTietGiamGiaHangMuaService.Save();
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


                var listCategory = _chiTietGiamGiaHangMuaService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<ChiTietGiamGiaHangMua>,IEnumerable<ChiTietGiamGiaHangMuaViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaChiTietGiamGiaHangMua.Length + x.MaChiTietGiamGiaHangMua);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("getchitietgiamgiahangmua")]
        public HttpResponseMessage getchitietgiamgiahangmua(HttpRequestMessage request, string MaGiamGiaHangMua)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _chiTietGiamGiaHangMuaService.getchitietgiamgiahangmua(MaGiamGiaHangMua);
              
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }


      

        public HttpResponseMessage Post(HttpRequestMessage request, ChiTietGiamGiaHangMua chiTietGiamGiaHangMua)
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
                    _chiTietGiamGiaHangMuaService.Add(chiTietGiamGiaHangMua);
                    _chiTietGiamGiaHangMuaService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, ChiTietGiamGiaHangMua chiTietGiamGiaHangMua)
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
                    _chiTietGiamGiaHangMuaService.Update(chiTietGiamGiaHangMua);
                    _chiTietGiamGiaHangMuaService.Commit();

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
                    _chiTietGiamGiaHangMuaService.delete(id);
                    _chiTietGiamGiaHangMuaService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

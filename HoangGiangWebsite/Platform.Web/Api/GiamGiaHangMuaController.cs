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
    [RoutePrefix("api/giamgiahangmua")]
    [Authorize]
    public class GiamGiaHangMuaController : ApiControllerBase
    {
        IGiamGiaHangMuaService _giamGiaHangMuaService;

        public GiamGiaHangMuaController(ILoiService loiService, IGiamGiaHangMuaService giamGiaHangMuaService) : base(loiService)
        {
            this._giamGiaHangMuaService = giamGiaHangMuaService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<GiamGiaHangMuaViewModel> giamGiaHangMuaVM)
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
        //            foreach (var item in giamGiaHangMuaVM)
        //            {
        //                var newThongBao = new GiamGiaHangMua();
        //                newThongBao.UpdateGiamGiaHangMua(item);

        //                _giamGiaHangMuaService.Add(newThongBao);
        //                _giamGiaHangMuaService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, GiamGiaHangMuaViewModel giamGiaHangMuaViewModel)

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

        //            var vienchucDb = _giamGiaHangMuaService.getID(Convert.ToInt32(giamGiaHangMuaViewModel.ID));

        //            vienchucDb.UpdateGiamGiaHangMua(giamGiaHangMuaViewModel);
        //            _giamGiaHangMuaService.Update(vienchucDb);
        //            _giamGiaHangMuaService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}





        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, GiamGiaHangMuaViewModel khachHang)
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
                    var newThongBao = new GiamGiaHangMua();
                    newThongBao.UpdateGiamGiaHangMua(khachHang);

                    _giamGiaHangMuaService.Add(newThongBao);
                    _giamGiaHangMuaService.Save();
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


                var listCategory = _giamGiaHangMuaService.GetAll();
              //  var responseData = Mapper.Map<IEnumerable<GiamGiaHangMua>,IEnumerable<GiamGiaHangMuaViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
         [Route("getgiamgiahangmua")]
        public HttpResponseMessage getgiamgiahangmua(HttpRequestMessage request, DateTime ngaydau, DateTime ngaycuoi)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _giamGiaHangMuaService.getgiamgiahangmua(ngaydau, ngaycuoi);
              //  var responseData = Mapper.Map<IEnumerable<GiamGiaHangMua>,IEnumerable<GiamGiaHangMuaViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }


      

        public HttpResponseMessage Post(HttpRequestMessage request, GiamGiaHangMua giamGiaHangMua)
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
                    _giamGiaHangMuaService.Add(giamGiaHangMua);
                    _giamGiaHangMuaService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, GiamGiaHangMua giamGiaHangMua)
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
                    _giamGiaHangMuaService.Update(giamGiaHangMua);
                    _giamGiaHangMuaService.Commit();

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
                    _giamGiaHangMuaService.delete(id);
                    _giamGiaHangMuaService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

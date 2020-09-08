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
    [RoutePrefix("api/giamgiahangban")]
    [Authorize]
    public class GiamGiaHangBanController : ApiControllerBase
    {
        IGiamGiaHangBanService _giamGiaHangBangService;

        public GiamGiaHangBanController(ILoiService loiService, IGiamGiaHangBanService giamGiaHangBangService) : base(loiService)
        {
            this._giamGiaHangBangService = giamGiaHangBangService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<GiamGiaHangBanViewModel> giamGiaHangBangVM)
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
        //            foreach (var item in giamGiaHangBangVM)
        //            {
        //                var newThongBao = new GiamGiaHangBan();
        //                newThongBao.UpdateGiamGiaHangBan(item);

        //                _giamGiaHangBangService.Add(newThongBao);
        //                _giamGiaHangBangService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, GiamGiaHangBanViewModel giamGiaHangBangViewModel)

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

        //            var vienchucDb = _giamGiaHangBangService.getID(Convert.ToInt32(giamGiaHangBangViewModel.ID));

        //            vienchucDb.UpdateGiamGiaHangBan(giamGiaHangBangViewModel);
        //            _giamGiaHangBangService.Update(vienchucDb);
        //            _giamGiaHangBangService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}





        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, GiamGiaHangBanViewModel khachHang)
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
                    var newThongBao = new GiamGiaHangBan();
                    newThongBao.UpdateGiamGiaHangBan(khachHang);

                    _giamGiaHangBangService.Add(newThongBao);
                    _giamGiaHangBangService.Save();
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


                var listCategory = _giamGiaHangBangService.GetAll();
              //  var responseData = Mapper.Map<IEnumerable<GiamGiaHangBan>,IEnumerable<GiamGiaHangBanViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
         [Route("getgiamgiahangban")]
        public HttpResponseMessage getgiamgiahangban(HttpRequestMessage request, DateTime ngaydau, DateTime ngaycuoi)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _giamGiaHangBangService.getgiamgiahangban(ngaydau, ngaycuoi);
              //  var responseData = Mapper.Map<IEnumerable<GiamGiaHangBan>,IEnumerable<GiamGiaHangBanViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

       




        public HttpResponseMessage Post(HttpRequestMessage request, GiamGiaHangBan giamGiaHangBang)
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
                    _giamGiaHangBangService.Add(giamGiaHangBang);
                    _giamGiaHangBangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, GiamGiaHangBan giamGiaHangBang)
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
                    _giamGiaHangBangService.Update(giamGiaHangBang);
                    _giamGiaHangBangService.Commit();

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
                    _giamGiaHangBangService.delete(id);
                    _giamGiaHangBangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

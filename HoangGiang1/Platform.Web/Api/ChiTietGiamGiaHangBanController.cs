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
    [RoutePrefix("api/chitietgiamgiahangban")]
    [Authorize]
    public class ChiTietGiamGiaHangBanController : ApiControllerBase
    {
        IChiTietGiamGiaHangBanService _chiTietGiamGiaHangBanService;

        public ChiTietGiamGiaHangBanController(ILoiService loiService, IChiTietGiamGiaHangBanService chiTietGiamGiaHangBanService) : base(loiService)
        {
            this._chiTietGiamGiaHangBanService = chiTietGiamGiaHangBanService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietGiamGiaHangBanViewModel> chiTietGiamGiaHangBanVM)
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
        //            foreach (var item in chiTietGiamGiaHangBanVM)
        //            {
        //                var newThongBao = new ChiTietGiamGiaHangBan();
        //                newThongBao.UpdateChiTietGiamGiaHangBan(item);

        //                _chiTietGiamGiaHangBanService.Add(newThongBao);
        //                _chiTietGiamGiaHangBanService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, ChiTietGiamGiaHangBanViewModel chiTietGiamGiaHangBanViewModel)

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

        //            var vienchucDb = _chiTietGiamGiaHangBanService.getID(Convert.ToInt32(chiTietGiamGiaHangBanViewModel.ID));

        //            vienchucDb.UpdateChiTietGiamGiaHangBan(chiTietGiamGiaHangBanViewModel);
        //            _chiTietGiamGiaHangBanService.Update(vienchucDb);
        //            _chiTietGiamGiaHangBanService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietGiamGiaHangBanViewModel> chiTietGiamGiaHangBanVM)
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
                    foreach (var item in chiTietGiamGiaHangBanVM)
                    {
                        var newThongBao = new ChiTietGiamGiaHangBan();
                        newThongBao.UpdateChiTietGiamGiaHangBan(item);

                        _chiTietGiamGiaHangBanService.Add(newThongBao);
                        _chiTietGiamGiaHangBanService.Save();
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


                var listCategory = _chiTietGiamGiaHangBanService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<ChiTietGiamGiaHangBan>,IEnumerable<ChiTietGiamGiaHangBanViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaChiTietGiamGiaHangBan.Length + x.MaChiTietGiamGiaHangBan);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
         [Route("getchitietgiamgiahangban")]
        public HttpResponseMessage getchitietgiamgiahangban(HttpRequestMessage request,string MaGiamGiaHangBan)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _chiTietGiamGiaHangBanService.getchitietgiamgiahangban(MaGiamGiaHangBan);
                //  var responseData = Mapper.Map<IEnumerable<ChiTietGiamGiaHangBan>,IEnumerable<ChiTietGiamGiaHangBanViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaChiTietGiamGiaHangBan.Length + x.MaChiTietGiamGiaHangBan);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        

        public HttpResponseMessage Post(HttpRequestMessage request, ChiTietGiamGiaHangBan chiTietGiamGiaHangBan)
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
                    _chiTietGiamGiaHangBanService.Add(chiTietGiamGiaHangBan);
                    _chiTietGiamGiaHangBanService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, ChiTietGiamGiaHangBan chiTietGiamGiaHangBan)
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
                    _chiTietGiamGiaHangBanService.Update(chiTietGiamGiaHangBan);
                    _chiTietGiamGiaHangBanService.Commit();

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
                    _chiTietGiamGiaHangBanService.delete(id);
                    _chiTietGiamGiaHangBanService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

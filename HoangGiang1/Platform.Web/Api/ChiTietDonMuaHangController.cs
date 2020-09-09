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
    [RoutePrefix("api/chitietdonmuahang")]
    [Authorize]
    public class ChiTietDonMuaHangController : ApiControllerBase
    {
        IChiTietDonMuaHangService _chiTietDonMuaHangService;

        public ChiTietDonMuaHangController(ILoiService loiService, IChiTietDonMuaHangService chiTietDonMuaHangService) : base(loiService)
        {
            this._chiTietDonMuaHangService = chiTietDonMuaHangService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietDonMuaHangViewModel> chiTietDonMuaHangVM)
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
        //            foreach (var item in chiTietDonMuaHangVM)
        //            {
        //                var newThongBao = new ChiTietDonMuaHang();
        //                newThongBao.UpdateChiTietDonMuaHang(item);

        //                _chiTietDonMuaHangService.Add(newThongBao);
        //                _chiTietDonMuaHangService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, ChiTietDonMuaHangViewModel chiTietDonMuaHangViewModel)

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

        //            var vienchucDb = _chiTietDonMuaHangService.getID(Convert.ToInt32(chiTietDonMuaHangViewModel.ID));

        //            vienchucDb.UpdateChiTietDonMuaHang(chiTietDonMuaHangViewModel);
        //            _chiTietDonMuaHangService.Update(vienchucDb);
        //            _chiTietDonMuaHangService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietDonMuaHangViewModel> chiTietDonMuaHangVM)
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
                    foreach (var item in chiTietDonMuaHangVM)
                    {
                        var newThongBao = new ChiTietDonMuaHang();
                        newThongBao.UpdateChiTietDonMuaHang(item);

                        _chiTietDonMuaHangService.Add(newThongBao);
                        _chiTietDonMuaHangService.Save();
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


                var listCategory = _chiTietDonMuaHangService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<ChiTietDonMuaHang>,IEnumerable<ChiTietDonMuaHangViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaChiTietDonMuaHang.Length + x.MaChiTietDonMuaHang);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

        [Route("getchitiet")]
        [HttpGet]
        public HttpResponseMessage getchitiet(HttpRequestMessage request, string maMH)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _chiTietDonMuaHangService.getchitiet(maMH);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }


        public HttpResponseMessage Post(HttpRequestMessage request, ChiTietDonMuaHang chiTietDonMuaHang)
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
                    _chiTietDonMuaHangService.Add(chiTietDonMuaHang);
                    _chiTietDonMuaHangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, ChiTietDonMuaHang chiTietDonMuaHang)
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
                    _chiTietDonMuaHangService.Update(chiTietDonMuaHang);
                    _chiTietDonMuaHangService.Commit();

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
                    _chiTietDonMuaHangService.delete(id);
                    _chiTietDonMuaHangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

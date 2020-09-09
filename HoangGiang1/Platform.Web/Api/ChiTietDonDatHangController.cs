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
    [RoutePrefix("api/chitietdondathang")]
    [Authorize]
    public class ChiTietDonDatHangController : ApiControllerBase
    {
        IChiTietDonDatHangService _chiTietDonDatHangService;

        public ChiTietDonDatHangController(ILoiService loiService, IChiTietDonDatHangService chiTietDonDatHangService) : base(loiService)
        {
            this._chiTietDonDatHangService = chiTietDonDatHangService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietDonDatHangViewModel> chiTietDonDatHangVM)
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
        //            foreach (var item in chiTietDonDatHangVM)
        //            {
        //                var newThongBao = new ChiTietDonDatHang();
        //                newThongBao.UpdateChiTietDonDatHang(item);

        //                _chiTietDonDatHangService.Add(newThongBao);
        //                _chiTietDonDatHangService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, ChiTietDonDatHangViewModel chiTietDonDatHangViewModel)

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

        //            var vienchucDb = _chiTietDonDatHangService.getID(Convert.ToInt32(chiTietDonDatHangViewModel.ID));

        //            vienchucDb.UpdateChiTietDonDatHang(chiTietDonDatHangViewModel);
        //            _chiTietDonDatHangService.Update(vienchucDb);
        //            _chiTietDonDatHangService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietDonDatHangViewModel> chiTietDonDatHangVM)
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
                    foreach (var item in chiTietDonDatHangVM)
                    {
                        var newThongBao = new ChiTietDonDatHang();
                        newThongBao.UpdateChiTietDonDatHang(item);

                        _chiTietDonDatHangService.Add(newThongBao);
                        _chiTietDonDatHangService.Save();
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


                var listCategory = _chiTietDonDatHangService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<ChiTietDonDatHang>,IEnumerable<ChiTietDonDatHangViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaChiTietDonDatHang.Length + x.MaChiTietDonDatHang);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
         [Route("getchitietdondathang")]
        public HttpResponseMessage getchitietdondathang(HttpRequestMessage request,string  MaDonDatHang)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _chiTietDonDatHangService.getchitietdondathang(MaDonDatHang);
                //  var responseData = Mapper.Map<IEnumerable<ChiTietDonDatHang>,IEnumerable<ChiTietDonDatHangViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaChiTietDonDatHang.Length + x.MaChiTietDonDatHang);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

      



        public HttpResponseMessage Post(HttpRequestMessage request, ChiTietDonDatHang chiTietDonDatHang)
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
                    _chiTietDonDatHangService.Add(chiTietDonDatHang);
                    _chiTietDonDatHangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, ChiTietDonDatHang chiTietDonDatHang)
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
                    _chiTietDonDatHangService.Update(chiTietDonDatHang);
                    _chiTietDonDatHangService.Commit();

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
                    _chiTietDonDatHangService.delete(id);
                    _chiTietDonDatHangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

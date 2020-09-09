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
    [RoutePrefix("api/chitiethoadon_banhang")]
    [Authorize]
    public class ChiTietHoaDon_BanHangController : ApiControllerBase
    {
        IChiTietHoaDon_BanHangService _chiTietHoaDon_BanHangService;

        public ChiTietHoaDon_BanHangController(ILoiService loiService, IChiTietHoaDon_BanHangService chiTietHoaDon_BanHangService) : base(loiService)
        {
            this._chiTietHoaDon_BanHangService = chiTietHoaDon_BanHangService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietHoaDon_BanHangViewModel> chiTietHoaDon_BanHangVM)
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
        //            foreach (var item in chiTietHoaDon_BanHangVM)
        //            {
        //                var newThongBao = new ChiTietHoaDon_BanHang();
        //                newThongBao.UpdateChiTietHoaDon_BanHang(item);

        //                _chiTietHoaDon_BanHangService.Add(newThongBao);
        //                _chiTietHoaDon_BanHangService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, ChiTietHoaDon_BanHangViewModel chiTietHoaDon_BanHangViewModel)

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

        //            var vienchucDb = _chiTietHoaDon_BanHangService.getID(Convert.ToInt32(chiTietHoaDon_BanHangViewModel.ID));

        //            vienchucDb.UpdateChiTietHoaDon_BanHang(chiTietHoaDon_BanHangViewModel);
        //            _chiTietHoaDon_BanHangService.Update(vienchucDb);
        //            _chiTietHoaDon_BanHangService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}




        [Route("getchitiethoadonbanhang")]
        public HttpResponseMessage getchitiethoadonbanhang(HttpRequestMessage request, string MaHoaDon)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _chiTietHoaDon_BanHangService.getchitiethoadonbanhang(MaHoaDon);
                //  var responseData = Mapper.Map<IEnumerable<HoaDon_BanHang>,IEnumerable<HoaDon_BanHangViewModel>>(listCategory);
                // var b = listCategory.OrderBy(x => x.MaHoaDon_BanHang.Length + x.MaHoaDon_BanHang);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietHoaDon_BanHangViewModel> chiTietHoaDon_BanHangVM)
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
                    foreach (var item in chiTietHoaDon_BanHangVM)
                    {
                        var newThongBao = new ChiTietHoaDon_BanHang();
                        newThongBao.UpdateChiTietHoaDon_BanHang(item);

                        _chiTietHoaDon_BanHangService.Add(newThongBao);
                        _chiTietHoaDon_BanHangService.Save();
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


                var listCategory = _chiTietHoaDon_BanHangService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<ChiTietHoaDon_BanHang>,IEnumerable<ChiTietHoaDon_BanHangViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaChiTietHoaDon_BanHang.Length + x.MaChiTietHoaDon_BanHang);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

     
        public HttpResponseMessage Post(HttpRequestMessage request, ChiTietHoaDon_BanHang chiTietHoaDon_BanHang)
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
                    _chiTietHoaDon_BanHangService.Add(chiTietHoaDon_BanHang);
                    _chiTietHoaDon_BanHangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, ChiTietHoaDon_BanHang chiTietHoaDon_BanHang)
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
                    _chiTietHoaDon_BanHangService.Update(chiTietHoaDon_BanHang);
                    _chiTietHoaDon_BanHangService.Commit();

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
                    _chiTietHoaDon_BanHangService.delete(id);
                    _chiTietHoaDon_BanHangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

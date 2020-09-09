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
    [RoutePrefix("api/hoadon_banhang")]
    [Authorize]
    public class HoaDon_BanHangController : ApiControllerBase
    {
        IHoaDon_BanHangService _hoaDon_BanHangService;

        public HoaDon_BanHangController(ILoiService loiService, IHoaDon_BanHangService hoaDon_BanHangService) : base(loiService)
        {
            this._hoaDon_BanHangService = hoaDon_BanHangService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<HoaDon_BanHangViewModel> hoaDon_BanHangVM)
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
        //            foreach (var item in hoaDon_BanHangVM)
        //            {
        //                var newThongBao = new HoaDon_BanHang();
        //                newThongBao.UpdateHoaDon_BanHang(item);

        //                _hoaDon_BanHangService.Add(newThongBao);
        //                _hoaDon_BanHangService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, HoaDon_BanHangViewModel hoaDon_BanHangViewModel)

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

        //            var vienchucDb = _hoaDon_BanHangService.getID(Convert.ToInt32(hoaDon_BanHangViewModel.ID));

        //            vienchucDb.UpdateHoaDon_BanHang(hoaDon_BanHangViewModel);
        //            _hoaDon_BanHangService.Update(vienchucDb);
        //            _hoaDon_BanHangService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, HoaDon_BanHangViewModel khachHang)
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
                    var newThongBao = new HoaDon_BanHang();
                    newThongBao.UpdateHoaDon_BanHang(khachHang);

                    _hoaDon_BanHangService.Add(newThongBao);
                    _hoaDon_BanHangService.Save();
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


                var listCategory = _hoaDon_BanHangService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<HoaDon_BanHang>,IEnumerable<HoaDon_BanHangViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaHoaDon_BanHang.Length + x.MaHoaDon_BanHang);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

        [Route("getxuathoadonbanhang")]
        public HttpResponseMessage getxuathoadonbanhang(HttpRequestMessage request, DateTime ngaydau, DateTime ngaycuoi)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _hoaDon_BanHangService.getxuathoadonbanhang(ngaydau, ngaycuoi);
                //  var responseData = Mapper.Map<IEnumerable<HoaDon_BanHang>,IEnumerable<HoaDon_BanHangViewModel>>(listCategory);
                // var b = listCategory.OrderBy(x => x.MaHoaDon_BanHang.Length + x.MaHoaDon_BanHang);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        public HttpResponseMessage Post(HttpRequestMessage request, HoaDon_BanHang hoaDon_BanHang)
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
                    _hoaDon_BanHangService.Add(hoaDon_BanHang);
                    _hoaDon_BanHangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, HoaDon_BanHang hoaDon_BanHang)
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
                    _hoaDon_BanHangService.Update(hoaDon_BanHang);
                    _hoaDon_BanHangService.Commit();

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
                    _hoaDon_BanHangService.delete(id);
                    _hoaDon_BanHangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

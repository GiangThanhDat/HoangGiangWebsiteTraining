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
    [RoutePrefix("api/chitietphieuxuat_banhang")]
    [Authorize]
    public class ChiTietPhieuXuat_BanHangController : ApiControllerBase
    {
        IChiTietPhieuXuat_BanHangService _chiTietPhieuXuat_BanHangService;

        public ChiTietPhieuXuat_BanHangController(ILoiService loiService, IChiTietPhieuXuat_BanHangService chiTietPhieuXuat_BanHangService) : base(loiService)
        {
            this._chiTietPhieuXuat_BanHangService = chiTietPhieuXuat_BanHangService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietPhieuXuat_BanHangViewModel> chiTietPhieuXuat_BanHangVM)
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
        //            foreach (var item in chiTietPhieuXuat_BanHangVM)
        //            {
        //                var newThongBao = new ChiTietPhieuXuat_BanHang();
        //                newThongBao.UpdateChiTietPhieuXuat_BanHang(item);

        //                _chiTietPhieuXuat_BanHangService.Add(newThongBao);
        //                _chiTietPhieuXuat_BanHangService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, ChiTietPhieuXuat_BanHangViewModel chiTietPhieuXuat_BanHangViewModel)

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

        //            var vienchucDb = _chiTietPhieuXuat_BanHangService.getID(Convert.ToInt32(chiTietPhieuXuat_BanHangViewModel.ID));

        //            vienchucDb.UpdateChiTietPhieuXuat_BanHang(chiTietPhieuXuat_BanHangViewModel);
        //            _chiTietPhieuXuat_BanHangService.Update(vienchucDb);
        //            _chiTietPhieuXuat_BanHangService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietPhieuXuat_BanHangViewModel> chiTietPhieuXuat_BanHangVM)
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
                    foreach (var item in chiTietPhieuXuat_BanHangVM)
                    {
                        var newThongBao = new ChiTietPhieuXuat_BanHang();
                        newThongBao.UpdateChiTietPhieuXuat_BanHang(item);

                        _chiTietPhieuXuat_BanHangService.Add(newThongBao);
                        _chiTietPhieuXuat_BanHangService.Save();
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


                var listCategory = _chiTietPhieuXuat_BanHangService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<ChiTietPhieuXuat_BanHang>,IEnumerable<ChiTietPhieuXuat_BanHangViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaChiTietPhieuXuat_BanHang.Length + x.MaChiTietPhieuXuat_BanHang);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
         [Route("getchitietxuatnhapkho")]
        public HttpResponseMessage getchitietxuatnhapkho(HttpRequestMessage request, string MaPhieuXuat)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _chiTietPhieuXuat_BanHangService.getchitietxuatnhapkho(MaPhieuXuat);
                //  var responseData = Mapper.Map<IEnumerable<ChiTietPhieuXuat_BanHang>,IEnumerable<ChiTietPhieuXuat_BanHangViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaChiTietPhieuXuat_BanHang.Length + x.MaChiTietPhieuXuat_BanHang);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

     
        public HttpResponseMessage Post(HttpRequestMessage request, ChiTietPhieuXuat_BanHang chiTietPhieuXuat_BanHang)
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
                    _chiTietPhieuXuat_BanHangService.Add(chiTietPhieuXuat_BanHang);
                    _chiTietPhieuXuat_BanHangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, ChiTietPhieuXuat_BanHang chiTietPhieuXuat_BanHang)
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
                    _chiTietPhieuXuat_BanHangService.Update(chiTietPhieuXuat_BanHang);
                    _chiTietPhieuXuat_BanHangService.Commit();

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
                    _chiTietPhieuXuat_BanHangService.delete(id);
                    _chiTietPhieuXuat_BanHangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

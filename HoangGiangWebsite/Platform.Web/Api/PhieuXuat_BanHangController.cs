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
    [RoutePrefix("api/phieuxuat_banhang")]
    [Authorize]
    public class PhieuXuat_BanHangController : ApiControllerBase
    {
        IPhieuXuat_BanHangService _phieuXuat_BanHangService;

        public PhieuXuat_BanHangController(ILoiService loiService, IPhieuXuat_BanHangService phieuXuat_BanHangService) : base(loiService)
        {
            this._phieuXuat_BanHangService = phieuXuat_BanHangService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<PhieuXuat_BanHangViewModel> phieuXuat_BanHangVM)
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
        //            foreach (var item in phieuXuat_BanHangVM)
        //            {
        //                var newThongBao = new PhieuXuat_BanHang();
        //                newThongBao.UpdatePhieuXuat_BanHang(item);

        //                _phieuXuat_BanHangService.Add(newThongBao);
        //                _phieuXuat_BanHangService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, PhieuXuat_BanHangViewModel phieuXuat_BanHangViewModel)

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

        //            var vienchucDb = _phieuXuat_BanHangService.getID(Convert.ToInt32(phieuXuat_BanHangViewModel.ID));

        //            vienchucDb.UpdatePhieuXuat_BanHang(phieuXuat_BanHangViewModel);
        //            _phieuXuat_BanHangService.Update(vienchucDb);
        //            _phieuXuat_BanHangService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, PhieuXuat_BanHangViewModel khachHang)
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
                    var newThongBao = new PhieuXuat_BanHang();
                    newThongBao.UpdatePhieuXuat_BanHang(khachHang);

                    _phieuXuat_BanHangService.Add(newThongBao);
                    _phieuXuat_BanHangService.Save();
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


                var listCategory = _phieuXuat_BanHangService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<PhieuXuat_BanHang>,IEnumerable<PhieuXuat_BanHangViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaPhieuXuat_BanHang.Length + x.MaPhieuXuat_BanHang);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
         [Route("getphieunhapxuatkho")]
        public HttpResponseMessage getphieunhapxuatkho(HttpRequestMessage request, DateTime ngaydau, DateTime ngaycuoi)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _phieuXuat_BanHangService.getphieunhapxuatkho(ngaydau, ngaycuoi);
                //  var responseData = Mapper.Map<IEnumerable<PhieuXuat_BanHang>,IEnumerable<PhieuXuat_BanHangViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaPhieuXuat_BanHang.Length + x.MaPhieuXuat_BanHang);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

     
        public HttpResponseMessage Post(HttpRequestMessage request, PhieuXuat_BanHang phieuXuat_BanHang)
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
                    _phieuXuat_BanHangService.Add(phieuXuat_BanHang);
                    _phieuXuat_BanHangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, PhieuXuat_BanHang phieuXuat_BanHang)
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
                    _phieuXuat_BanHangService.Update(phieuXuat_BanHang);
                    _phieuXuat_BanHangService.Commit();

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
                    _phieuXuat_BanHangService.delete(id);
                    _phieuXuat_BanHangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

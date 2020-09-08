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
    [RoutePrefix("api/phieunhapkho")]
    [Authorize]
    public class PhieuNhapKhoController : ApiControllerBase
    {
        IPhieuNhapKhoService _phieuNhapKhoService;

        public PhieuNhapKhoController(ILoiService loiService, IPhieuNhapKhoService phieuNhapKhoService) : base(loiService)
        {
            this._phieuNhapKhoService = phieuNhapKhoService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<PhieuNhapKhoViewModel> phieuNhapKhoVM)
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
        //            foreach (var item in phieuNhapKhoVM)
        //            {
        //                var newThongBao = new PhieuNhapKho();
        //                newThongBao.UpdatePhieuNhapKho(item);

        //                _phieuNhapKhoService.Add(newThongBao);
        //                _phieuNhapKhoService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, PhieuNhapKhoViewModel phieuNhapKhoViewModel)

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

        //            var vienchucDb = _phieuNhapKhoService.getID(Convert.ToInt32(phieuNhapKhoViewModel.ID));

        //            vienchucDb.UpdatePhieuNhapKho(phieuNhapKhoViewModel);
        //            _phieuNhapKhoService.Update(vienchucDb);
        //            _phieuNhapKhoService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, PhieuNhapKhoViewModel khachHang)
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
                    var newThongBao = new PhieuNhapKho();
                    newThongBao.UpdatePhieuNhapKho(khachHang);

                    _phieuNhapKhoService.Add(newThongBao);
                    _phieuNhapKhoService.Save();
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


                var listCategory = _phieuNhapKhoService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<PhieuNhapKho>,IEnumerable<PhieuNhapKhoViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaPhieuNhapKho.Length + x.MaPhieuNhapKho);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("getphieunhapxuatkho")]
        public HttpResponseMessage getphieunhapxuatkho(HttpRequestMessage request, DateTime ngaydau, DateTime ngaycuoi)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _phieuNhapKhoService.getphieunhapxuatkho(ngaydau, ngaycuoi);
                //  var responseData = Mapper.Map<IEnumerable<PhieuNhapKho>,IEnumerable<PhieuNhapKhoViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaPhieuNhapKho.Length + x.MaPhieuNhapKho);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

     
        public HttpResponseMessage Post(HttpRequestMessage request, PhieuNhapKho phieuNhapKho)
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
                    _phieuNhapKhoService.Add(phieuNhapKho);
                    _phieuNhapKhoService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, PhieuNhapKho phieuNhapKho)
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
                    _phieuNhapKhoService.Update(phieuNhapKho);
                    _phieuNhapKhoService.Commit();

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
                    _phieuNhapKhoService.delete(id);
                    _phieuNhapKhoService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

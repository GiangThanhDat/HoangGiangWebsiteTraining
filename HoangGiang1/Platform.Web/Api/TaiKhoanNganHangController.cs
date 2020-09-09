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
    [RoutePrefix("api/taikhoannganhang")]
    [Authorize]
    public class TaiKhoanNganHangController : ApiControllerBase
    {
        ITaiKhoanNganHangService _taiKhoanNganHangService;

        public TaiKhoanNganHangController(ILoiService loiService, ITaiKhoanNganHangService taiKhoanNganHangService) : base(loiService)
        {
            this._taiKhoanNganHangService = taiKhoanNganHangService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<TaiKhoanNganHangViewModel> taiKhoanNganHangVM)
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
        //            foreach (var item in taiKhoanNganHangVM)
        //            {
        //                var newThongBao = new TaiKhoanNganHang();
        //                newThongBao.UpdateTaiKhoanNganHang(item);

        //                _taiKhoanNganHangService.Add(newThongBao);
        //                _taiKhoanNganHangService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, TaiKhoanNganHangViewModel taiKhoanNganHangViewModel)

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

        //            var vienchucDb = _taiKhoanNganHangService.getID(Convert.ToInt32(taiKhoanNganHangViewModel.ID));

        //            vienchucDb.UpdateTaiKhoanNganHang(taiKhoanNganHangViewModel);
        //            _taiKhoanNganHangService.Update(vienchucDb);
        //            _taiKhoanNganHangService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<TaiKhoanNganHangViewModel>  khachHang)
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
                    foreach (var item in khachHang)
                    {
                        var newThongBao = new TaiKhoanNganHang();
                        newThongBao.UpdateTaiKhoanNganHang(item);

                        _taiKhoanNganHangService.Add(newThongBao);
                        _taiKhoanNganHangService.Save();
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


                var listCategory = _taiKhoanNganHangService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<TaiKhoanNganHang>,IEnumerable<TaiKhoanNganHangViewModel>>(listCategory);
                //var b = listCategory.OrderBy(x => x.MaTaiKhoanNganHang.Length + x.MaTaiKhoanNganHang);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }


      

        public HttpResponseMessage Post(HttpRequestMessage request, TaiKhoanNganHang taiKhoanNganHang)
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
                    _taiKhoanNganHangService.Add(taiKhoanNganHang);
                    _taiKhoanNganHangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, TaiKhoanNganHang taiKhoanNganHang)
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
                    _taiKhoanNganHangService.Update(taiKhoanNganHang);
                    _taiKhoanNganHangService.Commit();

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
                    _taiKhoanNganHangService.delete(id);
                    _taiKhoanNganHangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

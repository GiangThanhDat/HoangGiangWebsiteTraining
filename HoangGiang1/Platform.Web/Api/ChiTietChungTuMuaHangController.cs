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
    [RoutePrefix("api/chitietchungtumuahang")]
    [Authorize]
    public class ChiTietChungTuMuaHangController : ApiControllerBase
    {
        IChiTietChungTuMuaHangService _chiTietChungTuMuaHangService;

        public ChiTietChungTuMuaHangController(ILoiService loiService, IChiTietChungTuMuaHangService chiTietChungTuMuaHangService) : base(loiService)
        {
            this._chiTietChungTuMuaHangService = chiTietChungTuMuaHangService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietChungTuMuaHangViewModel> chiTietChungTuMuaHangVM)
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
        //            foreach (var item in chiTietChungTuMuaHangVM)
        //            {
        //                var newThongBao = new ChiTietChungTuMuaHang();
        //                newThongBao.UpdateChiTietChungTuMuaHang(item);

        //                _chiTietChungTuMuaHangService.Add(newThongBao);
        //                _chiTietChungTuMuaHangService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, ChiTietChungTuMuaHangViewModel chiTietChungTuMuaHangViewModel)

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

        //            var vienchucDb = _chiTietChungTuMuaHangService.getID(Convert.ToInt32(chiTietChungTuMuaHangViewModel.ID));

        //            vienchucDb.UpdateChiTietChungTuMuaHang(chiTietChungTuMuaHangViewModel);
        //            _chiTietChungTuMuaHangService.Update(vienchucDb);
        //            _chiTietChungTuMuaHangService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietChungTuMuaHangViewModel> chiTietChungTuMuaHangVM)
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
                    foreach (var item in chiTietChungTuMuaHangVM)
                    {
                        var newThongBao = new ChiTietChungTuMuaHang();
                        newThongBao.UpdateChiTietChungTuMuaHang(item);

                        _chiTietChungTuMuaHangService.Add(newThongBao);
                        _chiTietChungTuMuaHangService.Save();
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


                var listCategory = _chiTietChungTuMuaHangService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<ChiTietChungTuMuaHang>,IEnumerable<ChiTietChungTuMuaHangViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaChiTietChungTuMuaHang.Length + x.MaChiTietChungTuMuaHang);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }


      

        public HttpResponseMessage Post(HttpRequestMessage request, ChiTietChungTuMuaHang chiTietChungTuMuaHang)
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
                    _chiTietChungTuMuaHangService.Add(chiTietChungTuMuaHang);
                    _chiTietChungTuMuaHangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, ChiTietChungTuMuaHang chiTietChungTuMuaHang)
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
                    _chiTietChungTuMuaHangService.Update(chiTietChungTuMuaHang);
                    _chiTietChungTuMuaHangService.Commit();

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
                    _chiTietChungTuMuaHangService.delete(id);
                    _chiTietChungTuMuaHangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

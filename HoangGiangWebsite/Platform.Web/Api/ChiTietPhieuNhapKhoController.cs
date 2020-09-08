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
    [RoutePrefix("api/chitietphieunhapkho")]
    [Authorize]
    public class ChiTietPhieuNhapKhoController : ApiControllerBase
    {
        IChiTietPhieuNhapKhoService _chiTietPhieuNhapKhoService;

        public ChiTietPhieuNhapKhoController(ILoiService loiService, IChiTietPhieuNhapKhoService chiTietPhieuNhapKhoService) : base(loiService)
        {
            this._chiTietPhieuNhapKhoService = chiTietPhieuNhapKhoService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietPhieuNhapKhoViewModel> chiTietPhieuNhapKhoVM)
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
        //            foreach (var item in chiTietPhieuNhapKhoVM)
        //            {
        //                var newThongBao = new ChiTietPhieuNhapKho();
        //                newThongBao.UpdateChiTietPhieuNhapKho(item);

        //                _chiTietPhieuNhapKhoService.Add(newThongBao);
        //                _chiTietPhieuNhapKhoService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, ChiTietPhieuNhapKhoViewModel chiTietPhieuNhapKhoViewModel)

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

        //            var vienchucDb = _chiTietPhieuNhapKhoService.getID(Convert.ToInt32(chiTietPhieuNhapKhoViewModel.ID));

        //            vienchucDb.UpdateChiTietPhieuNhapKho(chiTietPhieuNhapKhoViewModel);
        //            _chiTietPhieuNhapKhoService.Update(vienchucDb);
        //            _chiTietPhieuNhapKhoService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietPhieuNhapKhoViewModel> chiTietPhieuNhapKhoVM)
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
                    foreach (var item in chiTietPhieuNhapKhoVM)
                    {
                        var newThongBao = new ChiTietPhieuNhapKho();
                        newThongBao.UpdateChiTietPhieuNhapKho(item);

                        _chiTietPhieuNhapKhoService.Add(newThongBao);
                        _chiTietPhieuNhapKhoService.Save();
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


                var listCategory = _chiTietPhieuNhapKhoService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<ChiTietPhieuNhapKho>,IEnumerable<ChiTietPhieuNhapKhoViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaChiTietPhieuNhapKho.Length + x.MaChiTietPhieuNhapKho);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
           [Route("getchitietxuatnhapkho")]
        public HttpResponseMessage getchitietxuatnhapkho(HttpRequestMessage request, string MaPhieuNhapKho)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _chiTietPhieuNhapKhoService.getchitietxuatnhapkho(MaPhieuNhapKho);
                //  var responseData = Mapper.Map<IEnumerable<ChiTietPhieuNhapKho>,IEnumerable<ChiTietPhieuNhapKhoViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaChiTietPhieuNhapKho.Length + x.MaChiTietPhieuNhapKho);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
          
        

        public HttpResponseMessage Post(HttpRequestMessage request, ChiTietPhieuNhapKho chiTietPhieuNhapKho)
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
                    _chiTietPhieuNhapKhoService.Add(chiTietPhieuNhapKho);
                    _chiTietPhieuNhapKhoService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, ChiTietPhieuNhapKho chiTietPhieuNhapKho)
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
                    _chiTietPhieuNhapKhoService.Update(chiTietPhieuNhapKho);
                    _chiTietPhieuNhapKhoService.Commit();

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
                    _chiTietPhieuNhapKhoService.delete(id);
                    _chiTietPhieuNhapKhoService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

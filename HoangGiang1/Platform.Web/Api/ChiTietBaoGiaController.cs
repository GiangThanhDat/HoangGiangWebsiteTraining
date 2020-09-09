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
    [RoutePrefix("api/chitietbaogia")]
    [Authorize]
    public class ChiTietBaoGiaController : ApiControllerBase
    {
        IChiTietBaoGiaService _chiTietBaoGiaService;

        public ChiTietBaoGiaController(ILoiService loiService, IChiTietBaoGiaService chiTietBaoGiaService) : base(loiService)
        {
            this._chiTietBaoGiaService = chiTietBaoGiaService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietBaoGiaViewModel> chiTietBaoGiaVM)
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
        //            foreach (var item in chiTietBaoGiaVM)
        //            {
        //                var newThongBao = new ChiTietBaoGia();
        //                newThongBao.UpdateChiTietBaoGia(item);

        //                _chiTietBaoGiaService.Add(newThongBao);
        //                _chiTietBaoGiaService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, ChiTietBaoGiaViewModel chiTietBaoGiaViewModel)

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

        //            var vienchucDb = _chiTietBaoGiaService.getID(Convert.ToInt32(chiTietBaoGiaViewModel.ID));

        //            vienchucDb.UpdateChiTietBaoGia(chiTietBaoGiaViewModel);
        //            _chiTietBaoGiaService.Update(vienchucDb);
        //            _chiTietBaoGiaService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}


        [Route("getchitietbaogia")]
        public HttpResponseMessage getchitietbaogia(HttpRequestMessage request, string maBG)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _chiTietBaoGiaService.getchitietbaogia(maBG);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }



        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietBaoGiaViewModel> chiTietBaoGiaVM)
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
                    foreach (var item in chiTietBaoGiaVM)
                    {
                        var newThongBao = new ChiTietBaoGia();
                        newThongBao.UpdateChiTietBaoGia(item);

                        _chiTietBaoGiaService.Add(newThongBao);
                        _chiTietBaoGiaService.Save();
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


                var listCategory = _chiTietBaoGiaService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<ChiTietBaoGia>,IEnumerable<ChiTietBaoGiaViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaChiTietBaoGia.Length + x.MaChiTietBaoGia);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

       [Route("getbyid")]
       [HttpGet]
        public HttpResponseMessage getbyid(HttpRequestMessage request,string id)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _chiTietBaoGiaService.getbyid(id);
                //  var responseData = Mapper.Map<IEnumerable<ChiTietBaoGia>,IEnumerable<ChiTietBaoGiaViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaChiTietBaoGia.Length + x.MaChiTietBaoGia);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

      



        public HttpResponseMessage Post(HttpRequestMessage request, ChiTietBaoGia chiTietBaoGia)
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
                    _chiTietBaoGiaService.Add(chiTietBaoGia);
                    _chiTietBaoGiaService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, ChiTietBaoGia chiTietBaoGia)
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
                    _chiTietBaoGiaService.Update(chiTietBaoGia);
                    _chiTietBaoGiaService.Commit();

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
                    _chiTietBaoGiaService.delete(id);
                    _chiTietBaoGiaService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

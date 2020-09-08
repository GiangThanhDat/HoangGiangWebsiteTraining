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
    [RoutePrefix("api/quetthetheongay")]
   
    public class QuetTheTheoNgayController : ApiControllerBase
    {
        IQuetTheTheoNgayService _quetTheTheoNgayService;

        public QuetTheTheoNgayController(ILoiService loiService, IQuetTheTheoNgayService quetTheTheoNgayService) : base(loiService)
        {
            this._quetTheTheoNgayService = quetTheTheoNgayService;
        }


        [Route("createExcel")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<QuetTheTheoNgayViewModel> quetTheTheoNgayVM)
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
                    foreach (var item in quetTheTheoNgayVM)
                    {
                        var newThongBao = new QuetTheTheoNgay();
                        newThongBao.UpdateQuetTheTheoNgay(item);

                        _quetTheTheoNgayService.Add(newThongBao);
                        _quetTheTheoNgayService.Save();
                    }


                    //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }
        public HttpResponseMessage Create(HttpRequestMessage request, QuetTheTheoNgay quetTheTheoNgay)
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
                    _quetTheTheoNgayService.Add(quetTheTheoNgay);
                    _quetTheTheoNgayService.Commit();
                    response = request.CreateResponse(HttpStatusCode.Created, quetTheTheoNgay);
                }
                return response;
            });

        }
		 
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _quetTheTheoNgayService.GetAll();

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("checkvangmat")]
        [HttpGet]
        public HttpResponseMessage checkvangmat(HttpRequestMessage request,string id)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _quetTheTheoNgayService.GetByMaNV(id);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

        public HttpResponseMessage Post(HttpRequestMessage request, QuetTheTheoNgay quetTheTheoNgay)
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
                    _quetTheTheoNgayService.Add(quetTheTheoNgay);
                    _quetTheTheoNgayService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, QuetTheTheoNgay quetTheTheoNgay)
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
                    _quetTheTheoNgayService.Update(quetTheTheoNgay);
                    _quetTheTheoNgayService.Commit();

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
                    _quetTheTheoNgayService.delete(id);
                    _quetTheTheoNgayService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

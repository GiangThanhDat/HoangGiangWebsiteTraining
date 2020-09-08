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
    [RoutePrefix("api/quanlyquagio")]
    [Authorize]
    public class QuanLyQuaGioController : ApiControllerBase
    {
        IQuanLyQuaGioService _quanLyQuaGioService;

        public QuanLyQuaGioController(ILoiService loiService, IQuanLyQuaGioService quanLyQuaGioService) : base(loiService)
        {
            this._quanLyQuaGioService = quanLyQuaGioService;
        }
        [Route("createExcel")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<QuanLyQuaGioViewModel> quanLyQuaGioVM)
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
                    foreach (var item in quanLyQuaGioVM)
                    {
                        var newThongBao = new QuanLyQuaGio();
                        newThongBao.UpdateQuanLyQuaGio(item);

                        _quanLyQuaGioService.Add(newThongBao);
                        _quanLyQuaGioService.Save();
                    }


                    //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }



        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage update(HttpRequestMessage request, QuanLyQuaGioViewModel quanLyQuaGioViewModel)

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

                    var vienchucDb = _quanLyQuaGioService.getID(Convert.ToInt32(quanLyQuaGioViewModel.ID));

                    vienchucDb.UpdateQuanLyQuaGio(quanLyQuaGioViewModel);
                    _quanLyQuaGioService.Update(vienchucDb);
                    _quanLyQuaGioService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
        public HttpResponseMessage Create(HttpRequestMessage request, QuanLyQuaGio quanLyQuaGio)
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
                    _quanLyQuaGioService.Add(quanLyQuaGio);
                    _quanLyQuaGioService.Commit();
                    response = request.CreateResponse(HttpStatusCode.Created, quanLyQuaGio);
                }
                return response;
            });

        }
		 
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _quanLyQuaGioService.GetAll();

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

        [Route("GetQuanLyQuaGio")]
        public HttpResponseMessage GetQuanLyQuaGio(HttpRequestMessage request, string msnv)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _quanLyQuaGioService.GetQuanLyQuaGio(msnv);
                var responseData = Mapper.Map<IEnumerable<QuanLyQuaGio>, IEnumerable<QuanLyQuaGio>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }


        public HttpResponseMessage Post(HttpRequestMessage request, QuanLyQuaGio quanLyQuaGio)
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
                    _quanLyQuaGioService.Add(quanLyQuaGio);
                    _quanLyQuaGioService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, QuanLyQuaGio quanLyQuaGio)
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
                    _quanLyQuaGioService.Update(quanLyQuaGio);
                    _quanLyQuaGioService.Commit();

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
                    _quanLyQuaGioService.delete(id);
                    _quanLyQuaGioService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

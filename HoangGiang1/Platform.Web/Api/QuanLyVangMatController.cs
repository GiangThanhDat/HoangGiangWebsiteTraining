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
    [RoutePrefix("api/quanlyvangmat")]
    //[Authorize]
    public class QuanLyVangMatController : ApiControllerBase
    {
        IQuanLyVangMatService _quanLyVangMatService;

        public QuanLyVangMatController(ILoiService loiService, IQuanLyVangMatService quanLyVangMatService) : base(loiService)
        {
            this._quanLyVangMatService = quanLyVangMatService;
        }
        [Route("create")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<QuanLyVangMatViewModel> quanLyVangMatVM)
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
                    foreach (var item in quanLyVangMatVM)
                    {
                        var newThongBao = new QuanLyVangMat();
                        item.NgayVangMat = DateTime.Now;

                        newThongBao.UpdateQuanLyVangMat(item);

                        _quanLyVangMatService.Add(newThongBao);
                        _quanLyVangMatService.Save();
                    }


                    //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }
        public HttpResponseMessage Create(HttpRequestMessage request, QuanLyVangMat quanLyVangMat)
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
                    _quanLyVangMatService.Add(quanLyVangMat);
                    _quanLyVangMatService.Commit();
                    response = request.CreateResponse(HttpStatusCode.Created, quanLyVangMat);
                }
                return response;
            });

        }
        [Route("GetquanLyVangMat")]
        [HttpGet]
        public HttpResponseMessage GetquanLyVangMat(HttpRequestMessage request, string msnv)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _quanLyVangMatService.quanLyVangMat(msnv);
                var responseData = Mapper.Map<IEnumerable<QuanLyVangMat>, IEnumerable<QuanLyVangMat>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _quanLyVangMatService.getall();

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("xemtheongay")]
        [HttpGet]
        public HttpResponseMessage xemtheongay(HttpRequestMessage request, DateTime ngay)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _quanLyVangMatService.xemtheongay(ngay);
                //var listHocPhiVm = Mapper.Map<List<QuanLyVangMatViewModel>>(listCategory);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("xemtheomsnv")]
        [HttpGet]
        public HttpResponseMessage xemtheomsnv(HttpRequestMessage request, string msnv)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _quanLyVangMatService.xemtheomsnv(msnv);
                //var listHocPhiVm = Mapper.Map<QuanLyVangMatViewModel>(listCategory);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("xemtheotennv")]
        [HttpGet]
        public HttpResponseMessage xemtheotennv(HttpRequestMessage request, string tennv)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _quanLyVangMatService.xemtheotennv(tennv);
                //var listHocPhiVm = Mapper.Map<QuanLyVangMatViewModel>(listCategory);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        public HttpResponseMessage Post(HttpRequestMessage request, QuanLyVangMat quanLyVangMat)
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
                    _quanLyVangMatService.Add(quanLyVangMat);
                    _quanLyVangMatService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, QuanLyVangMat quanLyVangMat)
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
                    _quanLyVangMatService.Update(quanLyVangMat);
                    _quanLyVangMatService.Commit();

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
                    _quanLyVangMatService.delete(id);
                    _quanLyVangMatService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

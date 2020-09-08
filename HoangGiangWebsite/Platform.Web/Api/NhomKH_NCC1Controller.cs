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
    [RoutePrefix("api/nhomkh_ncc")]
    [Authorize]
    public class NhomKH_NCC1Controller : ApiControllerBase
    {
        INhomKH_NCC1Service _nhomKH_NCC1Service;

        public NhomKH_NCC1Controller(ILoiService loiService, INhomKH_NCC1Service nhomKH_NCC1Service) : base(loiService)
        {
            this._nhomKH_NCC1Service = nhomKH_NCC1Service;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<NhomKH_NCC1ViewModel> nhomKH_NCC1VM)
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
        //            foreach (var item in nhomKH_NCC1VM)
        //            {
        //                var newThongBao = new NhomKH_NCC1();
        //                newThongBao.UpdateNhomKH_NCC1(item);

        //                _nhomKH_NCC1Service.Add(newThongBao);
        //                _nhomKH_NCC1Service.Save();
        //            }


        //            //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
        //            response = request.CreateResponse(HttpStatusCode.OK);
        //        }

        //        return response;
        //    });
        //}
        public HttpResponseMessage Create(HttpRequestMessage request, NhomKH_NCC1 nhomKH_NCC1)
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
                    _nhomKH_NCC1Service.Add(nhomKH_NCC1);
                    _nhomKH_NCC1Service.Commit();
                    response = request.CreateResponse(HttpStatusCode.Created, nhomKH_NCC1);
                }
                return response;
            });

        }

        [Route("delete")]
        [HttpDelete]
        [HttpGet]
        // [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, string ID)
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
                    var oldProductCategory = _nhomKH_NCC1Service.DELETE(int.Parse(ID));
                    _nhomKH_NCC1Service.Save();

                    var responseData = Mapper.Map<NhomKH_NCC1, NhomKH_NCC1ViewModel>(oldProductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _nhomKH_NCC1Service.GetAll();

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
       
        [Route("getbyid")]
        public HttpResponseMessage GetById(HttpRequestMessage request,string id)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _nhomKH_NCC1Service.GetByID(id);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("getbykeyword")]
        [HttpGet]
        public HttpResponseMessage getbykeyword(HttpRequestMessage request, string keyword)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _nhomKH_NCC1Service.GetByKeyWord(keyword);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        public HttpResponseMessage Post(HttpRequestMessage request, NhomKH_NCC1 nhomKH_NCC1)
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
                    _nhomKH_NCC1Service.Add(nhomKH_NCC1);
                    _nhomKH_NCC1Service.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage update(HttpRequestMessage request, NhomKH_NCC1ViewModel nhomKH_NCC1VM)
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

                    var vienchucDb = _nhomKH_NCC1Service.GetByID(nhomKH_NCC1VM.NhomKH_NCC);

                    vienchucDb.UpdateNhomKH_NCC1(nhomKH_NCC1VM);
                    _nhomKH_NCC1Service.Update(vienchucDb);
                    _nhomKH_NCC1Service.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }


        [Route("create")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, NhomKH_NCC1ViewModel khachHang)
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
                    var newThongBao = new NhomKH_NCC1();
                    newThongBao.UpdateNhomKH_NCC1(khachHang);

                    _nhomKH_NCC1Service.Add(newThongBao);
                    _nhomKH_NCC1Service.Save();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });

        }
        public HttpResponseMessage Put(HttpRequestMessage request, NhomKH_NCC1 nhomKH_NCC1)
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
                    _nhomKH_NCC1Service.Update(nhomKH_NCC1);
                    _nhomKH_NCC1Service.Commit();

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
                    _nhomKH_NCC1Service.delete(id);
                    _nhomKH_NCC1Service.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

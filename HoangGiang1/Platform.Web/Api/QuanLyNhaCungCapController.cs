
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
    [RoutePrefix("api/nhacungcap")]
    [Authorize]
    public class QuanLyNhaCungCapController : ApiControllerBase
    {
        IQuanLyNhaCungCapService _quanLyNhaCungCapService;

        public QuanLyNhaCungCapController(ILoiService loiService, IQuanLyNhaCungCapService quanLyNhaCungCapService) : base(loiService)
        {
            this._quanLyNhaCungCapService = quanLyNhaCungCapService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<QuanLyQuaGioViewModel> quanLyQuaGioVM)
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
        //            foreach (var item in quanLyQuaGioVM)
        //            {
        //                var newThongBao = new QuanLyQuaGio();
        //                newThongBao.UpdateQuanLyQuaGio(item);

        //                _quanLyNhaCungCapService.Add(newThongBao);
        //                _quanLyNhaCungCapService.Save();
        //            }


        //            //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
        //            response = request.CreateResponse(HttpStatusCode.OK);
        //        }

        //        return response;
        //    });
        //}



        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage update(HttpRequestMessage request, NhaCungCapViewModel nhaCungCapViewModel)

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

                    var vienchucDb = _quanLyNhaCungCapService.getThongTinNhaCungCap(nhaCungCapViewModel.MaNhaCungCap);

                    vienchucDb.UpdateNhaCungCap(nhaCungCapViewModel);
                    _quanLyNhaCungCapService.Update(vienchucDb);
                    _quanLyNhaCungCapService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
        public HttpResponseMessage Create(HttpRequestMessage request, NhaCungCap nhaCungCap)
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
                    _quanLyNhaCungCapService.Add(nhaCungCap);
                    _quanLyNhaCungCapService.Commit();
                    response = request.CreateResponse(HttpStatusCode.Created, nhaCungCap);
                }
                return response;
            });

        }
        [Route("create")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage CreateVienChuc(HttpRequestMessage request, NhaCungCapViewModel nhaCungCapViewModel)
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

                    var newPhongHoc = new NhaCungCap();
                    newPhongHoc.UpdateNhaCungCap(nhaCungCapViewModel);
                   

                    _quanLyNhaCungCapService.Add(newPhongHoc);
                    _quanLyNhaCungCapService.Save();




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


                var listCategory = _quanLyNhaCungCapService.GetAll();
                var a = listCategory.OrderBy(x => x.MaNhaCungCap);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, a);


                return response;
            });
        }
        [Route("search")]
        [HttpGet]
        public HttpResponseMessage search(HttpRequestMessage request,string name)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _quanLyNhaCungCapService.search(name);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

        [Route("getThongTinNhaCungCap")]
        public HttpResponseMessage GetQuanLyQuaGio(HttpRequestMessage request, string name)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _quanLyNhaCungCapService.getThongTinNhaCungCap(name);
                var responseData = Mapper.Map<NhaCungCap, NhaCungCap>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }


        public HttpResponseMessage Post(HttpRequestMessage request, NhaCungCap nhaCungCap)
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
                    _quanLyNhaCungCapService.Add(nhaCungCap);
                    _quanLyNhaCungCapService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, NhaCungCap nhaCungCap)
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
                    _quanLyNhaCungCapService.Update(nhaCungCap);
                    _quanLyNhaCungCapService.Commit();

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
                    _quanLyNhaCungCapService.delete(id);
                    _quanLyNhaCungCapService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

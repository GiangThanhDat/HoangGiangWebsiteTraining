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
    [RoutePrefix("api/lichsulamviec")]
    [Authorize]
    public class LichSuLamViecController : ApiControllerBase
    {
        ILichSuLamViecService _lichSuLamViecService;

        public LichSuLamViecController(ILoiService loiService, ILichSuLamViecService lichSuLamViecService) : base(loiService)
        {
            this._lichSuLamViecService = lichSuLamViecService;
        }
        [Route("createExcel")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<LichSuLamViecViewModel> lichSuLamViecVM)
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
                    foreach (var item in lichSuLamViecVM)
                    {
                        var newThongBao = new LichSuLamViec();
                        newThongBao.UpdateLichSuLamViec(item);

                        _lichSuLamViecService.Add(newThongBao);
                        _lichSuLamViecService.Save();
                    }


                    //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }
        public HttpResponseMessage Create(HttpRequestMessage request, LichSuLamViec lichSuLamViec)
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
                    _lichSuLamViecService.Add(lichSuLamViec);
                    _lichSuLamViecService.Commit();
                    response = request.CreateResponse(HttpStatusCode.Created, lichSuLamViec);
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
                    var oldProductCategory = _lichSuLamViecService.DELETE(int.Parse(ID));
                    _lichSuLamViecService.Save();

                    var responseData = Mapper.Map<LichSuLamViec, LichSuLamViecViewModel>(oldProductCategory);
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


                var listCategory = _lichSuLamViecService.GetAll();

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("GetLichSuLamViec")]
        public HttpResponseMessage GetLichSuLamViec(HttpRequestMessage request, string msnv)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _lichSuLamViecService.GetLichSuLamViec(msnv);
                var responseData = Mapper.Map<IEnumerable<LichSuLamViec>, IEnumerable<LichSuLamViec>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        public HttpResponseMessage Post(HttpRequestMessage request, LichSuLamViec lichSuLamViec)
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
                    _lichSuLamViecService.Add(lichSuLamViec);
                    _lichSuLamViecService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage update(HttpRequestMessage request, LichSuLamViecViewModel lichSuLamViecVM)
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

                    var vienchucDb = _lichSuLamViecService.getID(Convert.ToInt32(lichSuLamViecVM.ID));

                    vienchucDb.UpdateLichSuLamViec(lichSuLamViecVM);
                    _lichSuLamViecService.Update(vienchucDb);
                    _lichSuLamViecService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }


        [Route("create")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage Creates(HttpRequestMessage request, IEnumerable<LichSuLamViecViewModel> lichSuLamViecViewModels)
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
                    var b = "";
                    foreach (var item in lichSuLamViecViewModels)
                    {
                        if (item.MaSoNhanVien != null)
                        {
                            b = item.MaSoNhanVien;
                        }
                        var newquaTrinhDaoTao = new LichSuLamViec();
                        newquaTrinhDaoTao.UpdateLichSuLamViec(item);
                        newquaTrinhDaoTao.MaSoNhanVien = b;

                        _lichSuLamViecService.Add(newquaTrinhDaoTao);
                        _lichSuLamViecService.Save();
                    }



                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }
        public HttpResponseMessage Put(HttpRequestMessage request, LichSuLamViec lichSuLamViec)
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
                    _lichSuLamViecService.Update(lichSuLamViec);
                    _lichSuLamViecService.Commit();

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
                    _lichSuLamViecService.delete(id);
                    _lichSuLamViecService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

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
    [RoutePrefix("api/hoanthanhcongviec")]
    [Authorize]
    public class HoanThanhCongViecController : ApiControllerBase
    {
        IHoanThanhCongViecService _hoanThanhCongViecService;

        public HoanThanhCongViecController(ILoiService loiService, IHoanThanhCongViecService hoanThanhCongViecService) : base(loiService)
        {
            this._hoanThanhCongViecService = hoanThanhCongViecService;
        }
        [Route("createExcel")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<HoanThanhCongViecViewModel> HoanThanhCongViecVm)
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
                    foreach (var item in HoanThanhCongViecVm)
                    {
                        var newThongBao = new HoanThanhCongViec();
                        newThongBao.UpdateHoanThanhCongViec(item);

                        _hoanThanhCongViecService.Add(newThongBao);
                        _hoanThanhCongViecService.Save();
                    }


                    //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }
        public HttpResponseMessage Create(HttpRequestMessage request, HoanThanhCongViec hoanThanhCong)
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
                    _hoanThanhCongViecService.Add(hoanThanhCong);
                    _hoanThanhCongViecService.Commit();
                    response = request.CreateResponse(HttpStatusCode.Created, hoanThanhCong);
                }
                return response;
            });

        }
		
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _hoanThanhCongViecService.GetAll();

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }



        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage update(HttpRequestMessage request, HoanThanhCongViecViewModel hoanThanhCongViecVM)
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

                    var vienchucDb = _hoanThanhCongViecService.getID(Convert.ToInt32( hoanThanhCongViecVM.ID));

                    vienchucDb.UpdateHoanThanhCongViec(hoanThanhCongViecVM);
                    _hoanThanhCongViecService.Update(vienchucDb);
                    _hoanThanhCongViecService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }



        [Route("GetHoanThanhCongViec")]
        public HttpResponseMessage GetHoanThanhCongViec(HttpRequestMessage request, string msnv)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _hoanThanhCongViecService.GetHoanThanhCongViec(msnv);
                var responseData = Mapper.Map<IEnumerable<HoanThanhCongViec>, IEnumerable<HoanThanhCongViec>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        public HttpResponseMessage Post(HttpRequestMessage request, HoanThanhCongViec hoanThanhCongViec)
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
                    _hoanThanhCongViecService.Add(hoanThanhCongViec);
                    _hoanThanhCongViecService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, HoanThanhCongViec hoanThanhCongViec)
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
                    _hoanThanhCongViecService.Update(hoanThanhCongViec);
                    _hoanThanhCongViecService.Commit();

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
                    _hoanThanhCongViecService.delete(id);
                    _hoanThanhCongViecService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

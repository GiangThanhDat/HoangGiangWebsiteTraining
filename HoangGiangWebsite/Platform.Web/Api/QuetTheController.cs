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
    [RoutePrefix("api/quetthe")]
   
    public class QuetTheController : ApiControllerBase
    {
        IQuetTheService _quetTheService;

        public QuetTheController(ILoiService loiService, IQuetTheService quetTheService) : base(loiService)
        {
            this._quetTheService = quetTheService;
        }
        [Route("create")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<QuetTheViewModel> quetTheVM)
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
                    foreach (var item in quetTheVM)
                    {
                        var newThongBao = new QuetThe();
                        newThongBao.UpdateQuetThe(item);

                        _quetTheService.Add(newThongBao);
                        _quetTheService.Save();
                    }


                    //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }
        public HttpResponseMessage Create(HttpRequestMessage request, QuetThe quetThe)
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
                    _quetTheService.Add(quetThe);
                    _quetTheService.Commit();
                    response = request.CreateResponse(HttpStatusCode.Created, quetThe);
                }
                return response;
            });

        }
		 
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _quetTheService.GetAll();

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

		
        public HttpResponseMessage Post(HttpRequestMessage request, QuetThe quetThe)
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
                    _quetTheService.Add(quetThe);
                    _quetTheService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, QuetThe quetThe)
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
                    _quetTheService.Update(quetThe);
                    _quetTheService.Commit();

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
                    _quetTheService.delete(id);
                    _quetTheService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

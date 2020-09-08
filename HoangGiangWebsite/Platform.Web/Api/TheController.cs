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
    [RoutePrefix("api/the")]
    [Authorize]
    public class TheController : ApiControllerBase
    {
        ITheService _theService;

        public TheController(ILoiService loiService, ITheService theService) : base(loiService)
        {
            this._theService = theService;
        }
        [Route("createExcel")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<TheViewModel> theVM)
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
                    foreach (var item in theVM)
                    {
                        var newThongBao = new The();
                        newThongBao.UpdateThe(item);

                        _theService.Add(newThongBao);
                        _theService.Save();
                    }


                    //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }
        [Route("search")]
        [HttpGet]
        public HttpResponseMessage search(HttpRequestMessage request, string name)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _theService.searchs(name);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }


         [Route("gettennhanvienthe")]
        [HttpGet]
        public HttpResponseMessage gettennhanvienthe(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _theService.gettennhanvienthe();

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }


        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage update(HttpRequestMessage request, IEnumerable<TheViewModel> theViewModel)

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
                    foreach (var item in theViewModel)
                    {

                        var vienchucDb = _theService.getID(Convert.ToInt32(item.ID));

                        vienchucDb.UpdateThe(item);
                        _theService.Update(vienchucDb);
                        _theService.Commit();
                    }
                    response = request.CreateResponse(HttpStatusCode.OK);

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
                    var oldProductCategory = _theService.DELETE(int.Parse(ID));
                    _theService.Save();

                    var responseData = Mapper.Map<The, TheViewModel>(oldProductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }





        public HttpResponseMessage Create(HttpRequestMessage request, The the)
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
                    _theService.Add(the);
                    _theService.Commit();
                    response = request.CreateResponse(HttpStatusCode.Created, the);
                }
                return response;
            });

        }
		 
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _theService.GetAll();

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }


        [Route("Getthe")]
        [HttpGet]
        public HttpResponseMessage Getthe(HttpRequestMessage request, string msnv)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _theService.the(msnv);
             
                var response = request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            });
        }

        public HttpResponseMessage Post(HttpRequestMessage request, The the)
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
                    _theService.Add(the);
                    _theService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, The the)
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
                    _theService.Update(the);
                    _theService.Commit();

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
                    _theService.delete(id);
                    _theService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

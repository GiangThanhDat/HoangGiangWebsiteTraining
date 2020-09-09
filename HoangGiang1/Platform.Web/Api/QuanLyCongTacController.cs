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
    [RoutePrefix("api/quanlycongtac")]
    [Authorize]
    public class QuanLyCongTacController : ApiControllerBase
    {
        IQuanLyCongTacService _quanLyCongTacService;

        public QuanLyCongTacController (ILoiService loiService, IQuanLyCongTacService quanLyCongTacService) : base(loiService)
        {
            this._quanLyCongTacService = quanLyCongTacService;
        }
        [Route("createExcel")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<QuanLyCongTacViewModel> quanLyCongTacVM)
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
                    foreach (var item in quanLyCongTacVM)
                    {
                        var newThongBao = new QuanLyCongTac();
                        newThongBao.UpdateQuanLyCongTac(item);

                        _quanLyCongTacService.Add(newThongBao);
                        _quanLyCongTacService.Save();
                    }


                    //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }

        [Route("xemtheongay")]
        [HttpGet]
  
        public HttpResponseMessage xemtheongay(HttpRequestMessage request, DateTime ngay)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _quanLyCongTacService.xemtheongay(ngay);
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


                var listCategory = _quanLyCongTacService.xemtheomsnv(msnv);
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


                var listCategory = _quanLyCongTacService.xemtheotennv(tennv);
                //var listHocPhiVm = Mapper.Map<QuanLyVangMatViewModel>(listCategory);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _quanLyCongTacService.getall();

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage update(HttpRequestMessage request, QuanLyCongTacViewModel quanLyCongTacViewModel)

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

                    var vienchucDb = _quanLyCongTacService.getID(Convert.ToInt32(quanLyCongTacViewModel.ID));

                    vienchucDb.UpdateQuanLyCongTac(quanLyCongTacViewModel);
                    _quanLyCongTacService.Update(vienchucDb);
                    _quanLyCongTacService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
        public HttpResponseMessage Create(HttpRequestMessage request, QuanLyCongTac quanLyCongTac)
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
                    _quanLyCongTacService.Add(quanLyCongTac);
                    _quanLyCongTacService.Commit();
                    response = request.CreateResponse(HttpStatusCode.Created, quanLyCongTac);
                }
                return response;
            });

        }
		

        //[Route("getall")]
        //public HttpResponseMessage Getall(HttpRequestMessage request)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {


        //        var listCategory = _quanLyCongTacService.GetAll();

        //        HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


        //        return response;
        //    });
        //}

        [Route("GetquanLyCongTac")]
        public HttpResponseMessage GetquanLyCongTac(HttpRequestMessage request, string msnv)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _quanLyCongTacService.quanLyCongTac(msnv);
                var responseData = Mapper.Map<IEnumerable<QuanLyCongTac>, IEnumerable<QuanLyCongTac>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }


        public HttpResponseMessage Post(HttpRequestMessage request, QuanLyCongTac quanLyCongTac)
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
                    _quanLyCongTacService.Add(quanLyCongTac);
                    _quanLyCongTacService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }


        [Route("create")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, QuanLyCongTacViewModel quanLyCongTacViewModel)
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

                    var newPhongHoc = new QuanLyCongTac();
                    newPhongHoc.UpdateQuanLyCongTac(quanLyCongTacViewModel);

                    _quanLyCongTacService.Add(newPhongHoc);
                    _quanLyCongTacService.Save();




                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }
        public HttpResponseMessage Put(HttpRequestMessage request, QuanLyCongTac quanLyCongTac)
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
                    _quanLyCongTacService.Update(quanLyCongTac);
                    _quanLyCongTacService.Commit();

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
                    _quanLyCongTacService.delete(id);
                    _quanLyCongTacService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

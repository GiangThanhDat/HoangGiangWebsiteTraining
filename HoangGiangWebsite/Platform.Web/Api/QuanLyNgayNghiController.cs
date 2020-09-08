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
    [RoutePrefix("api/quanlyngaynghi")]
    [Authorize]
    public class QuanLyNgayNghiController : ApiControllerBase
    {
        IQuanLyNgayNghiService _quanLyNgayNghiService;

        public QuanLyNgayNghiController(ILoiService loiService, IQuanLyNgayNghiService quanLyNgayNghiService) : base(loiService)
        {
            this._quanLyNgayNghiService = quanLyNgayNghiService;
        }
        [Route("createExcel")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<QuanLyNgayNghiViewModel> quanLyNgayNghiVM)
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
                    foreach (var item in quanLyNgayNghiVM)
                    {
                        var newThongBao = new QuanLyNgayNghi();
                        newThongBao.UpdateQuanLyNgayNghi(item);

                        _quanLyNgayNghiService.Add(newThongBao);
                        _quanLyNgayNghiService.Save();
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


                var listCategory = _quanLyNgayNghiService.xemtheongay(ngay);
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


                var listCategory = _quanLyNgayNghiService.xemtheomsnv(msnv);
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


                var listCategory = _quanLyNgayNghiService.xemtheotennv(tennv);
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


                var listCategory = _quanLyNgayNghiService.getall();

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage update(HttpRequestMessage request, QuanLyNgayNghiViewModel quanLyNgayNghiViewModel)

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

                    var vienchucDb = _quanLyNgayNghiService.getID(Convert.ToInt32(quanLyNgayNghiViewModel.ID));

                    vienchucDb.UpdateQuanLyNgayNghi(quanLyNgayNghiViewModel);
                    _quanLyNgayNghiService.Update(vienchucDb);
                    _quanLyNgayNghiService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }


        public HttpResponseMessage Create(HttpRequestMessage request, QuanLyNgayNghi quanLyNgayNghi)
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
                    _quanLyNgayNghiService.Add(quanLyNgayNghi);
                    _quanLyNgayNghiService.Commit();
                    response = request.CreateResponse(HttpStatusCode.Created, quanLyNgayNghi);
                }
                return response;
            });

        }
		
        //[Route("getall")]
        //public HttpResponseMessage Get(HttpRequestMessage request)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {


        //        var listCategory = _quanLyNgayNghiService.GetAll();

        //        HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


        //        return response;
        //    });
        //}

        [Route("GetquanLyNgayNghi")]
        public HttpResponseMessage GetquanLyNgayNghi(HttpRequestMessage request, string msnv)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _quanLyNgayNghiService.quanLyNgayNghi(msnv);
                var responseData = Mapper.Map<IEnumerable<QuanLyNgayNghi>, IEnumerable<QuanLyNgayNghi>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }


        public HttpResponseMessage Post(HttpRequestMessage request, QuanLyNgayNghi quanLyNgayNghi)
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
                    _quanLyNgayNghiService.Add(quanLyNgayNghi);
                    _quanLyNgayNghiService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, QuanLyNgayNghi quanLyNgayNghi)
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
                    _quanLyNgayNghiService.Update(quanLyNgayNghi);
                    _quanLyNgayNghiService.Commit();

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
                    _quanLyNgayNghiService.delete(id);
                    _quanLyNgayNghiService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

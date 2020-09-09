using Platform.Model;
using Platform.Service;
using Platform.Web.infratructure.core;
using Platform.Web.infratructure.extensions;
using Platform.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Platform.Web.Api
{

    [RoutePrefix("api/quanlytaisan")]
    [Authorize]
    public class QuanLyTaiSanController : ApiControllerBase
    {
        IQuanLyTaiSanService _quanLyTaiSanService;

        public QuanLyTaiSanController(ILoiService loiService, IQuanLyTaiSanService coSoViecService) : base(loiService)
        {
            this._quanLyTaiSanService = coSoViecService;
        }
        [Route("createExcel")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<QuanLyTaiSanViewModel> quanLyTaiSanViewModels)
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
                    foreach (var item in quanLyTaiSanViewModels)
                    {
                        var newThongBao = new QuanLyTaiSan();
                        newThongBao.UpdateQuanLyTaiSan(item);

                        _quanLyTaiSanService.Add(newThongBao);
                        _quanLyTaiSanService.Save();
                    }


                    //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }
        public HttpResponseMessage Create(HttpRequestMessage request, QuanLyTaiSan quanLyTaiSan)
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
                    _quanLyTaiSanService.Add(quanLyTaiSan);
                    _quanLyTaiSanService.Commit();
                    response = request.CreateResponse(HttpStatusCode.Created, quanLyTaiSan);
                }
                return response;
            });

        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _quanLyTaiSanService.GetAll();

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("getQuanLyTaiSanCaNhan")]
        public HttpResponseMessage getQuanLyTaiSanCaNhan(HttpRequestMessage request,string msnv)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _quanLyTaiSanService.getQuanLyTaiSanCaNhan(msnv);


                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }



        [Route("create")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage CreateVienChuc(HttpRequestMessage request, QuanLyTaiSanViewModel quanLyTaiSanViewModel)
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

                    var newPhongHoc = new QuanLyTaiSan();
                    newPhongHoc.UpdateQuanLyTaiSan(quanLyTaiSanViewModel);
                   

                    _quanLyTaiSanService.Add(newPhongHoc);
                    _quanLyTaiSanService.Save();




                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }

        public HttpResponseMessage Post(HttpRequestMessage request, QuanLyTaiSan quanLyTai)
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
                    _quanLyTaiSanService.Add(quanLyTai);
                    _quanLyTaiSanService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, QuanLyTaiSan quanLyTaiSan)
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
                    _quanLyTaiSanService.Update(quanLyTaiSan);
                    _quanLyTaiSanService.Commit();

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
                    _quanLyTaiSanService.delete(id);
                    _quanLyTaiSanService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}
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
    [RoutePrefix("api/khachhang")]
    [Authorize]
    public class KhachHangController : ApiControllerBase
    {
        IKhachHangService _khachHangService;

        public KhachHangController(ILoiService loiService, IKhachHangService khachHangService) : base(loiService)
        {
            this._khachHangService = khachHangService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<KhachHangViewModel> khachHangVM)
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
        //            foreach (var item in khachHangVM)
        //            {
        //                var newThongBao = new KhachHang();
        //                newThongBao.UpdateKhachHang(item);

        //                _khachHangService.Add(newThongBao);
        //                _khachHangService.Save();
        //            }


        //            //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
        //            response = request.CreateResponse(HttpStatusCode.OK);
        //        }

        //        return response;
        //    });
        //}
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, KhachHangViewModel khachHang)
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
                    var newThongBao = new KhachHang();
                    newThongBao.UpdateKhachHang(khachHang);

                    _khachHangService.Add(newThongBao);
                    _khachHangService.Save();
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
                    var oldProductCategory = _khachHangService.DELETE(int.Parse(ID));
                    _khachHangService.Save();

                    var responseData = Mapper.Map<KhachHang, KhachHangViewModel>(oldProductCategory);
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


                var listCategory = _khachHangService.GetAll();
                var b = listCategory.OrderBy(x => x.MaKhachHang);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, b);


                return response;
            });
        }
        [Route("getbykeyword")]
        public HttpResponseMessage GetByKeyWord(HttpRequestMessage request,string keyword)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _khachHangService.GetByKeyWord(keyword);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("getbyid")]
        public HttpResponseMessage GetById(HttpRequestMessage request,string id)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _khachHangService.GetByID(id);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        public HttpResponseMessage Post(HttpRequestMessage request, KhachHang khachHang)
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
                    _khachHangService.Add(khachHang);
                    _khachHangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage update(HttpRequestMessage request, KhachHangViewModel khachHangVM)
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

                    var vienchucDb = _khachHangService.GetByID(khachHangVM.MaKhachHang);

                    vienchucDb.UpdateKhachHang(khachHangVM);
                    _khachHangService.Update(vienchucDb);
                    _khachHangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }


        [Route("creates")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage Creates(HttpRequestMessage request, IEnumerable<KhachHangViewModel> khachHangViewModels)
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
                    foreach (var item in khachHangViewModels)
                    {
                        
                        var newquaTrinhDaoTao = new KhachHang();
                        newquaTrinhDaoTao.UpdateKhachHang(item);

                        _khachHangService.Add(newquaTrinhDaoTao);
                        _khachHangService.Save();
                    }



                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }
        public HttpResponseMessage Put(HttpRequestMessage request, KhachHang khachHang)
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
                    _khachHangService.Update(khachHang);
                    _khachHangService.Commit();

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
                    _khachHangService.delete(id);
                    _khachHangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

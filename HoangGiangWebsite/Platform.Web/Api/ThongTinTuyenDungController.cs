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
    [RoutePrefix("api/thongtintuyendung")]
    [Authorize]
    public class ThongTinTuyenDungController : ApiControllerBase
    {
        IThongTinTuyenDungService _thongTinTuyenDungService;

        public ThongTinTuyenDungController(ILoiService loiService, IThongTinTuyenDungService  thongTinTuyenDungService) : base(loiService)
        {
            this. _thongTinTuyenDungService =  thongTinTuyenDungService;
        }
        [Route("createExcel")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ThongTinTuyenDungViewModel> thongTinTuyenDungVM)
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
                    foreach (var item in thongTinTuyenDungVM)
                    {
                        var newThongBao = new ThongTinTuyenDung();
                        newThongBao.UpdateThongTinTuyenDung(item);

                         _thongTinTuyenDungService.Add(newThongBao);
                         _thongTinTuyenDungService.Save();
                    }


                    //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }
        [Route("create")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage Creates(HttpRequestMessage request, IEnumerable<ThongTinTuyenDungViewModel> quaTrinhDaoTaoVM)
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
                    foreach (var item in quaTrinhDaoTaoVM)
                    {
                        if (item.MaSoNhanVien != null)
                        {
                            b = item.MaSoNhanVien;
                        }
                        var newquaTrinhDaoTao = new ThongTinTuyenDung();
                        newquaTrinhDaoTao.UpdateThongTinTuyenDung(item);
                        newquaTrinhDaoTao.MaSoNhanVien = b;

                        _thongTinTuyenDungService.Add(newquaTrinhDaoTao);
                        _thongTinTuyenDungService.Save();
                    }



                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }



        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage update(HttpRequestMessage request, ThongTinTuyenDungViewModel thongTinTuyenDungViewModel)

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

                    var vienchucDb = _thongTinTuyenDungService.getID(Convert.ToInt32(thongTinTuyenDungViewModel.ID));

                    vienchucDb.UpdateThongTinTuyenDung(thongTinTuyenDungViewModel);
                    _thongTinTuyenDungService.Update(vienchucDb);
                    _thongTinTuyenDungService.Commit();

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


                var listCategory =  _thongTinTuyenDungService.GetAll();

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("GetthongTinTuyenDung")]
        public HttpResponseMessage GetthongTinTuyenDung(HttpRequestMessage request, string msnv)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _thongTinTuyenDungService.thongTinTuyenDung(msnv);
                var responseData = Mapper.Map<IEnumerable<ThongTinTuyenDung>, IEnumerable<ThongTinTuyenDung>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }


        public HttpResponseMessage Post(HttpRequestMessage request, ThongTinTuyenDung thongTinTuyenDung)
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
                     _thongTinTuyenDungService.Add(thongTinTuyenDung);
                     _thongTinTuyenDungService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, ThongTinTuyenDung thongTinTuyenDung)
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
                     _thongTinTuyenDungService.Update(thongTinTuyenDung);
                     _thongTinTuyenDungService.Commit();

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
                     _thongTinTuyenDungService.delete(id);
                     _thongTinTuyenDungService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

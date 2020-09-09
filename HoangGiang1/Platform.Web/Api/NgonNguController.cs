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
    [RoutePrefix("api/ngonngu")]
    [Authorize]
    public class NgonNguController : ApiControllerBase
    {
        INgonNguService _ngonNguService;

        public NgonNguController(ILoiService loiService, INgonNguService ngonNguService) : base(loiService)
        {
            this._ngonNguService = ngonNguService;
        }
        [Route("createExcel")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<NgonNguViewModel> ngonNguVM)
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
                    foreach (var item in ngonNguVM)
                    {
                        var newThongBao = new NgonNgu();
                        newThongBao.UpdateNgonNgu(item);

                        _ngonNguService.Add(newThongBao);
                        _ngonNguService.Save();
                    }


                    //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
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
                    var oldProductCategory = _ngonNguService.DELETE(int.Parse(ID));
                    _ngonNguService.Save();

                    var responseData = Mapper.Map<NgonNgu, NgonNguViewModel>(oldProductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        //[Route("create")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, NgonNguViewModel ngonNguViewModel)
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

        //            var newPhongHoc = new NgonNgu();
        //            newPhongHoc.UpdateNgonNgu(ngonNguViewModel);

        //            _ngonNguService.Add(newPhongHoc);
        //            _ngonNguService.Save();




        //            response = request.CreateResponse(HttpStatusCode.OK);
        //        }

        //        return response;
        //    });
        //}

        [Route("create")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage Creates(HttpRequestMessage request, IEnumerable<NgonNguViewModel> ngonNguViewModels)
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
                    foreach (var item in ngonNguViewModels)
                    {
                        if (item.MaSoNhanVien != null)
                        {
                            b = item.MaSoNhanVien;
                        }
                        var newquaTrinhDaoTao = new NgonNgu();
                        newquaTrinhDaoTao.UpdateNgonNgu(item);
                        newquaTrinhDaoTao.MaSoNhanVien = b;

                        _ngonNguService.Add(newquaTrinhDaoTao);
                        _ngonNguService.Save();
                    }



                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage update(HttpRequestMessage request, NgonNguViewModel ngonNguViewModel)

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

                    var vienchucDb = _ngonNguService.getID(Convert.ToInt32(ngonNguViewModel.ID));

                    vienchucDb.UpdateNgonNgu(ngonNguViewModel);
                    _ngonNguService.Update(vienchucDb);
                    _ngonNguService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }


        public HttpResponseMessage Create(HttpRequestMessage request, NgonNgu ngonNgu)
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
                    _ngonNguService.Add(ngonNgu);
                    _ngonNguService.Commit();
                    response = request.CreateResponse(HttpStatusCode.Created, ngonNgu);
                }
                return response;
            });

        }
		
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _ngonNguService.GetAll();

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("GetngonNgu")]
        public HttpResponseMessage GetngonNgu(HttpRequestMessage request, string msnv)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _ngonNguService.ngonNgu(msnv);
                var responseData = Mapper.Map<IEnumerable<NgonNgu>, IEnumerable<NgonNgu>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        public HttpResponseMessage Post(HttpRequestMessage request, NgonNgu ngonNgu)
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
                    _ngonNguService.Add(ngonNgu);
                    _ngonNguService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, NgonNgu ngonNgu)
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
                    _ngonNguService.Update(ngonNgu);
                    _ngonNguService.Commit();

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
                    _ngonNguService.delete(id);
                    _ngonNguService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

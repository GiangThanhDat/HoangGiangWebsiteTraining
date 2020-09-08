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
    [RoutePrefix("api/taikhoanco")]
    [Authorize]
    public class TaiKhoanCoController : ApiControllerBase
    {
        ITaiKhoanCoService _taiKhoanCoService;

        public TaiKhoanCoController(ILoiService loiService, ITaiKhoanCoService taiKhoanCoService) : base(loiService)
        {
            this._taiKhoanCoService = taiKhoanCoService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<TaiKhoanCoViewModel> taiKhoanCoVM)
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
        //            foreach (var item in taiKhoanCoVM)
        //            {
        //                var newThongBao = new TaiKhoanCo();
        //                newThongBao.UpdateTaiKhoanCo(item);

        //                _taiKhoanCoService.Add(newThongBao);
        //                _taiKhoanCoService.Save();
        //            }


        //            //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
        //            response = request.CreateResponse(HttpStatusCode.OK);
        //        }

        //        return response;
        //    });
        //}


        //[Route("update")]
        //[HttpPut]
        //[AllowAnonymous]
        //public HttpResponseMessage update(HttpRequestMessage request, TaiKhoanCoViewModel taiKhoanCoViewModel)

        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (!ModelState.IsValid)
        //        {
        //            request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {

        //            var vienchucDb = _taiKhoanCoService.getID(Convert.ToInt32(taiKhoanCoViewModel.ID));

        //            vienchucDb.UpdateTaiKhoanCo(taiKhoanCoViewModel);
        //            _taiKhoanCoService.Update(vienchucDb);
        //            _taiKhoanCoService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        //[Route("create")]
        //[HttpPost]
        //public HttpResponseMessage Create(HttpRequestMessage request, TaiKhoanCoViewModel khachHang)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (!ModelState.IsValid)
        //        {
        //            request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            var newThongBao = new TaiKhoanCo();
        //            newThongBao.UpdateTaiKhoanCo(khachHang);

        //            _taiKhoanCoService.Add(newThongBao);
        //            _taiKhoanCoService.Save();
        //            response = request.CreateResponse(HttpStatusCode.OK);
        //        }
        //        return response;
        //    });

        //}

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _taiKhoanCoService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<TaiKhoanCo>,IEnumerable<TaiKhoanCoViewModel>>(listCategory);
                //var b = listCategory.OrderBy(x => x.MaTaiKhoanCo.Length + x.MaTaiKhoanCo);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }




        public HttpResponseMessage Post(HttpRequestMessage request, TaiKhoanCo taiKhoanCo)
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
                    _taiKhoanCoService.Add(taiKhoanCo);
                    _taiKhoanCoService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, TaiKhoanCo taiKhoanCo)
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
                    _taiKhoanCoService.Update(taiKhoanCo);
                    _taiKhoanCoService.Commit();

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
                    _taiKhoanCoService.delete(id);
                    _taiKhoanCoService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

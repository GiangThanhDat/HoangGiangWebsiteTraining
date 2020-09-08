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
    [RoutePrefix("api/taikhoanno")]
    [Authorize]
    public class TaiKhoanNoController : ApiControllerBase
    {
        ITaiKhoanNoService _taiKhoanNoService;

        public TaiKhoanNoController(ILoiService loiService, ITaiKhoanNoService taiKhoanNoService) : base(loiService)
        {
            this._taiKhoanNoService = taiKhoanNoService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<TaiKhoanNoViewModel> taiKhoanNoVM)
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
        //            foreach (var item in taiKhoanNoVM)
        //            {
        //                var newThongBao = new TaiKhoanNo();
        //                newThongBao.UpdateTaiKhoanNo(item);

        //                _taiKhoanNoService.Add(newThongBao);
        //                _taiKhoanNoService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, TaiKhoanNoViewModel taiKhoanNoViewModel)

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

        //            var vienchucDb = _taiKhoanNoService.getID(Convert.ToInt32(taiKhoanNoViewModel.ID));

        //            vienchucDb.UpdateTaiKhoanNo(taiKhoanNoViewModel);
        //            _taiKhoanNoService.Update(vienchucDb);
        //            _taiKhoanNoService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        //[Route("create")]
        //[HttpPost]
        //public HttpResponseMessage Create(HttpRequestMessage request, TaiKhoanNoViewModel khachHang)
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
        //            var newThongBao = new TaiKhoanNo();
        //            newThongBao.UpdateTaiKhoanNo(khachHang);

        //            _taiKhoanNoService.Add(newThongBao);
        //            _taiKhoanNoService.Save();
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


                var listCategory = _taiKhoanNoService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<TaiKhoanNo>,IEnumerable<TaiKhoanNoViewModel>>(listCategory);
                //var b = listCategory.OrderBy(x => x.MaTaiKhoanNo.Length + x.MaTaiKhoanNo);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }


      

        public HttpResponseMessage Post(HttpRequestMessage request, TaiKhoanNo taiKhoanNo)
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
                    _taiKhoanNoService.Add(taiKhoanNo);
                    _taiKhoanNoService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, TaiKhoanNo taiKhoanNo)
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
                    _taiKhoanNoService.Update(taiKhoanNo);
                    _taiKhoanNoService.Commit();

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
                    _taiKhoanNoService.delete(id);
                    _taiKhoanNoService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

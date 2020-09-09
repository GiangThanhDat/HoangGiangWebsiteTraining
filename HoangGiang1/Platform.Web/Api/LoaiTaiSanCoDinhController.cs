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
    [RoutePrefix("api/loaitaisancodinh")]
    [Authorize]
    public class LoaiTaiSanCoDinhController : ApiControllerBase
    {
        ILoaiTaiSanCoDinhService _loaiTaiSanCoDinhService;
       

        public LoaiTaiSanCoDinhController(ILoiService loiService, ILoaiTaiSanCoDinhService loaiTaiSanCoDinhService) : base(loiService)
        {
            this._loaiTaiSanCoDinhService = loaiTaiSanCoDinhService;
           
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<LoaiTaiSanCoDinhViewModel> loaiTaiSanCoDinhVM)
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
        //            foreach (var item in loaiTaiSanCoDinhVM)
        //            {
        //                var newThongBao = new LoaiTaiSanCoDinh();
        //                newThongBao.UpdateLoaiTaiSanCoDinh(item);

        //                _loaiTaiSanCoDinhService.Add(newThongBao);
        //                _loaiTaiSanCoDinhService.Save();
        //            }


        //            //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
        //            response = request.CreateResponse(HttpStatusCode.OK);
        //        }

        //        return response;
        //    });
        //}
       

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage update(HttpRequestMessage request, LoaiTaiSanCoDinhViewModel loaiTaiSanCoDinhViewModel)

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

                    var vienchucDb = _loaiTaiSanCoDinhService.GetByID((loaiTaiSanCoDinhViewModel.MaLoaiTSCD));

                    vienchucDb.UpdateLoaiTaiSanCoDinh(loaiTaiSanCoDinhViewModel);
                    _loaiTaiSanCoDinhService.Update(vienchucDb);
                    _loaiTaiSanCoDinhService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }







        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, LoaiTaiSanCoDinhViewModel khachHang)
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
                    var newThongBao = new LoaiTaiSanCoDinh();
                    newThongBao.UpdateLoaiTaiSanCoDinh(khachHang);

                    _loaiTaiSanCoDinhService.Add(newThongBao);
                    _loaiTaiSanCoDinhService.Save();
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


                var listCategory = _loaiTaiSanCoDinhService.GetAll();
              //  var responseData = Mapper.Map<IEnumerable<LoaiTaiSanCoDinh>,IEnumerable<LoaiTaiSanCoDinhViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
      


      

        public HttpResponseMessage Post(HttpRequestMessage request, LoaiTaiSanCoDinh loaiTaiSanCoDinh)
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
                    _loaiTaiSanCoDinhService.Add(loaiTaiSanCoDinh);
                    _loaiTaiSanCoDinhService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, LoaiTaiSanCoDinh loaiTaiSanCoDinh)
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
                    _loaiTaiSanCoDinhService.Update(loaiTaiSanCoDinh);
                    _loaiTaiSanCoDinhService.Commit();

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
                    _loaiTaiSanCoDinhService.delete(id);
                    _loaiTaiSanCoDinhService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

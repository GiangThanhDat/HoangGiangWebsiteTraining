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
    [RoutePrefix("api/thanhpham")]
    [Authorize]
    public class ThanhPhamController : ApiControllerBase
    {
        IThanhPhamService _thanhPhamService;

        public ThanhPhamController(ILoiService loiService, IThanhPhamService thanhPhamService) : base(loiService)
        {
            this._thanhPhamService = thanhPhamService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ThanhPhamViewModel> thanhPhamVM)
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
        //            foreach (var item in thanhPhamVM)
        //            {
        //                var newThongBao = new ThanhPham();
        //                newThongBao.UpdateThanhPham(item);

        //                _thanhPhamService.Add(newThongBao);
        //                _thanhPhamService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, ThanhPhamViewModel thanhPhamViewModel)

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

        //            var vienchucDb = _thanhPhamService.getID(Convert.ToInt32(thanhPhamViewModel.ID));

        //            vienchucDb.UpdateThanhPham(thanhPhamViewModel);
        //            _thanhPhamService.Update(vienchucDb);
        //            _thanhPhamService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}



        //[Route("create")]
        //[HttpPost]
        //public HttpResponseMessage Create(HttpRequestMessage request, ThanhPhamViewModel khachHang)
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
        //            var newThongBao = new ThanhPham();
        //            newThongBao.UpdateThanhPham(khachHang);

        //            _thanhPhamService.Add(newThongBao);
        //            _thanhPhamService.Save();
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


                var listCategory = _thanhPhamService.GetAll();
              //  var responseData = Mapper.Map<IEnumerable<ThanhPham>,IEnumerable<ThanhPhamViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

       




        public HttpResponseMessage Post(HttpRequestMessage request, ThanhPham thanhPham)
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
                    _thanhPhamService.Add(thanhPham);
                    _thanhPhamService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, ThanhPham thanhPham)
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
                    _thanhPhamService.Update(thanhPham);
                    _thanhPhamService.Commit();

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
                    _thanhPhamService.delete(id);
                    _thanhPhamService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

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
    [RoutePrefix("api/tinhtrang")]
    [Authorize]
    public class TinhTrangController : ApiControllerBase
    {
        ITinhTrangService _tinhTrangService;

        public TinhTrangController(ILoiService loiService, ITinhTrangService tinhTrangService) : base(loiService)
        {
            this._tinhTrangService = tinhTrangService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<TinhTrangViewModel> tinhTrangVM)
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
        //            foreach (var item in tinhTrangVM)
        //            {
        //                var newThongBao = new TinhTrang();
        //                newThongBao.UpdateTinhTrang(item);

        //                _tinhTrangService.Add(newThongBao);
        //                _tinhTrangService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, TinhTrangViewModel tinhTrangViewModel)

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

        //            var vienchucDb = _tinhTrangService.getID(Convert.ToInt32(tinhTrangViewModel.ID));

        //            vienchucDb.UpdateTinhTrang(tinhTrangViewModel);
        //            _tinhTrangService.Update(vienchucDb);
        //            _tinhTrangService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}





        //[Route("create")]
        //[HttpPost]
        //public HttpResponseMessage Create(HttpRequestMessage request, TinhTrangViewModel khachHang)
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
        //            var newThongBao = new TinhTrang();
        //            newThongBao.UpdateTinhTrang(khachHang);

        //            _tinhTrangService.Add(newThongBao);
        //            _tinhTrangService.Save();
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


                var listCategory = _tinhTrangService.GetAll();
              //  var responseData = Mapper.Map<IEnumerable<TinhTrang>,IEnumerable<TinhTrangViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }


      

        public HttpResponseMessage Post(HttpRequestMessage request, TinhTrang tinhTrang)
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
                    _tinhTrangService.Add(tinhTrang);
                    _tinhTrangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, TinhTrang tinhTrang)
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
                    _tinhTrangService.Update(tinhTrang);
                    _tinhTrangService.Commit();

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
                    _tinhTrangService.delete(id);
                    _tinhTrangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

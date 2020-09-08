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
    [RoutePrefix("api/lenhsanxuat")]
    [Authorize]
    public class LenhSanXuatController : ApiControllerBase
    {
        ILenhSanXuatService _lenhSanXuatService;

        public LenhSanXuatController(ILoiService loiService, ILenhSanXuatService lenhSanXuatService) : base(loiService)
        {
            this._lenhSanXuatService = lenhSanXuatService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<LenhSanXuatViewModel> lenhSanXuatVM)
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
        //            foreach (var item in lenhSanXuatVM)
        //            {
        //                var newThongBao = new LenhSanXuat();
        //                newThongBao.UpdateLenhSanXuat(item);

        //                _lenhSanXuatService.Add(newThongBao);
        //                _lenhSanXuatService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, LenhSanXuatViewModel lenhSanXuatViewModel)

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

        //            var vienchucDb = _lenhSanXuatService.getID(Convert.ToInt32(lenhSanXuatViewModel.ID));

        //            vienchucDb.UpdateLenhSanXuat(lenhSanXuatViewModel);
        //            _lenhSanXuatService.Update(vienchucDb);
        //            _lenhSanXuatService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}



        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, LenhSanXuatViewModel khachHang)
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
                    var newThongBao = new LenhSanXuat();
                    newThongBao.UpdateLenhSanXuat(khachHang);

                    _lenhSanXuatService.Add(newThongBao);
                    _lenhSanXuatService.Save();
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


                var listCategory = _lenhSanXuatService.GetAll();
              //  var responseData = Mapper.Map<IEnumerable<LenhSanXuat>,IEnumerable<LenhSanXuatViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
      
         [Route("getLenhSanXuat")]
        public HttpResponseMessage getLenhSanXuat(HttpRequestMessage request, DateTime ngaydau, DateTime ngaycuoi)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _lenhSanXuatService.getLenhSanXuat(ngaydau, ngaycuoi);
              //  var responseData = Mapper.Map<IEnumerable<LenhSanXuat>,IEnumerable<LenhSanXuatViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

       




        public HttpResponseMessage Post(HttpRequestMessage request, LenhSanXuat lenhSanXuat)
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
                    _lenhSanXuatService.Add(lenhSanXuat);
                    _lenhSanXuatService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, LenhSanXuat lenhSanXuat)
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
                    _lenhSanXuatService.Update(lenhSanXuat);
                    _lenhSanXuatService.Commit();

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
                    _lenhSanXuatService.delete(id);
                    _lenhSanXuatService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

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
    [RoutePrefix("api/chungtumuahang")]
    [Authorize]
    public class ChungTuMuaHangController : ApiControllerBase
    {
        IChungTuMuaHangService _chungTuMuaHangService;

        public ChungTuMuaHangController(ILoiService loiService, IChungTuMuaHangService chungTuMuaHangService) : base(loiService)
        {
            this._chungTuMuaHangService = chungTuMuaHangService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChungTuMuaHangViewModel> chungTuMuaHangVM)
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
        //            foreach (var item in chungTuMuaHangVM)
        //            {
        //                var newThongBao = new ChungTuMuaHang();
        //                newThongBao.UpdateChungTuMuaHang(item);

        //                _chungTuMuaHangService.Add(newThongBao);
        //                _chungTuMuaHangService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, ChungTuMuaHangViewModel chungTuMuaHangViewModel)

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

        //            var vienchucDb = _chungTuMuaHangService.getID(Convert.ToInt32(chungTuMuaHangViewModel.ID));

        //            vienchucDb.UpdateChungTuMuaHang(chungTuMuaHangViewModel);
        //            _chungTuMuaHangService.Update(vienchucDb);
        //            _chungTuMuaHangService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}





        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ChungTuMuaHangViewModel khachHang)
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
                    var newThongBao = new ChungTuMuaHang();
                    newThongBao.UpdateChungTuMuaHang(khachHang);

                    _chungTuMuaHangService.Add(newThongBao);
                    _chungTuMuaHangService.Save();
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


                var listCategory = _chungTuMuaHangService.GetAll();
              //  var responseData = Mapper.Map<IEnumerable<ChungTuMuaHang>,IEnumerable<ChungTuMuaHangViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }


      

        public HttpResponseMessage Post(HttpRequestMessage request, ChungTuMuaHang chungTuMuaHang)
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
                    _chungTuMuaHangService.Add(chungTuMuaHang);
                    _chungTuMuaHangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, ChungTuMuaHang chungTuMuaHang)
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
                    _chungTuMuaHangService.Update(chungTuMuaHang);
                    _chungTuMuaHangService.Commit();

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
                    _chungTuMuaHangService.delete(id);
                    _chungTuMuaHangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

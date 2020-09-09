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
    [RoutePrefix("api/chungtumuadichvu")]
    [Authorize]
    public class ChungTuMuaDichVuController : ApiControllerBase
    {
        IChungTuMuaDichVuService _chungTuMuaDichVugService;

        public ChungTuMuaDichVuController(ILoiService loiService, IChungTuMuaDichVuService chungTuMuaDichVugService) : base(loiService)
        {
            this._chungTuMuaDichVugService = chungTuMuaDichVugService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChungTuMuaDichVuViewModel> chungTuMuaDichVugVM)
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
        //            foreach (var item in chungTuMuaDichVugVM)
        //            {
        //                var newThongBao = new ChungTuMuaDichVu();
        //                newThongBao.UpdateChungTuMuaDichVu(item);

        //                _chungTuMuaDichVugService.Add(newThongBao);
        //                _chungTuMuaDichVugService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, ChungTuMuaDichVuViewModel chungTuMuaDichVugViewModel)

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

        //            var vienchucDb = _chungTuMuaDichVugService.getID(Convert.ToInt32(chungTuMuaDichVugViewModel.ID));

        //            vienchucDb.UpdateChungTuMuaDichVu(chungTuMuaDichVugViewModel);
        //            _chungTuMuaDichVugService.Update(vienchucDb);
        //            _chungTuMuaDichVugService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}





        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ChungTuMuaDichVuViewModel khachHang)
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
                    var newThongBao = new ChungTuMuaDichVu();
                    newThongBao.UpdateChungTuMuaDichVu(khachHang);

                    _chungTuMuaDichVugService.Add(newThongBao);
                    _chungTuMuaDichVugService.Save();
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


                var listCategory = _chungTuMuaDichVugService.GetAll();
              //  var responseData = Mapper.Map<IEnumerable<ChungTuMuaDichVu>,IEnumerable<ChungTuMuaDichVuViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

        [Route("getchungtumuadichvu")]
        [HttpGet]
        public HttpResponseMessage getchungtumuadichvu(HttpRequestMessage request,DateTime ngaydau,DateTime ngaycuoi)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _chungTuMuaDichVugService.getchungtumuadichvu(ngaydau,ngaycuoi);
                //  var responseData = Mapper.Map<IEnumerable<ChungTuMuaDichVu>,IEnumerable<ChungTuMuaDichVuViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }


        public HttpResponseMessage Post(HttpRequestMessage request, ChungTuMuaDichVu chungTuMuaDichVug)
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
                    _chungTuMuaDichVugService.Add(chungTuMuaDichVug);
                    _chungTuMuaDichVugService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, ChungTuMuaDichVu chungTuMuaDichVug)
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
                    _chungTuMuaDichVugService.Update(chungTuMuaDichVug);
                    _chungTuMuaDichVugService.Commit();

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
                    _chungTuMuaDichVugService.delete(id);
                    _chungTuMuaDichVugService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

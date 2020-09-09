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
    [RoutePrefix("api/tralaihangmua")]
    [Authorize]
    public class TraLaiHangMuaController : ApiControllerBase
    {
        ITraLaiHangMuaService _traLaiHangMuaService;

        public TraLaiHangMuaController(ILoiService loiService, ITraLaiHangMuaService traLaiHangMuaService) : base(loiService)
        {
            this._traLaiHangMuaService = traLaiHangMuaService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<TraLaiHangMuaViewModel> traLaiHangMuaVM)
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
        //            foreach (var item in traLaiHangMuaVM)
        //            {
        //                var newThongBao = new TraLaiHangMua();
        //                newThongBao.UpdateTraLaiHangMua(item);

        //                _traLaiHangMuaService.Add(newThongBao);
        //                _traLaiHangMuaService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, TraLaiHangMuaViewModel traLaiHangMuaViewModel)

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

        //            var vienchucDb = _traLaiHangMuaService.getID(Convert.ToInt32(traLaiHangMuaViewModel.ID));

        //            vienchucDb.UpdateTraLaiHangMua(traLaiHangMuaViewModel);
        //            _traLaiHangMuaService.Update(vienchucDb);
        //            _traLaiHangMuaService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}





        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, TraLaiHangMuaViewModel khachHang)
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
                    var newThongBao = new TraLaiHangMua();
                    newThongBao.UpdateTraLaiHangMua(khachHang);

                    _traLaiHangMuaService.Add(newThongBao);
                    _traLaiHangMuaService.Save();
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


                var listCategory = _traLaiHangMuaService.GetAll();
              //  var responseData = Mapper.Map<IEnumerable<TraLaiHangMua>,IEnumerable<TraLaiHangMuaViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
         [Route("gettralaihangmua")]
        public HttpResponseMessage gettralaihangmua(HttpRequestMessage request, DateTime ngaydau, DateTime ngaycuoi)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _traLaiHangMuaService.gettralaihangmua(ngaydau, ngaycuoi);
           

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }


      

        public HttpResponseMessage Post(HttpRequestMessage request, TraLaiHangMua traLaiHangMua)
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
                    _traLaiHangMuaService.Add(traLaiHangMua);
                    _traLaiHangMuaService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, TraLaiHangMua traLaiHangMua)
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
                    _traLaiHangMuaService.Update(traLaiHangMua);
                    _traLaiHangMuaService.Commit();

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
                    _traLaiHangMuaService.delete(id);
                    _traLaiHangMuaService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

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
    [RoutePrefix("api/tralaihangban")]
    [Authorize]
    public class TraLaiHangBanController : ApiControllerBase
    {
        ITraLaiHangBanService _traLaiHangBangService;

        public TraLaiHangBanController(ILoiService loiService, ITraLaiHangBanService traLaiHangBangService) : base(loiService)
        {
            this._traLaiHangBangService = traLaiHangBangService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<TraLaiHangBanViewModel> traLaiHangBangVM)
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
        //            foreach (var item in traLaiHangBangVM)
        //            {
        //                var newThongBao = new TraLaiHangBan();
        //                newThongBao.UpdateTraLaiHangBan(item);

        //                _traLaiHangBangService.Add(newThongBao);
        //                _traLaiHangBangService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, TraLaiHangBanViewModel traLaiHangBangViewModel)

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

        //            var vienchucDb = _traLaiHangBangService.getID(Convert.ToInt32(traLaiHangBangViewModel.ID));

        //            vienchucDb.UpdateTraLaiHangBan(traLaiHangBangViewModel);
        //            _traLaiHangBangService.Update(vienchucDb);
        //            _traLaiHangBangService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}

        [Route("gettralaihangban")]
        public HttpResponseMessage gettralaihangban(HttpRequestMessage request, DateTime ngaydau, DateTime ngaycuoi)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _traLaiHangBangService.gettralaihangban(ngaydau, ngaycuoi);
                //  var responseData = Mapper.Map<IEnumerable<TraLaiHangBan>,IEnumerable<TraLaiHangBanViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }




        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, TraLaiHangBanViewModel khachHang)
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
                    var newThongBao = new TraLaiHangBan();
                    newThongBao.UpdateTraLaiHangBan(khachHang);

                    _traLaiHangBangService.Add(newThongBao);
                    _traLaiHangBangService.Save();
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


                var listCategory = _traLaiHangBangService.GetAll();
              //  var responseData = Mapper.Map<IEnumerable<TraLaiHangBan>,IEnumerable<TraLaiHangBanViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

       




        public HttpResponseMessage Post(HttpRequestMessage request, TraLaiHangBan traLaiHangBang)
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
                    _traLaiHangBangService.Add(traLaiHangBang);
                    _traLaiHangBangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, TraLaiHangBan traLaiHangBang)
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
                    _traLaiHangBangService.Update(traLaiHangBang);
                    _traLaiHangBangService.Commit();

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
                    _traLaiHangBangService.delete(id);
                    _traLaiHangBangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

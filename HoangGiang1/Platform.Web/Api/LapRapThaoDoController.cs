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
    [RoutePrefix("api/laprapthaodo")]
    [Authorize]
    public class LapRapThaoDoController : ApiControllerBase
    {
        ILapRapThaoDoService _lapRapThaoDoService;

        public LapRapThaoDoController(ILoiService loiService, ILapRapThaoDoService lapRapThaoDoService) : base(loiService)
        {
            this._lapRapThaoDoService = lapRapThaoDoService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<LapRapThaoDoViewModel> lapRapThaoDoVM)
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
        //            foreach (var item in lapRapThaoDoVM)
        //            {
        //                var newThongBao = new LapRapThaoDo();
        //                newThongBao.UpdateLapRapThaoDo(item);

        //                _lapRapThaoDoService.Add(newThongBao);
        //                _lapRapThaoDoService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, LapRapThaoDoViewModel lapRapThaoDoViewModel)

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

        //            var vienchucDb = _lapRapThaoDoService.getID(Convert.ToInt32(lapRapThaoDoViewModel.ID));

        //            vienchucDb.UpdateLapRapThaoDo(lapRapThaoDoViewModel);
        //            _lapRapThaoDoService.Update(vienchucDb);
        //            _lapRapThaoDoService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}



        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, LapRapThaoDoViewModel khachHang)
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
                    var newThongBao = new LapRapThaoDo();
                    newThongBao.UpdateLapRapThaoDo(khachHang);

                    _lapRapThaoDoService.Add(newThongBao);
                    _lapRapThaoDoService.Save();
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


                var listCategory = _lapRapThaoDoService.GetAll();
              //  var responseData = Mapper.Map<IEnumerable<LapRapThaoDo>,IEnumerable<LapRapThaoDoViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
       [Route("getlenhlaprapthaodo")]
        public HttpResponseMessage getlenhlaprapthaodo(HttpRequestMessage request, DateTime ngaydau, DateTime ngaycuoi)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _lapRapThaoDoService.getlenhlaprapthaodo(ngaydau, ngaycuoi);
              //  var responseData = Mapper.Map<IEnumerable<LapRapThaoDo>,IEnumerable<LapRapThaoDoViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
      
        




        public HttpResponseMessage Post(HttpRequestMessage request, LapRapThaoDo lapRapThaoDo)
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
                    _lapRapThaoDoService.Add(lapRapThaoDo);
                    _lapRapThaoDoService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, LapRapThaoDo lapRapThaoDo)
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
                    _lapRapThaoDoService.Update(lapRapThaoDo);
                    _lapRapThaoDoService.Commit();

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
                    _lapRapThaoDoService.delete(id);
                    _lapRapThaoDoService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

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
    [RoutePrefix("api/chitietlaprapthaodo")]
    [Authorize]
    public class ChiTietLapRapThaoDoController : ApiControllerBase
    {
        IChiTietLapRapThaoDoService _chiTietLapRapThaoDoService;

        public ChiTietLapRapThaoDoController(ILoiService loiService, IChiTietLapRapThaoDoService chiTietLapRapThaoDoService) : base(loiService)
        {
            this._chiTietLapRapThaoDoService = chiTietLapRapThaoDoService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietLapRapThaoDoViewModel> chiTietLapRapThaoDoVM)
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
        //            foreach (var item in chiTietLapRapThaoDoVM)
        //            {
        //                var newThongBao = new ChiTietLapRapThaoDo();
        //                newThongBao.UpdateChiTietLapRapThaoDo(item);

        //                _chiTietLapRapThaoDoService.Add(newThongBao);
        //                _chiTietLapRapThaoDoService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, ChiTietLapRapThaoDoViewModel chiTietLapRapThaoDoViewModel)

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

        //            var vienchucDb = _chiTietLapRapThaoDoService.getID(Convert.ToInt32(chiTietLapRapThaoDoViewModel.ID));

        //            vienchucDb.UpdateChiTietLapRapThaoDo(chiTietLapRapThaoDoViewModel);
        //            _chiTietLapRapThaoDoService.Update(vienchucDb);
        //            _chiTietLapRapThaoDoService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietLapRapThaoDoViewModel> chiTietLapRapThaoDoVM)
        {


            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    foreach (var item in chiTietLapRapThaoDoVM)
                    {
                        var newThongBao = new ChiTietLapRapThaoDo();
                        newThongBao.UpdateChiTietLapRapThaoDo(item);

                        _chiTietLapRapThaoDoService.Add(newThongBao);
                        _chiTietLapRapThaoDoService.Save();
                    }
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


                var listCategory = _chiTietLapRapThaoDoService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<ChiTietLapRapThaoDo>,IEnumerable<ChiTietLapRapThaoDoViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaChiTietLapRapThaoDo.Length + x.MaChiTietLapRapThaoDo);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
         [Route("getchitietlenhlaprapthaodo")]
        public HttpResponseMessage getchitietlenhlaprapthaodo(HttpRequestMessage request, string MaLapRapThaoDo)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _chiTietLapRapThaoDoService.getchitietlenhlaprapthaodo(MaLapRapThaoDo);
                //  var responseData = Mapper.Map<IEnumerable<ChiTietLapRapThaoDo>,IEnumerable<ChiTietLapRapThaoDoViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaChiTietLapRapThaoDo.Length + x.MaChiTietLapRapThaoDo);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        

        public HttpResponseMessage Post(HttpRequestMessage request, ChiTietLapRapThaoDo chiTietLapRapThaoDo)
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
                    _chiTietLapRapThaoDoService.Add(chiTietLapRapThaoDo);
                    _chiTietLapRapThaoDoService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, ChiTietLapRapThaoDo chiTietLapRapThaoDo)
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
                    _chiTietLapRapThaoDoService.Update(chiTietLapRapThaoDo);
                    _chiTietLapRapThaoDoService.Commit();

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
                    _chiTietLapRapThaoDoService.delete(id);
                    _chiTietLapRapThaoDoService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

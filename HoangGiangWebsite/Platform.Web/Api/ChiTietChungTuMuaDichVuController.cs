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
    [RoutePrefix("api/chitietchungtumuadichvu")]
    [Authorize]
    public class ChiTietChungTuMuaDichVuController : ApiControllerBase
    {
        IChiTietChungTuMuaDichVuService _chiTietChungTuMuaDichVuService;

        public ChiTietChungTuMuaDichVuController(ILoiService loiService, IChiTietChungTuMuaDichVuService chiTietChungTuMuaDichVuService) : base(loiService)
        {
            this._chiTietChungTuMuaDichVuService = chiTietChungTuMuaDichVuService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietChungTuMuaDichVuViewModel> chiTietChungTuMuaDichVuVM)
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
        //            foreach (var item in chiTietChungTuMuaDichVuVM)
        //            {
        //                var newThongBao = new ChiTietChungTuMuaDichVu();
        //                newThongBao.UpdateChiTietChungTuMuaDichVu(item);

        //                _chiTietChungTuMuaDichVuService.Add(newThongBao);
        //                _chiTietChungTuMuaDichVuService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, ChiTietChungTuMuaDichVuViewModel chiTietChungTuMuaDichVuViewModel)

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

        //            var vienchucDb = _chiTietChungTuMuaDichVuService.getID(Convert.ToInt32(chiTietChungTuMuaDichVuViewModel.ID));

        //            vienchucDb.UpdateChiTietChungTuMuaDichVu(chiTietChungTuMuaDichVuViewModel);
        //            _chiTietChungTuMuaDichVuService.Update(vienchucDb);
        //            _chiTietChungTuMuaDichVuService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietChungTuMuaDichVuViewModel> chiTietChungTuMuaDichVuVM)
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
                    foreach (var item in chiTietChungTuMuaDichVuVM)
                    {
                        var newThongBao = new ChiTietChungTuMuaDichVu();
                        newThongBao.UpdateChiTietChungTuMuaDichVu(item);

                        _chiTietChungTuMuaDichVuService.Add(newThongBao);
                        _chiTietChungTuMuaDichVuService.Save();
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


                var listCategory = _chiTietChungTuMuaDichVuService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<ChiTietChungTuMuaDichVu>,IEnumerable<ChiTietChungTuMuaDichVuViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaChiTietChungTuMuaDichVu.Length + x.MaChiTietChungTuMuaDichVu);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

        [Route("getchitietchungtumuadichvu")]
        [HttpGet]
        public HttpResponseMessage getchitietchungtumuadichvu(HttpRequestMessage request,string machungtu)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _chiTietChungTuMuaDichVuService.getchitietchungtumuadichvu(machungtu);
             
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }



        public HttpResponseMessage Post(HttpRequestMessage request, ChiTietChungTuMuaDichVu chiTietChungTuMuaDichVu)
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
                    _chiTietChungTuMuaDichVuService.Add(chiTietChungTuMuaDichVu);
                    _chiTietChungTuMuaDichVuService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, ChiTietChungTuMuaDichVu chiTietChungTuMuaDichVu)
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
                    _chiTietChungTuMuaDichVuService.Update(chiTietChungTuMuaDichVu);
                    _chiTietChungTuMuaDichVuService.Commit();

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
                    _chiTietChungTuMuaDichVuService.delete(id);
                    _chiTietChungTuMuaDichVuService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

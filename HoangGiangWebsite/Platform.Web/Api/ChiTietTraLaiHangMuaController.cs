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
    [RoutePrefix("api/chitiettralaihangmua")]
    [Authorize]
    public class ChiTietTraLaiHangMuaController : ApiControllerBase
    {
        IChiTietTraLaiHangMuaService _chiTietTraLaiHangMuaService;

        public ChiTietTraLaiHangMuaController(ILoiService loiService, IChiTietTraLaiHangMuaService chiTietTraLaiHangMuaService) : base(loiService)
        {
            this._chiTietTraLaiHangMuaService = chiTietTraLaiHangMuaService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietTraLaiHangMuaViewModel> chiTietTraLaiHangMuaVM)
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
        //            foreach (var item in chiTietTraLaiHangMuaVM)
        //            {
        //                var newThongBao = new ChiTietTraLaiHangMua();
        //                newThongBao.UpdateChiTietTraLaiHangMua(item);

        //                _chiTietTraLaiHangMuaService.Add(newThongBao);
        //                _chiTietTraLaiHangMuaService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, ChiTietTraLaiHangMuaViewModel chiTietTraLaiHangMuaViewModel)

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

        //            var vienchucDb = _chiTietTraLaiHangMuaService.getID(Convert.ToInt32(chiTietTraLaiHangMuaViewModel.ID));

        //            vienchucDb.UpdateChiTietTraLaiHangMua(chiTietTraLaiHangMuaViewModel);
        //            _chiTietTraLaiHangMuaService.Update(vienchucDb);
        //            _chiTietTraLaiHangMuaService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietTraLaiHangMuaViewModel> chiTietTraLaiHangMuaVM)
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
                    foreach (var item in chiTietTraLaiHangMuaVM)
                    {
                        var newThongBao = new ChiTietTraLaiHangMua();
                        newThongBao.UpdateChiTietTraLaiHangMua(item);

                        _chiTietTraLaiHangMuaService.Add(newThongBao);
                        _chiTietTraLaiHangMuaService.Save();
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


                var listCategory = _chiTietTraLaiHangMuaService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<ChiTietTraLaiHangMua>,IEnumerable<ChiTietTraLaiHangMuaViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaChiTietTraLaiHangMua.Length + x.MaChiTietTraLaiHangMua);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("getchitiettralaihangmua")]
        public HttpResponseMessage getchitiettralaihangmua(HttpRequestMessage request, string MaTraLaiHang)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _chiTietTraLaiHangMuaService.getchitiettralaihangmua(MaTraLaiHang);
             
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }


      

        public HttpResponseMessage Post(HttpRequestMessage request, ChiTietTraLaiHangMua chiTietTraLaiHangMua)
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
                    _chiTietTraLaiHangMuaService.Add(chiTietTraLaiHangMua);
                    _chiTietTraLaiHangMuaService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, ChiTietTraLaiHangMua chiTietTraLaiHangMua)
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
                    _chiTietTraLaiHangMuaService.Update(chiTietTraLaiHangMua);
                    _chiTietTraLaiHangMuaService.Commit();

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
                    _chiTietTraLaiHangMuaService.delete(id);
                    _chiTietTraLaiHangMuaService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

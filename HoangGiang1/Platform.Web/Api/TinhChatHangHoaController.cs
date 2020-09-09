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
    [RoutePrefix("api/tinhchathanghoa")]
    [Authorize]
    public class TinhChatHangHoaController : ApiControllerBase
    {
        ITinhChatHangHoaService _tinhChatHangHoaService;

        public TinhChatHangHoaController(ILoiService loiService, ITinhChatHangHoaService tinhChatHangHoaService) : base(loiService)
        {
            this._tinhChatHangHoaService = tinhChatHangHoaService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<TinhChatHangHoaViewModel> tinhChatHangHoaVM)
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
        //            foreach (var item in tinhChatHangHoaVM)
        //            {
        //                var newThongBao = new TinhChatHangHoa();
        //                newThongBao.UpdateTinhChatHangHoa(item);

        //                _tinhChatHangHoaService.Add(newThongBao);
        //                _tinhChatHangHoaService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, TinhChatHangHoaViewModel tinhChatHangHoaViewModel)

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

        //            var vienchucDb = _tinhChatHangHoaService.getID(Convert.ToInt32(tinhChatHangHoaViewModel.ID));

        //            vienchucDb.UpdateTinhChatHangHoa(tinhChatHangHoaViewModel);
        //            _tinhChatHangHoaService.Update(vienchucDb);
        //            _tinhChatHangHoaService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}





        //[Route("create")]
        //[HttpPost]
        //public HttpResponseMessage Create(HttpRequestMessage request, TinhChatHangHoaViewModel khachHang)
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
        //            var newThongBao = new TinhChatHangHoa();
        //            newThongBao.UpdateTinhChatHangHoa(khachHang);

        //            _tinhChatHangHoaService.Add(newThongBao);
        //            _tinhChatHangHoaService.Save();
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


                var listCategory = _tinhChatHangHoaService.GetAll();
              //  var responseData = Mapper.Map<IEnumerable<TinhChatHangHoa>,IEnumerable<TinhChatHangHoaViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }


      

        public HttpResponseMessage Post(HttpRequestMessage request, TinhChatHangHoa tinhChatHangHoa)
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
                    _tinhChatHangHoaService.Add(tinhChatHangHoa);
                    _tinhChatHangHoaService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, TinhChatHangHoa tinhChatHangHoa)
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
                    _tinhChatHangHoaService.Update(tinhChatHangHoa);
                    _tinhChatHangHoaService.Commit();

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
                    _tinhChatHangHoaService.delete(id);
                    _tinhChatHangHoaService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

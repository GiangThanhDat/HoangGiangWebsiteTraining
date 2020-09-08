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
    [RoutePrefix("api/hanghoa_donvitinh")]
    [Authorize]
    public class HangHoa_DonViTinhController : ApiControllerBase
    {
        IHangHoa_DonViTinhService _hangHoa_DonViTinhService;

        public HangHoa_DonViTinhController(ILoiService loiService, IHangHoa_DonViTinhService hangHoa_DonViTinhService) : base(loiService)
        {
            this._hangHoa_DonViTinhService = hangHoa_DonViTinhService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<HangHoa_DonViTinhViewModel> hangHoa_DonViTinhVM)
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
        //            foreach (var item in hangHoa_DonViTinhVM)
        //            {
        //                var newThongBao = new HangHoa_DonViTinh();
        //                newThongBao.UpdateHangHoa_DonViTinh(item);

        //                _hangHoa_DonViTinhService.Add(newThongBao);
        //                _hangHoa_DonViTinhService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, HangHoa_DonViTinhViewModel hangHoa_DonViTinhViewModel)

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

        //            var vienchucDb = _hangHoa_DonViTinhService.getID(Convert.ToInt32(hangHoa_DonViTinhViewModel.ID));

        //            vienchucDb.UpdateHangHoa_DonViTinh(hangHoa_DonViTinhViewModel);
        //            _hangHoa_DonViTinhService.Update(vienchucDb);
        //            _hangHoa_DonViTinhService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}







        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, HangHoa_DonViTinhViewModel khachHang)
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
                    var newThongBao = new HangHoa_DonViTinh();
                    newThongBao.UpdateHangHoa_DonViTinh(khachHang);

                    _hangHoa_DonViTinhService.Add(newThongBao);
                    _hangHoa_DonViTinhService.Save();
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


                var listCategory = _hangHoa_DonViTinhService.GetAll();
              //  var responseData = Mapper.Map<IEnumerable<HangHoa_DonViTinh>,IEnumerable<HangHoa_DonViTinhViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }


      

        public HttpResponseMessage Post(HttpRequestMessage request, HangHoa_DonViTinh hangHoa_DonViTinh)
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
                    _hangHoa_DonViTinhService.Add(hangHoa_DonViTinh);
                    _hangHoa_DonViTinhService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, HangHoa_DonViTinh hangHoa_DonViTinh)
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
                    _hangHoa_DonViTinhService.Update(hangHoa_DonViTinh);
                    _hangHoa_DonViTinhService.Commit();

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
                    _hangHoa_DonViTinhService.delete(id);
                    _hangHoa_DonViTinhService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

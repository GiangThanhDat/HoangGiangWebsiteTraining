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
    [RoutePrefix("api/dondathang")]
    [Authorize]
    public class DonDatHangController : ApiControllerBase
    {
        IDonDatHangService _donDatHanggService;

        public DonDatHangController(ILoiService loiService, IDonDatHangService donDatHanggService) : base(loiService)
        {
            this._donDatHanggService = donDatHanggService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<DonDatHangViewModel> donDatHanggVM)
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
        //            foreach (var item in donDatHanggVM)
        //            {
        //                var newThongBao = new DonDatHang();
        //                newThongBao.UpdateDonDatHang(item);

        //                _donDatHanggService.Add(newThongBao);
        //                _donDatHanggService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, DonDatHangViewModel donDatHanggViewModel)

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

        //            var vienchucDb = _donDatHanggService.getID(Convert.ToInt32(donDatHanggViewModel.ID));

        //            vienchucDb.UpdateDonDatHang(donDatHanggViewModel);
        //            _donDatHanggService.Update(vienchucDb);
        //            _donDatHanggService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}





        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, DonDatHangViewModel khachHang)
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
                    var newThongBao = new DonDatHang();
                    newThongBao.UpdateDonDatHang(khachHang);

                    _donDatHanggService.Add(newThongBao);
                    _donDatHanggService.Save();
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


                var listCategory = _donDatHanggService.GetAll();
              //  var responseData = Mapper.Map<IEnumerable<DonDatHang>,IEnumerable<DonDatHangViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
         [Route("gettdondathang")]
        public HttpResponseMessage gettdondathang(HttpRequestMessage request, DateTime ngaydau, DateTime ngaycuoi)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _donDatHanggService.gettdondathang(ngaydau, ngaycuoi);
           

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

        


        public HttpResponseMessage Post(HttpRequestMessage request, DonDatHang donDatHangg)
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
                    _donDatHanggService.Add(donDatHangg);
                    _donDatHanggService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, DonDatHang donDatHangg)
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
                    _donDatHanggService.Update(donDatHangg);
                    _donDatHanggService.Commit();

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
                    _donDatHanggService.delete(id);
                    _donDatHanggService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}

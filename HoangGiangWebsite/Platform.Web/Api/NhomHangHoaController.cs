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
    [RoutePrefix("api/nhomhanghoa")]
    [Authorize]
    public class NhomHangHoaController : ApiControllerBase
    {
        INhomHangHoaService _nhomHangHoaService;

        public NhomHangHoaController(ILoiService loiService, INhomHangHoaService nhomHangHoaService) : base(loiService)
        {
            this._nhomHangHoaService = nhomHangHoaService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietBaoGiaViewModel> chiTietBaoGiaVM)
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
        //            foreach (var item in chiTietBaoGiaVM)
        //            {
        //                var newThongBao = new ChiTietBaoGia();
        //                newThongBao.UpdateChiTietBaoGia(item);

        //                _nhomHangHoaService.Add(newThongBao);
        //                _nhomHangHoaService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, ChiTietBaoGiaViewModel chiTietBaoGiaViewModel)

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

        //            var vienchucDb = _nhomHangHoaService.getID(Convert.ToInt32(chiTietBaoGiaViewModel.ID));

        //            vienchucDb.UpdateChiTietBaoGia(chiTietBaoGiaViewModel);
        //            _nhomHangHoaService.Update(vienchucDb);
        //            _nhomHangHoaService.Commit();

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


                var listCategory = _nhomHangHoaService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<ChiTietBaoGia>,IEnumerable<ChiTietBaoGiaViewModel>>(listCategory);
                // var b = listCategory.OrderBy(x => x.MaChiTietBaoGia.Length + x.MaChiTietBaoGia);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

       





        public HttpResponseMessage Post(HttpRequestMessage request, NhomHangHoa nhomHangHoa)
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
                    _nhomHangHoaService.Add(nhomHangHoa);
                    _nhomHangHoaService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, NhomHangHoa nhomHangHoa)
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
                    _nhomHangHoaService.Update(nhomHangHoa);
                    _nhomHangHoaService.Commit();

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
                    _nhomHangHoaService.delete(id);
                    _nhomHangHoaService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}
